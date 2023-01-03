using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{
    /*
     * Entity InvoicePDF: defines the invoice of the payment
     */
    public class InvoicePDF
    {
        private ILazyLoader LazyLoader;
        private Payment _payment;

        //constructor with no arguments
        public InvoicePDF()
        {
        }

        //constructor with parameter _lazyLoader
        private InvoicePDF(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public decimal LoadingStatus { get; set; }

        public long InvoiceCode { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte DataPDF { get; set; }

        public byte DataExcel { get; set; }

        public long PaymentId { get; set; }
        //
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
    }
}
