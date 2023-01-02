using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{




   
        public class Image
        {
            private ILazyLoader _lazyLoader;
            private Product? _product;

            public Image() { }

            private Image(ILazyLoader lazyLoader)
            {
                _lazyLoader = lazyLoader;
            }

            public long Id { get; set; }

            public string  PathImage { get; set; }

            public string Data { get; set; }

            public Product? Product
            {
                get
                {
                    return _lazyLoader.Load(this, ref _product);
                }

                set
                {
                    _product = value;
                }
            }

        }
    }