using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotMarket.Models
{

    public class Order
    {

        private ILazyLoader _lazyLoader;
        private Profile? _profile;
        private Payment? _payment;
        private IEnumerable<Kart> _karts = new List<Kart>();
        public Order() { }

        private Order(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  long Id { get; set; }
        public string CodeOrd { get; set; }
        public float TotalPrice { get; set; }
        public bool FastDelivery { get; set; }
        public bool ProcessedPayment { get; set; }
        public  bool Delivered { get; set; }
        public long PaymentId { get; set; }


        public Profile? Profile
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

        public Payment? Payment
        {
            get
            {
                return _lazyLoader.Load(this, ref _payment);
            }

            set
            {
                _payment = value;
            }
        }

        public IEnumerable<Kart> Karts
        {
            get
            {
                return _lazyLoader.Load(this, ref _karts);
            }

            set
            {
                _karts = value;
            }
        }
    }
}
