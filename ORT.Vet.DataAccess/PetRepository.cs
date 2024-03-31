using Microsoft.EntityFrameworkCore;
using ORT.Vet.Domain;

namespace ORT.Vet.DataAccess;
public class PetRepository : GenericRepository<Pet>
{
    public PetRepository(DbContext context)
    {
        Context = context;
    }
}

