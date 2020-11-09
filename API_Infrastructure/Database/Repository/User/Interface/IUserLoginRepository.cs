using API_Model;

namespace API_Infrastructure
{
    public interface IUserLoginRepository
    {
        UserLoginModel GetAllUserLogin();
        void Create(UserLoginModel model);
    }
}