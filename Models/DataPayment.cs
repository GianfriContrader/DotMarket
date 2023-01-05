using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{
    /*
     * Entity DataPayment: defines the data of credit card
     */
    public class DataPayment
    {
        private ILazyLoader LazyLoader;
        private Profile _profile;
        private IEnumerable<Payment> _payments = new List<Payment>();

        //constructor with no arguments
        public DataPayment()
        {
        }

        //constructor with parameter _lazyLoader
        private DataPayment(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public string Circuit { get; set; }

        public string Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        // relazione uno-a-molti
        public long ProfileId { get; set; }
        //
        public Profile Profile
        {
            get
            {
                return LazyLoader.Load(this, ref _profile);
            }

            set
            {
                _profile = value;
            }
        }

        public IEnumerable<Payment> Payments
        {
            get
            {
                return LazyLoader.Load(this, ref _payments);
            }

            set
            {
                _payments = value;
            }
        }
    }
}
