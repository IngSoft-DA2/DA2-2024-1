using ORT.Vet.Domain;

namespace IImporter;

public interface ImporterInterface
{
    string GetName();
    
    // 2. Esta bien compartir el dominio?
    List<Pet> ImportPets();
    
    // 3. Que pasa si necesito parametros?
    // List<Parameters> NecessaryParameters();
    // retornaria -> [ { Name: "Path de archivo JSON", Type: ParamType.String } ]

    // class Parameters
    // {
    //     public string Name { get; set; }
    //     public ParamType Type { get; set; }
    // }
    //
    // enum ParamType
    // {
    //     Integer,
    //     String,
    //     Boolean,
    //     Date
    // }
}
