using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models
{
    public class LawnSection: ModelBase
    {
        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("Description")]
        [BsonRequired]
        public string Description { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}