using API_Model;

namespace API_Application

{
    public interface IUserLoginService
    {
        UserLoginModel GetAllUserLogin();
        void Create(UserLoginModel model);
    }
}