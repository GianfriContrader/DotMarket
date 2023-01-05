namespace DotMarket.DTO
{
    /*
     * InvoicePDFDTO
     */
    public class InvoicePDFDTO
    {

    }
    public class ReadInvoicePDFDTO : InvoicePDFDTO
    {
        public long Id { get; set; }
    }

    public class InsertInvoicePDFDTO : InvoicePDFDTO
    {
        public decimal LoadingStatus { get; set; }
        public long InvoiceCode { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte DataPDF { get; set; }
        public byte DataExcel { get; set; }
        public long PaymentId { get; set; }
    }
}
