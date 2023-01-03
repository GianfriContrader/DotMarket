namespace DotMarket.Models
{
    public class Order
    {
        public  long Id { get; set; }
        public string CodeOrd { get; set; } = string.Empty; 
        public bool IsFastDelivery { get; set; }
        public  bool IsDelivered { get; set; }
        public virtual Profile Profile { get; set; }

        public long PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public long KartId { get; set; }
        public virtual Kart Kart { get; set; }
    }
}
