using System;
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
        [BsonElement("LawnId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string LawnId { get; set; }
        [BsonElement("LawnSectionId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LawnSectionId { get; set; }
        [BsonElement("Amount")]
        [BsonRequired]
        public decimal Amount { get; set; }
        [BsonElement("UnitOfMeasure")]
        [BsonRequired]
        public string UnitOfMeasure { get; set; }
        [BsonElement("ApplicationDate")]
        [BsonRequired]
        public DateTime ApplicationDate { get; set; }
    }
}