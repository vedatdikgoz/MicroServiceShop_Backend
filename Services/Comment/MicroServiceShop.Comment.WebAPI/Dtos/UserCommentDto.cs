namespace MicroServiceShop.Comment.WebAPI.Dtos
{
    public class UserCommentDto
    {
        public string Id { get; set; } = null!;
        public string NameSurname { get; set; } = null!;
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
