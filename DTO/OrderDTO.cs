namespace DotMarket.DTO
{
    /*
     * OrderDTO: DTO dell'entity Order
     */
    public class OrderDTO
    {
        public string CodeOrd { get; set; }


        IEnumerable<DetailProductDTO> ListDetailProductDTO;
    }
}
