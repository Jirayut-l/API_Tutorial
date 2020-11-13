using API_Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace API_Application
{
    public class UserService : IUserService
    {
        private readonly IUserLoginService _userLoginService;
        private readonly AppSettings _appSettings;
        private readonly IEmployeeService _employeeService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRevokeTokenService _revokeTokenService;
        public UserService(IUserLoginService userLoginService, IOptions<AppSettings> appSettings, IEmployeeService employeeService, IRefreshTokenService refreshTokenService, IRevokeTokenService revokeTokenService)
        {
            _userLoginService = userLoginService;
            _employeeService = employeeService;
            _refreshTokenService = refreshTokenService;
            _revokeTokenService = revokeTokenService;
            _appSettings = appSettings.Value;
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

        public Task<Result<UserLoginModel>> GetUserLogin(int pkUid)
        {
            try
            {
                var result = _userLoginService.GetUserLoginByPK(pkUid);
                if (result == null) return Task.FromResult(ResultMessage<UserLoginModel>.Error(Constants.NotFound));
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
                _userLoginService.Update(pkUid, model);
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

        public Task<Result<AuthenticateResponseModel>> Authenticate(AuthenticateRequestModel model, string ipAddress)
        {
            try
            {
                var user = _userLoginService.Authenticate(model);

                if (user == null) return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Error(Constants.NotFoundUserLogin));

                var employee = _employeeService.GetEmployee(user.FkEmpId ?? 0);

                 var jwtToken = GenerateJwtToken(user);

                 var refreshToken = GenerateRefreshToken(ipAddress, model.Username);

                _refreshTokenService.CreateRefreshToken(refreshToken);

                var resultAuthentication = new AuthenticateResponseModel(employee, jwtToken, refreshToken.Token,user.Role);

                return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Success(resultAuthentication));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage<AuthenticateResponseModel>.ExceptionError(ex));
            }
        }

        public Task<Result<AuthenticateResponseModel>> RefreshToken(string token, string ipAddress)
        {
            try
            {
                var refreshToken = _refreshTokenService.GetRefreshTokenByToken(token);
                if (refreshToken == null)
                    return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Error(Constants.InvalidToken));

                if (!refreshToken.IsActive && !refreshToken.IsExpired)
                    return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Error(Constants.TokenExpired));

                var user =_userLoginService.GetAllUser().FirstOrDefault(f => f.Username == refreshToken.CreateByUser);

                if (user == null) return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Error(Constants.NotFoundUserLogin));

                var employee = _employeeService.GetEmployee(user.FkEmpId ?? 0);

                var jwtToken = GenerateJwtToken(user);

                var resultAuthentication = new AuthenticateResponseModel(employee, jwtToken, refreshToken.Token,user.Role);

                return Task.FromResult(ResultMessage<AuthenticateResponseModel>.Success(resultAuthentication));
            }
            catch (Exception ex)

            {
                return Task.FromResult(ResultMessage<AuthenticateResponseModel>.ExceptionError(ex));
            }
        }

        public Task<Result<IEnumerable<RefreshTokenModel>>> GetAllRefreshToken()
        {
            try
            {
                var allRefreshToken = _refreshTokenService.GetAll();
                return Task.FromResult(ResultMessage<IEnumerable<RefreshTokenModel>>.Success(allRefreshToken));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage<IEnumerable<RefreshTokenModel>>.ExceptionError(ex));
            }
        }

        public Task<Result> RevokeToken(string token, string ipAddress)
        {
            try
            {
                var result = _revokeTokenService.RevokeToken(token, ipAddress);
                return result;
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultMessage.ExceptionError(ex));
            }
        }

        private string GenerateJwtToken(UserLoginModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static RefreshTokenModel GenerateRefreshToken(string ipAddress, string username)
        {
            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshTokenModel
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(3),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                CreateByUser = username
            };
        }

    }
}
