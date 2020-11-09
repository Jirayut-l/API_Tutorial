using API_Model;

namespace API_Infrastructure
{
    public interface IUserRepository
    {
        UserLoginModel GetUserLogin();
    }
}