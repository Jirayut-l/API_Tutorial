using System.Collections.Generic;
using API_Model;

namespace API_Infrastructure
{
    public interface IRefreshTokenRepository
    {
        void CreateRefreshToken(RefreshTokenModel model);
        RefreshTokenModel GetRefreshTokenByToken(string token);
        IEnumerable<RefreshTokenModel> GetAll();
    }
}