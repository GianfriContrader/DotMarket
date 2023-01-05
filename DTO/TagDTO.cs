namespace DotMarket.DTO
{
    /*
     * TagDTO 
     */

    public class TagDTO
    {
        public string Name { get; set; }
    }

    public class InsertTagDTO : TagDTO
    {
    }

    public class EditTagDTO : TagDTO 
    { 
        public long Id { get; set; }
    }
}
