using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroServiceShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProductInfo { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } = null!;
        [BsonIgnore]
        public Product Product { get; set; } = null!;
    }
}
