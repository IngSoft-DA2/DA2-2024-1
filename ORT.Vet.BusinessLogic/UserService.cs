using ORT.Vet.Domain;
using ORT.Vet.IDataAccess;
using ORT.Vet.IBusinessLogic;

namespace ORT.Vet.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.Insert(user);
            _userRepository.Save();
        }
    }
}