using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace DotMarket.Models
{

    public class Comment
    {

        private ILazyLoader _lazyLoader;
        private Profile _profile;
        private Product _product;

        public Comment() { }

        private Comment(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsLike { get; set; }



        public Profile Profile
        {
            get
            {
                return _lazyLoader.Load(this, ref _profile);
            }

            set
            {
                _profile = value;
            }
        }

        public Product Product
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
