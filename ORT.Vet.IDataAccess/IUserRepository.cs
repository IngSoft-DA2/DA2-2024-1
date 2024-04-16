using ORT.Vet.Domain;

namespace ORT.Vet.IDataAccess;

public interface IUserRepository : IGenericRepository<User>
{
    User? FindByToken(Guid token);
}