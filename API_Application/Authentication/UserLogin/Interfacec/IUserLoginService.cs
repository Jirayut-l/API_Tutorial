using API_Model;

namespace API_Application

{
    public interface IUserLoginService
    {
        UserLoginModel GetAllUser();
        void Create(UserLoginModel model);
        void Delete(int pkUid);
    }
}