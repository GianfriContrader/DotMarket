namespace DotMarket.DTO
{
    /*
     * ImageDTO: DTO dell'entity Image
     */
    public class ImageDTO
    {

    }

    public class UploadImageDTO : ImageDTO
    {
        public byte[] Data { get; set; }
        public int ProductId { get; set; }
    }

    public class ImageUpdateDTO : UploadImageDTO
    {
        public int Id { get; set; }
    }
}
