using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models.Products
{
    public abstract class Product: ModelBase
    {
        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("Description")]
        [BsonRequired]
        public string Description { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("ProductType")]
        public string ProductType { get; set; }
    }
}