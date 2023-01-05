namespace DotMarket.DTO
{
    /*
     * KartDTO: DTO dell'entity Kart
     */
    public class KartDTO
    {
        public string CodeOrd { get; set; }

        IEnumerable<DetailProductDTO> ListDetailProductDTO;

    }

    public class EditKartDTO 
    {

        IEnumerable<EditProductDTO> ListEditProductDTO;
    }    

    public class InsertKartDTO:EditKartDTO
        
        
    { 
    }

}
