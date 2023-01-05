namespace DotMarket.DTO
{
    public class CommentDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsLike { get; set; }
    }
   
    public class InsertCommentDTO : CommentDTO
    {

        public long ProfileId { get; set; }

        public long ProductId { get; set; }
    }

    public class EditCommentDTO : CommentDTO
    {
        public long Id { get; set; }

        public int ProductId { get; set; }
    }
}
