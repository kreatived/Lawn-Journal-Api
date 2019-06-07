using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models
{
    public class ProductApplication: ModelBase
    {
        [BsonElement("ProductId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string ProductId { get; set; }
        [BsonElement("AmountLb")]
        [BsonRequired]
        public int AmountLb { get; set; }
    }
}