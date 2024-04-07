using Microsoft.EntityFrameworkCore;
using ORT.Vet.Domain;

namespace ORT.Vet.DataAccess;
public class PetRepository : GenericRepository<Pet>
{
    public PetRepository(DbContext context)
    {
        Context = context;
    }

    public IEnumerable<Pet> FindByOwner(int ownerId)
    {
        return Context.Set<Pet>().Where(p => p.OwnerId == ownerId).ToList();
    }
}

