using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{
    /*
     * Entity DataPayment: defines the data of credit card
     */
    public class DataPayment
    {
        private ILazyLoader _LazyLoader;
        private Profile? _profile;

        //constructor with no arguments
        public DataPayment()
        {

        }

        //constructor with parameter _lazyLoader
        private DataPayment(ILazyLoader _lazyLoader)
        {
            _LazyLoader = _lazyLoader;
        }

        public long Id { get; set; }
        public string Circuit { get; set; }
        public string Number { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int SecurityCode { get; set; }

        public Payment Payment { get; set; } = new Payment();
        public long PaymentId { get; set; }

        public InvoicePDF invoicePDF { get; set; } = new InvoicePDF();
        public long InvoicePDFId { get; set; }

        public Profile Profile
        {
            get
            {
                return _LazyLoader.Load(this, ref _profile);
            }

            set
            {
                _profile = value;
            }
        }
    }
}
