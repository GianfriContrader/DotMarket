using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{

    public class Comment
    {

        private ILazyLoader LazyLoader;
        private Profile _profile;
        private Product _product;

        public Comment() { }

        private Comment(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsLike { get; set; }

        public long ProfileId { get; set; }
        //
        public Profile Profile
        {
            get
            {
                return LazyLoader.Load(this, ref _profile);
            }

            set
            {
                _profile = value;
            }
        }

        public long ProductId { get; set; }
        //
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
