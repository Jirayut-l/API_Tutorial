using System;
using System.Collections.Generic;

namespace API_Infrastructure
{
    public partial class RefreshToken
    {
        public int PkRfTk { get; set; }
        public string Token { get; set; }
        public bool? IsExpired { get; set; }
        public DateTime? Created { get; set; }
        public string CreateByIp { get; set; }
        public string CreateByUser { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string RevokedByUser { get; set; }
        public string ReplacedByToken { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Expires { get; set; }
    }
}
