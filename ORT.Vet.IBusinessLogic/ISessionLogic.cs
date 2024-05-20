using ORT.Vet.Domain;

namespace ORT.Vet.IBusinessLogic;

public interface ISessionLogic
{
    User? GetCurrentUser(Guid? token = null);
    Guid Authenticate(string name, string password);
}