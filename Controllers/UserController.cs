using DotMarket.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotMarket.Controllers
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
            if (ModelState.IsValid)
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

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(string id, string email, string password)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "L'email non può essere nulla");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "La password non può essere vuoto");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return Ok("Utente modificato");
                    else
                        Errors(result);

                }
            }

            return NotFound("Utente non trovato");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return Ok("Utente eliminato");
                else
                    Errors(result);
            }
            return NotFound("Id utente non trovato.");
        }


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
