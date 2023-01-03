namespace DotMarket.Models
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}