﻿using System.ComponentModel.DataAnnotations;

namespace API_Model
{
    public class UserLoginModel
    {
        public int PkUid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? FkEmpId { get; set; }
    }
}