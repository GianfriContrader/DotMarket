namespace DotMarket.DTO
{
    /*
     * PaymentDTO 
     */

    public class PaymentDTO
    {
        
    }
    public class InsertPaymentDTO : PaymentDTO
    {
        public long DataPaymentId { get; set; }
        public long OrderId { get; set; }
        public long AddressId { get; set; }
    }

}
