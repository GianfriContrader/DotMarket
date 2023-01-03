namespace DotMarket.Models
{
    public class User : IdentityUser
    { 
        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; } = new Profile();
    }
}