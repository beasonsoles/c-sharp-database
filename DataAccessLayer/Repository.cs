using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        public Repository(DbContext datacontext)
        {
            DbSet = datacontext.Set<T>();
            this.context = datacontext;
        }
        public void Insert(T entity)
        {
            context.Entry(entity).State = System.Data.EntityState.Added;
            context.SaveChanges();
        }
        public void Delete(T entity) 
        {
            context.Entry(entity).State = System.Data.EntityState.Deleted;
            context.SaveChanges();
        }
        public void Update(T entity) 
        {
            context.Entry(entity).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }
        public T GetById(int id) 
        { 
            return context.Set<T>().Find(id);
        }
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return context.Where(predicate);
        }
        public IEnumerable<T> GetAll() 
        { 
            return context.Set<T>().ToList();
        }
        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        // This method will find the related records by passing two arguments
        // First argument: lambda expression to search a record such as d => d.StandardName.Equals(standardName)
        // to search a record by standard name
        // Second argument: navigation property that leads to the related records such as d => d.Students 
        // The method returns the related records that met the condition in the first argument.
        {
            T item = null;
            IQueryable<T> dbQuery = null;
            foreach(Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = DbSet.Include<T, object>(navigationProperty);
                item = dbQuery.AsNoTracking().FirstOrDefault(where);
                return item;
            }
        }
    }
}