using System.ComponentModel.DataAnnotations;

namespace API_Model
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}