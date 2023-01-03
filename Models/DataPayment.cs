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
        private Profile? _profile;
        private Payment? _payment;
        private InvoicePDF? _invoicePDF;

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
        public DateOnly ExpirationDate { get; set; }
       
        public int SecurityCode { get; set; }


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

        public Payment Payment
        {
            get
            {
                return LazyLoader.Load(this, ref _payment);
            }

            set
            {
                _payment = value;
            }
        }
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
