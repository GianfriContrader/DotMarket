﻿using Azure;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace DotMarket.Models
{
    public class Product
    {
        private ILazyLoader LazyLoader;
        private IEnumerable<Comment> _comments = new List<Comment>();
        private IEnumerable<Tag> _tags = new List<Tag>();
        private IEnumerable<Kart> _karts = new List<Kart>();
        private Image? _image;

        public Product() { }

        private Product (ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public uint Quantity { get; set; }

        public char Status { get; set; }

        public uint Stars { get; set; }
        
        public IEnumerable<Comment> Comments
        {
            get
            {
                return LazyLoader.Load(this, ref _comments);
            }

            set
            {
                _comments = value;
            }
        }

        public IEnumerable<Tag> Tags
        {
            get
            {
                return LazyLoader.Load(this, ref _tags);
            }

            set
            {
                _tags = value;
            }
        }

        public IEnumerable<Kart> Karts
        {
            get
            {
                return LazyLoader.Load(this, ref _karts);
            }

            set
            {
                _karts = value;
            }
        }

        //relazione uno-a-uno
        public long? ImageId { get; set; }
        //
        public Image Image
        {
            get
            {
                return LazyLoader.Load(this, ref _image);
            }

            set
            {
                _image = value;
            }
        }
    }

}
