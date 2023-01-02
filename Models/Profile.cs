namespace DotMarket.Models
{
    public class Profile
    {
        public long Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FiscalCode { get; set; } = string.Empty;

        public DateTime Birthday { get; set; } 

        public DateTime AtCreated { get; set; } = DateTime.Now;

        public bool IsSubscribed { get; set; } = false;
        // one to one con User
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; } = new User();


        // many to many con address
        public List<Address> Addresses { get; set; } = new List<Address>();


        //TODO: Inserire el altre relazioni.
    }
}
