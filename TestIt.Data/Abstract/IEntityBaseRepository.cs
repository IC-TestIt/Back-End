using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestIt.Model;

namespace TestIt.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T SingleIncluding(int id, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        T GetSingle(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddMultiple(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Commit();
        void AddOrUpdate(T entity);
        void AddOrUpdateMultiple(List<T> list);
    }
}
