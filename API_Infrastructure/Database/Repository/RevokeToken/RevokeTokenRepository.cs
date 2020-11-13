using System;
using System.Linq;

namespace API_Infrastructure
{
    public class RevokeTokenRepository : IRevokeTokenRepository
    {
        private readonly API_TESTContext _apiTestContext;
        public RevokeTokenRepository()
        {
            _apiTestContext=new API_TESTContext();
        }
        public void RevokeToken(string token, string ipAddress)
        {
            var entity = _apiTestContext.RefreshToken.FirstOrDefault(f => f.Token == token);
            if (entity == null) return;
            entity.Revoked = DateTime.UtcNow;
            entity.RevokedByIp = ipAddress;
            entity.IsActive = false;
            entity.IsExpired = false;
            _apiTestContext.SaveChanges();
        }
    }
}