using EFMvcFrame.Model.Entites;
//using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany<TOrder>(Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
        IList<T> GetPage<TOrder>(Pagination page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, string sortMode = "desc");
        int ExecutSqlCommand(string sql, params object[] param);
    }
}
