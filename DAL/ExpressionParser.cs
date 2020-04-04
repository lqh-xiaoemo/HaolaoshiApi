using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Util;
namespace DAL
{
    /// <summary>
    /// <see cref="Expression"/>解析器。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpressionParser<T>
    {
        public ParameterExpression Parameter { get; } = Expression.Parameter(typeof(T));
        public Expression<Func<T, bool>> ParserConditions(IEnumerable<Condition> conditions)
        {
            //将条件转化成表达是的Body
            var query = ParseExpressionBody(conditions);
            return Expression.Lambda<Func<T, bool>>(query, Parameter);
        }

        private Expression ParseExpressionBody(IEnumerable<Condition> conditions)
        {
            if (conditions == null || conditions.Count() == 0)
            {
                return Expression.Constant(true, typeof(bool));
            }
            else if (conditions.Count() == 1)
            {
                return ParseCondition(conditions.First());
            }
            else
            {
                Expression left = ParseCondition(conditions.First());
                Expression right = ParseExpressionBody(conditions.Skip(1));
                return Expression.AndAlso(left, right);
            }
        }

        private Expression ParseCondition(Condition condition)
        {
            Expression key = Expression.Property(Parameter, condition.Key);
            //通过Tuple元组，实现Sql参数化。
            Expression value = ToTuple(condition.Value, key.Type);

            switch (condition.Op)
            {
                case ConditionOp.Contains:
                    return Expression.Call(key, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), value);
                case ConditionOp.Eq:
                    return Expression.Equal(key, value);
                case ConditionOp.Gt:
                    return Expression.GreaterThan(key, value);
                case ConditionOp.Gte:
                    return Expression.GreaterThanOrEqual(key, value);
                case ConditionOp.Lt:
                    return Expression.LessThan(key, value);
                case ConditionOp.Lte:
                    return Expression.LessThanOrEqual(key, value);
                case ConditionOp.Ne:
                    return Expression.NotEqual(key, value);
                case ConditionOp.In:
                    return ParaseIn(condition);
                case ConditionOp.Between:
                    return ParaseBetween(condition);
                default:
                    throw new NotImplementedException("不支持此操作。");
            }
        }

        private Expression ParaseBetween(Condition conditions)
        {
            Expression key = Expression.Property(Parameter, conditions.Key);
            var valueArr = conditions.Value.ToString().Split(',');
            if (valueArr.Length != 2)
            {
                throw new NotImplementedException("ParaseBetween参数错误");
            }

            Expression expression = Expression.Constant(true, typeof(bool));
            if (double.TryParse(valueArr[0], out double v1)
                && double.TryParse(valueArr[1], out double v2))
            {
                Expression startvalue = ToTuple(v1, typeof(double));
                Expression start = Expression.GreaterThanOrEqual(key, Expression.Convert(startvalue, key.Type));
                Expression endvalue = ToTuple(v2, typeof(double));
                Expression end = Expression.LessThanOrEqual(key, Expression.Convert(endvalue, key.Type));
                return Expression.AndAlso(start, end);
            }
            else if (DateTime.TryParse(valueArr[0], out DateTime v3)
                && DateTime.TryParse(valueArr[1], out DateTime v4))
            {
                Expression startvalue = ToTuple(v3, typeof(DateTime));
                Expression start = Expression.GreaterThanOrEqual(key, Expression.Convert(startvalue, key.Type));
                Expression endvalue = ToTuple(v4, typeof(DateTime));
                Expression end = Expression.LessThanOrEqual(key, Expression.Convert(endvalue, key.Type));
                return Expression.AndAlso(start, end);
            }
            else
            {
                throw new NotImplementedException("ParaseBetween参数错误");
            }
        }

        private Expression ParaseIn(Condition conditions)
        {
            Expression key = Expression.Property(Parameter, conditions.Key);
            var valueArr = conditions.Value.ToString().Split(',');
            Expression expression = Expression.Constant(false, typeof(bool));
            foreach (var itemVal in valueArr)
            {
                //Expression value = Expression.Constant(itemVal);
                Expression value = ToTuple(itemVal, typeof(string));
                Expression right = Expression.Equal(key, Expression.Convert(value, key.Type));
                expression = Expression.Or(expression, right);
            }
            return expression;
        }

        private Expression ToTuple(object value, Type type)
        {
            var tuple = Tuple.Create(value);
            return Expression.Convert(
                 Expression.Property(Expression.Constant(tuple), nameof(tuple.Item1))
                 , type);
        }

    }


    /// <summary>
    /// 条件实体。
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConditionOp Op { get; set; }

        public OrderEnum Order { get; set; } = OrderEnum.None;
    }

    /// <summary>
    /// 排序方式枚举。
    /// </summary>
    public enum OrderEnum
    {
        /// <summary>
        /// 不排序。
        /// </summary>
        None,
        /// <summary>
        /// 升序。
        /// </summary>
        Asc,
        /// <summary>
        /// 降序。
        /// </summary>
        Desc
    }

    /// <summary>
    /// 条件标志。
    /// </summary>
    public enum ConditionOp
    {
        Contains,
        Eq,
        Ne,//NotEqual不等于
        Gt,//Greater
        Gte,// GreaterEqual
        Lt,//Less
        Lte,//LessEqual
        In,//包含
        Between
    }

    public static  class QueryableExtensions
    {
        /// <summary>
        /// 添加查询条件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static IQueryable<T> Conditions<T>(this IQueryable<T> query, IEnumerable<Condition> conditions)
        {
            var parser = new ExpressionParser<T>();
            var filter = parser.ParserConditions(conditions);
            query = query.Where(filter);
            foreach (var orderinfo in conditions.Where(c => c.Order != OrderEnum.None))
            {
                var t = typeof(T);
                var propertyInfo = t.GetProperty(orderinfo.Key);
                var parameter = Expression.Parameter(t);
                Expression propertySelector = Expression.Property(parameter, propertyInfo);

                var orderby = Expression.Lambda<Func<T, object>>(Expression.Convert(propertySelector, typeof(object)), parameter);
                if (orderinfo.Order == OrderEnum.Desc)
                    query = query.OrderByDescending(orderby);
                else
                    query = query.OrderBy(orderby);

            }
            return query;
        }
        /// <summary>
        /// 条件查询，自带分页。
        /// 添加过滤条件 如key="parent.id__eq" value = 1 如果添加时不加操作符 默认是等于eq 即如key=parent
        // 实际key是parent_eq
        //key 如 name__like、name__eq
        //  value 如果是in查询 多个值之间","分隔
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Pagination<T> Conditions<T>(this IQueryable<T> query, Dictionary<string, string> where)
        {
            int pageNo = 1, pageSize = 10;
            List<Condition> conditions = new List<Condition>();
            foreach (var w in where)
            {
                switch (w.Key)
                {
                    case "pageNo":
                        pageNo = Convert.ToInt32(w.Value);
                        break;
                    case "pageSize":
                        pageSize = Convert.ToInt32(w.Value);
                        break;
                    case "sort"://排序           
                        break;
                    default://查询字符串
                        var arr = w.Key.Split("__");
                        var c = new Condition() { Key = arr[0], Value = Reflect.ConvertPropertyType<T>(w.Key,w.Value),Op=ConditionOp.Eq };
                        if (arr.Length > 1) c.Op = (ConditionOp)Enum.Parse(typeof(ConditionOp), arr[1]);
                        conditions.Add(c); 
                        break;
                }
            }
            return Conditions<T>(query, conditions).Page(pageNo, pageSize);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNo">查询页码，如果查询页码小于1则查询所有</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Pagination<T> Page<T>(this IQueryable<T> query, int pageNo = 1, int pageSize = 10)
        {
            int total = query.Count();
            int pageCount = (int)(Math.Ceiling(total * 1.0 / pageSize));
            return Pagination<T>.Init(pageCount, total, pageNo>0? query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList(): query.ToList());
        }
    }
}
