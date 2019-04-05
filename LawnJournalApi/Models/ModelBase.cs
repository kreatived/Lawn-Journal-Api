using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models
{
    public abstract class ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
    }
}