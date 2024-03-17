using System.Collections.Generic;

namespace ORT.Vet.IBusinessLogic
{
    public interface IBusinessLogic<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
    }
}
