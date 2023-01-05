namespace DotMarket.DTO
{
    /*
     * TagDTO: DTO dell'entity Tag
     */

    public class TagDTO
    {
        public string Name { get; set; }
    }
    public class InsertTagDTO : TagDTO
    {
        
    }

    public class EditTagDTO : InsertTagDTO
    { 
        public long Id { get; set; }
    }
}
