using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotMarket.Models
{
    /*
    * Entity Payment: defines the tag relative of the product
    */
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
