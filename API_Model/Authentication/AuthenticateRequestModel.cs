using System.ComponentModel.DataAnnotations;

namespace API_Model
{
    public class AuthenticateRequestModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}