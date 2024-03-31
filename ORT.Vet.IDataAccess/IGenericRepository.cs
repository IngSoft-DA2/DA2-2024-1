using System;
using System.Linq.Expressions;

namespace ORT.Vet.IDataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<U> GetAll<U>() where U : class;
        IEnumerable<U> GetAll<U>(Func<U, bool> predicate, List<string> includes = null) where U : class;

        void Insert(T entity);

        void Update(T entity);
        T Get(Expression<Func<T, bool>> searchCondition, List<string> includes = null);
        void Save();
        void Delete(T entity);
        bool CheckConnection();
    }
}
