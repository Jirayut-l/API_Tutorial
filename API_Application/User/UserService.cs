using System;
using System.Numerics;
using System.Threading.Tasks;
using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class UserService : IUserService
    {
        private readonly IUserLoginService _userLoginService;

        public UserService(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        public Task<Result<UserLoginModel>> GetAllUserLogin()
        {
            try
            {
                var result = _userLoginService.GetAllUserLogin();
                return Task.FromResult(ResultMessage<UserLoginModel>.Success(result));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage<UserLoginModel>.ExceptionError(ex));
            }
        }

        public Task<Result> CreateUserLogin(UserLoginModel model)
        {
            try
            {
                _userLoginService.Create(model);
                return Task.FromResult(ResultMessage.Success(Constants.CreateSuccess));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage.ExceptionError(ex));
            }
        }
    }
}
