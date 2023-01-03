namespace DotMarket.Models
{
    public class DataPayment
    { 
        public long Id { get; set; }
        public string Circuit { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string SecurityCode { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public virtual Profile Profile { get; set; } = new Profile();
        public virtual IEnumerable<Payment> Payments { get; set; } = new List<Payment>();

    }
}
