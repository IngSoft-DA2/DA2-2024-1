using Microsoft.EntityFrameworkCore;
using ORT.Vet.Domain;
using ORT.Vet.IDataAccess;

namespace ORT.Vet.DataAccess;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DbContext context)
    {
        Context = context;
    }

    public User? FindByToken(Guid token)
    {
        var session = Context.Set<Session>().FirstOrDefault(s => s.Token == token);
        return session?.User;
    }
}