namespace DotMarket.Models
{
    public class ProductKart
    {
        public long Id { get; set; }

        public int QtyToBuy { get; set; }

        public virtual Product Product { get; set; } 

        public virtual Kart Kart { get; set; }
    }
}
