using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API_Application
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        private readonly IUserLoginService _userLoginService;

        public RoleRequirementHandler(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {

            var claimsIdentity = (ClaimsIdentity)context.User.Identity;
            var checkClamsCount = claimsIdentity.Claims.ToList();
            if (checkClamsCount.Any())
            {
                var claims = claimsIdentity.Name;
                var getRole = _userLoginService.GetUserLoginByUsername(claims);
                var findRole = requirement.Role.FirstOrDefault(w => getRole != null && w.Contains(getRole.Role));
                if (string.IsNullOrEmpty(findRole))
                {
                    context.Fail();
                }
                else
                {
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}