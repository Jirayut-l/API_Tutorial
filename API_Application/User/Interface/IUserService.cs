using System.Collections.Generic;
using System.Threading.Tasks;
using API_Model;

namespace API_Application
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserLoginModel>>> GetAllUserLogin();
        Task<Result<UserLoginModel>> GetUserLogin(int pkUid);
        Task<Result> CreateUserLogin(UserLoginModel model);
        Task<Result> DeleteUserLogin(int pkUid);
        Task<Result> UpdateUserLogin(int pkUid,UserLoginModel model);
        Task<Result> UpdateRangeUserLogin(IEnumerable<UserLoginModel> models);
    }

}
