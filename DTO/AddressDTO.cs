namespace DotMarket.DTO
{
    /*
     * AddressDTO
     */
    public class AddressDTO
    {
        public string City { get; set; }
        public string Province { get; set; }
        public string Residence { get; set; }
        public string Region { get; set; }
    }

    public class ReadAddressDTO : AddressDTO
    {
        
    }

    public class InsertAddressDTO : AddressDTO 
    {
       
    }

    public class EditAddressDTO : AddressDTO
    {
        public long Id { get; set; }
    }
}
