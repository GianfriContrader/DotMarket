
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleMng, UserManager<User> userMng)
        {
            _roleManager = roleMng;
            _userManager = userMng;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_roleManager.Roles);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                    return Ok("Ruolo inserito correttamente");

                Errors(result);
            }

            return BadRequest("Qualcosa è andato storto.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return Ok("Eliminazione avvenuta con successo.");

                Errors(result);
            }

            return NotFound("Ruolo non trovato.");
        }

        [HttpGet("showUsersForRole")]
        public async Task<IActionResult> ShowUsersForRoleId(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<User> members = new List<User>();
            List<User> nonMembers = new List<User>();
            foreach (User user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return Ok(new RoleEditDTO
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }
        [HttpPut("updateRole")]
        public async Task<IActionResult> Update(RoleModificationDTO model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                return Ok("Avvenuto con successo.");
            }

            return BadRequest("Qualcosa è andato storto");
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
