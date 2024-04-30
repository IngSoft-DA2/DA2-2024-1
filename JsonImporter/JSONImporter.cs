using IImporter;
using ORT.Vet.Domain;

namespace JsonImporter;


public class JSONImporter : ImporterInterface
{
    public string GetName()
    {
        return "JSON Importer";
    }

    public List<Pet> ImportPets()
    {
        // Harcodeado - Aca deberia leer el archivo JSON de verdad
        return new List<Pet>()
        {
            new Pet()
            {
                Age = 2, Name = "Fluffy", Id = 1, Owner = new Owner() { Id = 1, Name = "John Doe" }, OwnerId = 1
            }
        };
    }
}