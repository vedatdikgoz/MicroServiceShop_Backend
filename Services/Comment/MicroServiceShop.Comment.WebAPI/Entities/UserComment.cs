using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroServiceShop.Comment.WebAPI.Entities
{
    public class UserComment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string NameSurname { get; set; } = null!;
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? CommentDetail { get; set; }
        public int Rating { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } = null!;
    }
}
