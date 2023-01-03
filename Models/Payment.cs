namespace DotMarket.Models
{
    public class Payment
    {
        public long Id { get; set; }

        public long ResponsePay { get; set; }

        public long AddressId { get; set; }

        public virtual Address Address { get; set; } = new Address();

        public virtual Order Order { get; set; } = new Order();

        public virtual DataPayment DataPayment { get; set; }

        public long InvoiceId { get; set; } 

        public virtual InvoicePDF InvoicePDF { get; set; } = new InvoicePDF();

    }
}

