using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;      
        public string Province { get; set; } = string.Empty; 
        public string Region { get; set; } = string.Empty;
        public virtual IEnumerable<Profile> Profiles { get; set; } = new List<Profile>();
        public virtual Payment Payment { get; set; } = new Payment();
    }
}
