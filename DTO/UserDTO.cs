using System.ComponentModel.DataAnnotations;

namespace DotMarket.DTO
{
    public class LoginDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;

    }
}
