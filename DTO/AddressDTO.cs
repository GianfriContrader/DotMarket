namespace DotMarket.DTO
{
    /*
     * AddressDTO: DTO dell'entity Address
     */
    public class AddressDTO
    {
        public string City { get; set; }
        public string Province { get; set; }
        public string Residence { get; set; }
        public string Region { get; set; }
    }

    public class InsertAddressDTO : AddressDTO 
    {
       
    }

    public class EditAddressDTO : AddressDTO
    {
        public long Id { get; set; }
    }
}
