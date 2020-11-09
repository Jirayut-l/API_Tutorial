using API_Model;

namespace API_Application
{
    public interface IUserService
    {
        string printText();
        UserLoginModel GetUserLogin();
    }

}
