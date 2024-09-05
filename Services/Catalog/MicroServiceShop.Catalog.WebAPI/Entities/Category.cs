using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroServiceShop.Catalog.WebAPI.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
