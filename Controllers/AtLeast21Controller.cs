using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationClaims.Controllers
{
    [Authorize(Policy = "AtLeast21")]
    public class AtLeast21Controller : Controller
    {
        public IActionResult Index() => View();

    }
}
