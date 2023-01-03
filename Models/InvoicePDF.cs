using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{
    /*
     * Entity InvoicePDF: defines the invoice of the payment
     */
    public class InvoicePDF
    {
        public long Id { get; set; }

        public float LoadingStatus { get; set; }
        public long InvoiceCode { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte DataPDF { get; set; }
        public byte DataExcel { get; set; }
        public virtual Payment Payment { get; set; } = new Payment();
       
    }
}
