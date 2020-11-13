using System.Threading.Tasks;
using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class RevokeTokenService : IRevokeTokenService
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRevokeTokenRepository _revokeTokenRepository;

        public RevokeTokenService(IRefreshTokenService refreshTokenService, IRevokeTokenRepository revokeTokenRepository)
        {
            _refreshTokenService = refreshTokenService;
            _revokeTokenRepository = revokeTokenRepository;
        }

        public Task<Result> RevokeToken(string token, string ipAddress)
        {
            var checkRefreshToken = _refreshTokenService.GetRefreshTokenByToken(token);
            if (checkRefreshToken.Revoked != null)
                return Task.FromResult(ResultMessage.Error(Constants.CannotRevokeToken));
            if (string.IsNullOrEmpty(checkRefreshToken.Token) || !checkRefreshToken.IsActive)
                return Task.FromResult(ResultMessage.Error(Constants.CannotFoundToken));
            _revokeTokenRepository.RevokeToken(token, ipAddress);
            return Task.FromResult(ResultMessage.Success(Constants.SuccessRevokeToken));
        }
    }
}