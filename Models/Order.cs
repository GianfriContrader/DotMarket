using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotMarket.Models
{

    public class Order
    {
        
        private Profile _profile;
        //private Payment _payment;
        private IEnumerable<Kart> _karts = new List<Kart>();

        public Order() { }

        
        public long PaymentId { get; set; } 
        public  long Id { get; set; }

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
            get;set;
        }

        public Payment Payment { get; set; }

        public IEnumerable<Kart> Karts
        {
            get;set;
        }
    }
}
