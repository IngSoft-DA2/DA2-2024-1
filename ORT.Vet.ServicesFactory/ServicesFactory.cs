using Microsoft.Extensions.DependencyInjection;
using ORT.Vet.BusinessLogic;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;

namespace ORT.Vet.ServicesFactory;

public class ServicesFactory
{
    public ServicesFactory() { }

    public void RegisterServices(IServiceCollection serviceCollection){
        serviceCollection.AddScoped<IBusinessLogic<Pet>, PetLogic>();
    }

}
