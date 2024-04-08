using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ORT.Vet.Domain;

namespace ORT.Vet.DataAccess.Test;

[TestClass]
public class PetRepositoryTest
{
    private SqliteConnection _connection;
    private VetContext _context;
    private PetRepository _petRepository;
    
    [TestInitialize]
    public void Setup()
    {
        // Fake in-memory database
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        var contextOptions = new DbContextOptionsBuilder<VetContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new VetContext(contextOptions);
        _context.Database.EnsureCreated();

        _petRepository = new PetRepository(_context);
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _context.Database.EnsureDeleted();
    }
    
    [TestMethod]
    public void GetAllPetsTest()
    {
        // Arrange
        var expectedPets = TestData();
        LoadContext(expectedPets);
        
        var retrievedPets = _petRepository.GetAll<Pet>();
        CollectionAssert.AreEqual(expectedPets, retrievedPets.ToList());
    }
    
    private void LoadContext(List<Pet> pets)
    {
        _context.Pets.AddRange(pets);
        _context.SaveChanges();
    }

    private List<Pet> TestData()
    {
        return new List<Pet>
        {
            new Pet { Name = "Kila", Age = 2, Owner = new Owner() { Name = "John" } },
            new Pet { Name = "Toby", Age = 3, Owner = new Owner() { Name = "John" } }
        };
    }
}