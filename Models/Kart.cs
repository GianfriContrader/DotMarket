using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotMarket.Models
{

    public class Kart
    {
        public long Id { get; set; }
        
        public float TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual IEnumerable<ProductKart> ProductsKart { get; set; } = new List<ProductKart>();

        public virtual Order Order { get; set; }
        
    }
}
