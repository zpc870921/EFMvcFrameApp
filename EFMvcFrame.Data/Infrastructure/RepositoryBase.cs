using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.SqlClient;
using EFMvcFrame.Model.Entites;
//using PagedList;


namespace EFMvcFrame.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private PersonDbContext dataContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public PersonDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            // dataContext.Entry(entity).p
            DataContext.Configuration.ValidateOnSaveEnabled = false;
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var item in properties)
            {
                //var attr = attProvider.GetAttributes(item).FirstOrDefault(a => a is UnableModifyAttribute);
                //UnableModifyAttribute attrModify = null;
                //if (attr == null || (attrModify = attr as UnableModifyAttribute) == null || attrModify.IsChanged)
                //{
                    this.DataContext.Entry(entity).Property(item.Name).IsModified = true;
                //}
                //this.dataContext.Entry(entity).Property

                //this.DataContext.Entry(entity).Property() 
            }

            //this.DataContext.Entry(entity).State = EntityState.
            // this.DataContext.Entry(entity).

            //dataContext.Entry(entity).State = EntityState.Modified;
            //DataContext.Entry(entity).Reload();
        }

        public virtual int ExecutSqlCommand(string sql, params object[] param)
        {
            return this.DataContext.Database.ExecuteSqlCommand(sql, param);
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetMany<TOrder>(Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            return dbset.Where(where).OrderByDescending(order).ToList();
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <param name="sortMode"></param>
        /// <returns></returns>
        public virtual IList<T> GetPage<TOrder>(Pagination page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, string sortMode = "desc")
        {
            var results = string.Equals(sortMode, "desc") ? dbset.OrderByDescending(order).Where(where).Skip(page.Start).Take(page.PageSize).ToList() : dbset.OrderBy(order).Where(where).Skip(page.Start).Take(page.PageSize).ToList();
            page.TotalItem = dbset.Count(where);
            return results;
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        //public int Execute(string sql,params object[] param)
        //{
        //    return this.DataContext.Database.ExecuteSqlCommand(sql, param);
        //}
    }
}
