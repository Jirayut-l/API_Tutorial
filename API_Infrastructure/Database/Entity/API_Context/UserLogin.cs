using System;
using System.Collections.Generic;

namespace API_Infrastructure
{
    public partial class UserLogin
    {
        public int PkUid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? FkEmpId { get; set; }
    }
}
