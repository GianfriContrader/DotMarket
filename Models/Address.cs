using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
    public class Address
    {
        private ILazyLoader LazyLoader;
        private IEnumerable<Profile> _profiles = new List<Profile>();
        public Address() { }

        private Address(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;        
        public string Province { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;  
        public Payment Payment { get; set; } = new Payment();
        public long PaymentId { get; set; }

        //many to many con Profile
        public IEnumerable<Profile> Profiles
        {
            get
            {
                return LazyLoader.Load(this, ref _profiles);
            }

            set
            {
                _profiles = value;
            }
        }
       

    }
}
