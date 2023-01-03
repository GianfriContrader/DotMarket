namespace DotMarket.Models
{

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; } 
        public string Description { get; set; } = string.Empty;
        public uint Quantity { get; set; }
        public bool Status { get; set; } 
        public uint Stars { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public virtual IEnumerable<Tag> Tags { get; set; } = new List<Tag>();

        public virtual IEnumerable<ProductKart> ProductsKart { get; set; } = new List<ProductKart>();

        public long ImageId { get; set; }
        public virtual Image Image { get; set; } 

    }

}
