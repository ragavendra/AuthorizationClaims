using AuthorizationClaims.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthorizationClaims.Authorization
{
    public class TodoItemAdministratorsAuthorizationHandler
                : AuthorizationHandler<OperationAuthorizationRequirement, TodoItemDTO>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   TodoItemDTO resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if(context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
