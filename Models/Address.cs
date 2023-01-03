using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
    public class Address
    {
        private ILazyLoader LazyLoader;
        private IEnumerable<Profile> _profiles = new List<Profile>();
        private Payment payment;
        public Address() { }

        private Address(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public string ZipCode { get; set; }
        public string City { get; set; }      
        public string Province { get; set; } 
        public string Region { get; set; } 
        public Payment Payment {
            get
            {
                return LazyLoader.Load(this, ref _payment);
            }

            set
            {
                _payment = value;
            }
        } 

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
