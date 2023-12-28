using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Clean.Architecture.Application.Interfaces.Configuration;

namespace Clean.Architecture.Middlewares
{
    public class AuthenticationMiddlewareHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly IEnvironmentSystem _environmentSystem;

        public AuthenticationMiddlewareHandler(IEnvironmentSystem environmentSystem)
        {
            _environmentSystem = environmentSystem;
        }

        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            var claimSystem = context.User.FindFirst("system");
            var claimUserId = context.User.FindFirst("userid");
            var claimUserName = context.User.FindFirst("username");
            var claimMachine = context.User.FindFirst("machine");
            var claimMacAddress = context.User.FindFirst("macaddress");

            if (claimSystem != null && claimUserId != null)
                _environmentSystem.UpdateEnvironmnetSystem(                    
                    claimUserId != null ? int.Parse(claimUserId.Value) : null,
                    claimUserName?.Value                    
                );

            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
