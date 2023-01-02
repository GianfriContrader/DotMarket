using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{
    /*
     * Entity Payment: defines the payment
     */

    public class Payment
    {
        private ILazyLoader _LazyLoader;
        private DataPayment? _dataPayment;
        private Order? _order;
        private Address? _address;

        //constructor with no arguments
        public Payment()
        {

        }

        //constructor with parameter _lazyLoader
        public Payment(ILazyLoader _lazyLoader)
        {
            _LazyLoader = _lazyLoader;
        }

        public long Id { get; set; }
        public DataPayment? DataPayment
        {
            get
            {
                return _LazyLoader.Load(this, ref _dataPayment);
            }

            set
            {
                _dataPayment = value;
            }
        }
        public Order? Order
        {
            get
            {
                return _LazyLoader.Load(this, ref _order);
            }

            set
            {
                _order = value;
            }
        }
        
        public long ResponsePay { get; set; }
        
        public Address? Address
        {
            get
            {
                return _LazyLoader.Load(this, ref _address);
            }

            set
            {
                _address = value;
            }
        }
        
    }
}
