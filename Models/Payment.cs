using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotMarket.Models
{
    /*
     * Entity Payment: defines the payment
     */

    public class Payment
    {
        private ILazyLoader LazyLoader;
        private DataPayment _dataPayment;
        //private Order _order;
        private Address _address;
        private InvoicePDF _invoicePDF;

        //constructor with no arguments
        public Payment()
        {
        }

        //constructor with parameter _lazyLoader
        private Payment(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public long ResponsePay { get; set; }

        public long DataPaymentId { get; set; }
        //
        public DataPayment DataPayment
        {
            get
            {
                return LazyLoader.Load(this, ref _dataPayment);
            }

            set
            {
                _dataPayment = value;
            }
        }

        public long? OrderId { get; set; }
        //
        public Order Order { get; set; }
        
        public long AddressId { get; set; }
        //
        public Address Address
        {
            get
            {
                return LazyLoader.Load(this, ref _address);
            }

            set
            {
                _address = value;
            }
        }

        public long InvoicePDFId { get; set; }
        //
        public InvoicePDF InvoicePDF
        {
            get
            {
                return LazyLoader.Load(this, ref _invoicePDF);
            }

            set
            {
                _invoicePDF = value;
            }
        }
    }
}

