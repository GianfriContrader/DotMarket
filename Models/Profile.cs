using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Xml.Linq;

namespace DotMarket.Models
{
    public class Profile
    {
        public Profile() 
        {
            this.AtCreated = DateTime.Now;
        }

        public long Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FiscalCode { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; } 

        public DateTime AtCreated { get; set; }

        public bool IsSubscribed { get; set; }

        // one to one con User
        public virtual User User { get; set; }

        public virtual IEnumerable<Kart> Karts { get; set; } = new List<Kart>();
        public virtual IEnumerable<Address> Addresses { get; set; } = new List<Address>();

        public virtual IEnumerable<DataPayment> DataPayments { get; set; } = new List<DataPayment>();

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

        public virtual IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

    }
}
