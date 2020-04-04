using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model;
using DAL;
using Common;
namespace Bll.Impl
{
    public class BaseBll<T> : IBaseBll<T> where T : ID, new()
    {
       protected IBaseDAL<T> dal;  //-----------待处理
        public BaseBll(IBaseDAL<T> dal)
        {
            this.dal = dal;
        }
        public bool Add(T o)
        {
            return dal.Add(o);
        }

        public bool Delete(T o)
        {
            return dal.Delete(o);
        }
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public bool Delete(Expression<Func<T, bool>> where)
        {
            return dal.Delete(where);
        }
        public bool Update(T o, params string[] propertyNames)
        {
            return dal.Update(o, propertyNames);
        }
        public bool Update(T o)
        {
            return dal.Update(o);
        }
        public T SelectOne(int id)
        {
            return dal.SelectOne(id);
        }
        public T SelectOne(Expression<Func<T, bool>> where)
        {
            return dal.SelectOne(where);
        }
        public Pagination<T> Query(Dictionary<string, string> where)
        {
            return dal.Query(where);
        }
        public IEnumerable<T> SelectAll()
        {
            return dal.SelectAll();
        }
        public IEnumerable<T> SelectAll(Expression<Func<T, bool>> where)
        {
            return dal.SelectAll(where);
        }
        public Pagination<T> SelectAll(Expression<Func<T, bool>> where, int pageNo, int pageSize)
        {
            return dal.SelectAll(where, pageNo, pageSize);
        }
        public Pagination<T>  SelectAll<OrderKey>(Expression<Func<T, bool>> whereLambda, Func<T, OrderKey> orderbyLambda, bool asc, int pageNo, int pageSize)
        {
            return dal.SelectAll(whereLambda, orderbyLambda, asc, pageNo, pageSize);
        }

    }
}
