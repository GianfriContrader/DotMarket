namespace DotMarket.DTO
{
    /*
     * ProductDTO
     */
    public class ProductDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public char Status { get; set; }
        public uint Stars { get; set; }
    }
    public class InsertProductDTO : ProductDTO
    {
        public uint Quantity { get; set; }
    }

    public class EditProductDTO : InsertProductDTO 
    { 
        public long Id { get; set; }
    }
}
