using System;

namespace API_Model
{
    public class RefreshTokenModel
    {
        public int PkRfTk { get; set; }
        public string Token { get; set; }
        public DateTime? Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public string CreateByUser { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string RevokedByUser { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}