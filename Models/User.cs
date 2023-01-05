namespace DotMarket.Models
{
    public class User : IdentityUser
    { 
        public long ProfileId { get; set; }
        
        public Profile Profile { get; set; }
    }
}