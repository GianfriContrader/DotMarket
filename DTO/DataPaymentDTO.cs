namespace DotMarket.DTO
{
    /*
     * DataPaymentDTO
     */ 
    public class DataPaymentDTO
    {
        public string Circuit { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }

    public class InsertDataPaymentDTO : DataPaymentDTO
    {
        public long ProfileId { get; set; }
    }

    public class EditDataPaymentDTO : DataPaymentDTO 
    { 
        public long Id { get; set; }
    }


}
