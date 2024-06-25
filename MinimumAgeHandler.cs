using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationClaims
{

    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(
                // DateOfBirth should be there to achec age
                // Ref https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-8.0#apply-policies-to-mvc-controllers
                c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com");

            if (dateOfBirthClaim is null)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
