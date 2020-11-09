using System;
using System.Collections.Generic;

namespace API_Tutorial.Models
{
    public partial class UserLogin
    {
        public int PkUid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
