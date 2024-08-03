using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroServiceShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } = null!;
        [BsonIgnore]
        public Product Product { get; set; } = null!;
    }
}
