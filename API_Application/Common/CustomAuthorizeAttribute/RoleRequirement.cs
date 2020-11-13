using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API_Application
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> Role { get; }

        public RoleRequirement(IEnumerable<string> role)
        {
            Role = role;
        }
    }
}