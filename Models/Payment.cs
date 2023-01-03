using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotMarket.Models
{
    /*
     * Entity Payment: defines the payment
     */

    public class Payment
    {
        private DataPayment _dataPayment;
        private Order _order;
        private Address _address;

        //constructor with no arguments
        public Payment()
        {

        }

        //constructor with parameter _lazyLoader
       
        public long Id { get; set; }

        public long ResponsePay { get; set; }

        public long AddressId { get; set; }

        public long OrderID { get; set; }

        public DataPayment DataPayment
        {
            get;set;
        }

        public Order Order
        {
            get;set;
        }
        
        public Address Address
        {
            get;set;
        }

    }
}

