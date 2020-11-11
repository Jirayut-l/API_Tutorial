using System.Collections.Generic;
using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public void CreateRefreshToken(RefreshTokenModel model)
        {
            _refreshTokenRepository.CreateRefreshToken(model);
        }

        public RefreshTokenModel GetRefreshTokenByToken(string token)
        {
            return _refreshTokenRepository.GetRefreshTokenByToken(token);
        }

        public IEnumerable<RefreshTokenModel> GetAll()
        {
            return _refreshTokenRepository.GetAll();
        }
    }
}