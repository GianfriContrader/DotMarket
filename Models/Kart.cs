using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotMarket.Models
{

    public class Kart
    {
        private ILazyLoader LazyLoader;

        private Order? _order;
        private Product? _product;


        public Kart( ) {  }

        public Kart(ILazyLoader lazyLoader) {

            LazyLoader = lazyLoader;
        
        }

       public long Id { get; set; }


        public int Quantity { get; set; }=1;

        public decimal ProductPrice { get; set; }

        public DateTime Date { get; set; }

        public uint DiscountApplied { get; set; } = 0;


        public Order Order
        {
            get
            {
                return LazyLoader.Load(this, ref _order);
            }

            set
            {
                _order = value;
            }
        }

        public Product Product
        {
            get
            {
                return LazyLoader.Load(this, ref _product);
            }

            set
            {
                _product = value;
            }
        }


    }
}
