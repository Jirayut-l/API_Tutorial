using System.Text.Json.Serialization;

namespace API_Model
{
    public class AuthenticateResponseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponseModel(EmployeeModel emp, string jwtToken, string refreshToken,string role)
        {
            Name = emp.Name;
            LastName = emp.LastName;
            Position = emp.Position;
            Department = emp.Department;
            Email = emp.Email;
            Role = role;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}