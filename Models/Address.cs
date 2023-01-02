using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
    public class Address
    {
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;        
        public string Province { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;  
        public Payment Payment { get; set; } = new Payment();
        public long PaymentId { get; set; }

        //many to many con Profile
        public List<Profile> Profiles { get; set; } = new List<Profile>();


    }
}
