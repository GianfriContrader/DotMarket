using DotMarket.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserManager<User> _userManagare;
        private SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userMgr, SignInManager<User> signIngMgr)
        {

            _userManagare = userMgr;
            _signInManager = signIngMgr;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                User appUser = await _userManagare.FindByEmailAsync(loginDTO.Email);
                if (appUser != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginDTO.Password, false/*loginDTO.Remember utilizzo per non dover fae più login*/, false);

                    if (result.Succeeded)
                        return Ok("Utente loggato");
                }
                return NotFound("Email o Password errati!");
            }
            return BadRequest("Qualcosa è andato storto.");

        }

        [HttpGet("out")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("LOG OUT");
        }
    }
}
