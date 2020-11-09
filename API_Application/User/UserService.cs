using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string printText()
        {
            return "Print By Layer Application";
        }

        public UserLoginModel GetUserLogin()
        {
            return _userRepository.GetUserLogin();
        }
    }
}
