using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public UserLoginModel GetAllUser()
        {
            return _userLoginRepository.GetAllUserLogin();
        }

        public void Create(UserLoginModel model)
        {
            _userLoginRepository.Create(model);
        }

        public void Delete(int pkUid)
        {
           _userLoginRepository.Delete(pkUid);
        }
    }
}