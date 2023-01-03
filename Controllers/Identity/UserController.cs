using DotMarket.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotMarket.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private IPasswordHasher<User> _passwordHasher;

        public UserController(UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(_userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            if(ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = request.Username,
                    Email = request.Email,
                };

                IdentityResult result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return Ok("Registrazione avvenuta con successo.");
                }
                else
                {
                    Errors(result);
                }
            }

            return BadRequest("Qualcosa è andato storto.");
        }

        private void Errors(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
