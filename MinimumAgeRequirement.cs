using Microsoft.AspNetCore.Authorization;

namespace WebAll
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge) =>
            MinimumAge = minimumAge;

        public int MinimumAge { get; }
    }
}
