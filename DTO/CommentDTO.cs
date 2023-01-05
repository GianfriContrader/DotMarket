namespace DotMarket.DTO
{
    public class CommentBaseDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsLike { get; set; }
    }

    public class InsertCommentDTO : CommentBaseDTO
    {

        public long ProfileId { get; set; }

        public long ProductId { get; set; }
    }

    public class ModifyCommentDTO : CommentBaseDTO
    {
        public long Id { get; set; }

        public int ProductId { get; set; }
    }

    public class CommentReadDTO : CommentBaseDTO
    {
        public int Id { get; set; }
    }

    public class CommentDTO : CommentReadDTO
    {
    }
}
