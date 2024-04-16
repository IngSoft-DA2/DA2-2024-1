using ORT.Vet.DataAccess;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;

namespace ORT.Vet.BusinessLogic;

public class SessionLogic : ISessionLogic
{
    private readonly UserRepository _repository;
    private User? _currentUser;

    public SessionLogic(UserRepository repository)
    {
        _repository = repository;
    }

    public User? GetCurrentUser(Guid? token = null)
    {
        if (token == null)
        {
            return _currentUser;
        }
        
        _currentUser = _repository.FindByToken(token.Value);
        return _currentUser;
    }
}