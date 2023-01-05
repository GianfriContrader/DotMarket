namespace DotMarket.DTO
{
    /*
     * TagDTO 
     */

    public class TagDTO
    {

    }
    public class ReadTagDTO : TagDTO
    {
        public long Id { get; set; }
    }

    public class InsertTagDTO : TagDTO
    {
        public string Name { get; set; }
    }

    public class EditTagDTO : TagDTO 
    { 
        public long Id { get; set; }
    }
}
