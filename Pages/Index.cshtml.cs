using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationClaims.Pages
{
    #region snippet
    [Authorize(Policy = "EmployeeOnly")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
    #endregion
}
