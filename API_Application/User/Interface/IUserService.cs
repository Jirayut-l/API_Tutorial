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
        Task<Result<AuthenticateResponseModel>> Authenticate(AuthenticateRequestModel model, string ipAddress);
        Task<Result<AuthenticateResponseModel>> RefreshToken(string token, string ipAddress);
        Task<Result<IEnumerable<RefreshTokenModel>>> GetAllRefreshToken();
        Task<Result> RevokeToken(string token, string ipAddress);
    }

}
