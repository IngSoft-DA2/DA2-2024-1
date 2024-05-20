using ORT.Vet.IDataAccess;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;

namespace ORT.Vet.BusinessLogic;

public class SessionLogic : ISessionLogic
{
    private readonly IUserRepository _repository;
    private User? _currentUser;

    public SessionLogic(IUserRepository repository)
    {
        _repository = repository;
    }

        public Guid Authenticate(string name, string password)
        {
            var user = _repository.FindByName(name);

            if (user == null || user.Password != password)
            {
                throw new Exception("Invalid email or password.");
            }

            var session = new Session
            {
                User = user,
                UserId = user.Id
            };

            _repository.AddSession(session);

            return session.Token;
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