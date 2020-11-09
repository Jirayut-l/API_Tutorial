using System.Threading.Tasks;
using API_Model;

namespace API_Application
{
    public interface IUserService
    {
        Task<Result<UserLoginModel>> GetAllUserLogin();
        Task<Result> CreateUserLogin(UserLoginModel model);
        Task<Result> DeleteUserLogin(int PkUid);
    }

}
