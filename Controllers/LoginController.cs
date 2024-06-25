using AuthorizationClaims.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationClaims.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ApplicationDbContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> LoginAsync(Params params_)
        {
            var resp = CreatedAtAction(nameof(LoginAsync), new { id = params_.Region }, new { message = $"Started loading for {params_.Region} ." });

            /*
          [HttpPost]
        public async Task<ActionResult> Load(Params params_)
        {
            var resp = CreatedAtAction(nameof(GetStopItem), new { id = params_.Region }, new { message = $"Started loading for {params_.Region} ." });

            */
            return resp;
        }

    }
}
