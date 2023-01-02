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


        // many to many con address
        public List<Address> Addresses { get; set; } = new List<Address>();

        //todo Creare relazioni con il resto
    }
}
