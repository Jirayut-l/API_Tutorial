using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using API_Infrastructure;
using API_Model;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API_Application
{
    public class UserService : IUserService
    {
        private readonly IUserLoginService _userLoginService;

        public UserService(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        public Task<Result<IEnumerable<UserLoginModel>>> GetAllUserLogin()
        {
            try
            {
                var result = _userLoginService.GetAllUser();
                return Task.FromResult(ResultMessage<IEnumerable<UserLoginModel>>.Success(result));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage<IEnumerable<UserLoginModel>>.ExceptionError(ex));
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

        public Task<Result> DeleteUserLogin(int pkUid)
        {
            try
            {
                if (pkUid <= 0) return Task.FromResult(ResultMessage.Error(Constants.IsNullValue));
                _userLoginService.Delete(pkUid);
                return Task.FromResult(ResultMessage.Success(Constants.DeleteSuccess));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage.ExceptionError(ex));
            }
        }

        public Task<Result> UpdateUserLogin(int pkUid, UserLoginModel model)
        {
            try
            {
                if (pkUid < 0) return Task.FromResult(ResultMessage.Error(Constants.IsNullValue));
                _userLoginService.Update(pkUid,model);
                return Task.FromResult(ResultMessage.Success(Constants.UpdateSuccess));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage.ExceptionError(ex));
            }
        }

        public Task<Result> UpdateRangeUserLogin(IEnumerable<UserLoginModel> models)
        {
            try
            {
                _userLoginService.UpdateRange(models);
                return Task.FromResult(ResultMessage.Success(Constants.UpdateSuccess));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage.ExceptionError(ex));
            }
        }

    }
}
