using IImporter;
using ORT.Vet.Domain;

namespace CSVImporter;

public class CSVImporter : ImporterInterface
{
    public string GetName()
    {
        return "CSV Importer";
    }

    public List<Pet> ImportPets()
    {
        // Harcodeado - Aca deberia leer el archivo CSV de verdad
        return new List<Pet>()
        {
            new Pet()
            {
                Age = 2, Name = "Fluffy", Id = 1, Owner = new Owner() { Id = 1, Name = "John Doe" }, OwnerId = 1
            }
        };
    }
}