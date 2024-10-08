﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroServiceShop.Catalog.WebAPI.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;
        [BsonIgnore]
        public Category Category { get; set; } = null!;
    }
}
