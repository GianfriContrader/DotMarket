namespace DotMarket.Models
{
    public class Address
    {
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;        
        public string Province { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;

        //many to many con Profile
        public List<Profile> Profiles { get; set; }


    }
}
