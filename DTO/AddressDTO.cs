namespace DotMarket.DTO
{
    /*
     * AddressDTO
     */
    public class AddressDTO
    {
        
    }

    public class ReadAddressDTO : AddressDTO
    {
        public long Id { get; set; }
    }

    public class InsertAddressDTO : AddressDTO 
    {
        public string City { get; set; }
        public string Province { get; set; }
        public string Residence { get; set; }
        public string Region { get; set; }
    }

    public class EditAddressDTO : InsertAddressDTO
    {
        public long Id { get; set; }
    }
}
