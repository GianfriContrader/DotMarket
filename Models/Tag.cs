using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotMarket.Models
{
    /*
    * Entity Payment: defines the tag relative of the product
    */
    public class Tag
    {

        private ILazyLoader LazyLoader;
        private IEnumerable<Product> _products = new List<Product>();

        //constructor with no argument
        public Tag() { }

        //constructor with parameter _lazyLoader
        private Tag(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Tag(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Product> Products
        {
            get
            {
                return LazyLoader.Load(this, ref _products);
            }

            set
            {
                _products = value;
            }
        }
    
    }
}
