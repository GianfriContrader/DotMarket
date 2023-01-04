using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotMarket.Models
{

    public class Order
    {
        private ILazyLoader LazyLoader;
        private Profile _profile;
        //private Payment _payment;
        private Kart _kart;

        public Order() { }

        private Order(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }

        public string CodeOrd { get; set; }

        public float TotalPrice { get; set; }

        public bool FastDelivery { get; set; }

        public bool ProcessedPayment { get; set; }

        public  bool Delivered { get; set; }

        //relazione molti-a-uno, obbligatoria
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

        //public long ForeignPayment;
        //
        public Payment Payment { get; set; }

        public Kart Kart { get; set; }
    }
}
