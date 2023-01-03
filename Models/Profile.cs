using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotMarket.Models
{
    public class Profile
    {
        private ILazyLoader _lazyLoader;
        public Profile() { }

        public long Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FiscalCode { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; } 

        public DateTime AtCreated { get; set; }

        public bool IsSubscribed { get; set; } = false;
        // one to one con User
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; }

        // many to many con address
        public IEnumerable<Address> Addresses { get; set; } 

        //one to many
        public IEnumerable<DataPayment> DataPayments { get; set; }

        public IEnumerable<Order> Orders { get; set; }


        //TODO: Inserire el altre relazioni.
    }
}
