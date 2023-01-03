using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
        public class Image
        {
            private ILazyLoader LazyLoader;
            private Product? _product;

            public Image() { }

            private Image(ILazyLoader lazyLoader)
            {
                LazyLoader = lazyLoader;
            }

            public long Id { get; set; }

            public string  PathImage { get; set; }

            public string Data { get; set; }

            public Product? Product
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