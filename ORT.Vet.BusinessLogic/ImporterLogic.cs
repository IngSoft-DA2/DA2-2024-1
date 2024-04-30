using System.Reflection;
using IImporter;
using ORT.Vet.IBusinessLogic;


namespace ORT.Vet.BusinessLogic;

public class ImporterLogic : IImporterLogic
{
    public List<ImporterInterface> GetAllImporters()
    {
        var importersPath = "./Importers"; // Se puede usar appsettings.json
        string[] filePaths = Directory.GetFiles(importersPath);
        // ej: filePaths = ["./Importers/JsonImporter.dll", "./Importers/CSVImporter.dll"]
        List<ImporterInterface> availableImporters = new List<ImporterInterface>();

        foreach (string file in filePaths)
        {
            if (FileIsDll(file))
            {
                FileInfo dllFile  = new FileInfo(file);
                Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);

                // ej de GetTypes -> [JSONImporter, CSVImporter]
                foreach (Type type in myAssembly.GetTypes())
                {
                    if (ImplementsRequiredInterface(type))
                    {
                        ImporterInterface instance = (ImporterInterface)Activator.CreateInstance(type);
                        availableImporters.Add(instance);
                    }
                }
            }
        }

        return availableImporters;
    }
    
    
    private bool FileIsDll(string file)
    {
        return file.EndsWith("dll");
    }
    
    public bool ImplementsRequiredInterface(Type type)
    {
        return typeof(ImporterInterface).IsAssignableFrom(type) && !type.IsInterface;
    }
}