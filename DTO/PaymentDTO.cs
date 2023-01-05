namespace DotMarket.DTO
{
    /*
     * PaymentDTO: DTO dell'entity Payment
     */

    public class PaymentDTO
    {
        public long DataPaymentId { get; set; }
        public long OrderId { get; set; }
        public long AddressId { get; set; }
    }
    public class InsertPaymentDTO : PaymentDTO
    {
        
    }

}
