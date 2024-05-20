using ORT.Vet.Domain;

namespace ORT.Vet.IDataAccess;

public interface IUserRepository : IGenericRepository<User>
{
    User? FindByToken(Guid token);
    User? FindByName(string name);
    void AddSession(Session session);
}