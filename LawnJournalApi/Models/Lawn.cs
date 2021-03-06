using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models
{
    public class Lawn: ModelBase
    {
        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("Description")]
        [BsonRequired]
        public string Description { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
        public List<LawnSection> Sections { get; set; }

        public Lawn()
        {
            Sections = new List<LawnSection>();
        }
    }
}