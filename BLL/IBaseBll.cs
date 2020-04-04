using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model;
using Common;
namespace Bll
{
    public interface IBaseBll<T> where T : ID, new()
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        bool Delete(Expression<Func<T, bool>> where);
        bool Update(T entity, params string[] propertyNames);
        bool Update(T entity);
        T SelectOne(int id);
        Pagination<T> Query(Dictionary<string, string> where);
        T SelectOne(Expression<Func<T, bool>> whereLambda);
        IEnumerable<T> SelectAll();
        IEnumerable<T> SelectAll(Expression<Func<T, bool>> where);
        Pagination<T> SelectAll(Expression<Func<T, bool>> whereLambda, int pageNo, int pageSize);
        Pagination<T> SelectAll<OrderKey>(Expression<Func<T, bool>> whereLambda, Func<T, OrderKey> orderbyLambda, bool asc, int pageNo, int pageSize);
    }
}
