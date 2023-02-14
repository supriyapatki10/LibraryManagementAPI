using System;
using LibraryManagementAPI.Services.Contracts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Entities;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        // protected
        private readonly RepositoryContext RepositoryContext;
        
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

        /// <summary>
        /// Generic search which would compare all columns from given entity against searchString
        /// </summary>
        /// <param name="query"></param>
        public IQueryable<T> FindAllColumns(string searchString)
        {
            //first find all properties within T class with same type as query.
            var stringProperties = typeof(T).GetProperties().Where(prop =>
                prop.PropertyType == searchString.GetType());

            // then find all rows from context that has at least one property/column with value equal to query:
            var searchResults = RepositoryContext.Set<T>().Where(book =>
               stringProperties.Any(prop =>
               (string)prop.GetValue(book, null) == searchString));
            return searchResults;
        }


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}

