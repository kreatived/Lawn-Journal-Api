using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Models.Products
{
    public class Fertilizer: Product
    {
        [BsonElement("CoverageArea")]
        [BsonRequired]
        public int CoverageArea { get; set; }
        [BsonElement("CoverageAreaUnitOfMeasure")]
        [BsonRequired]
        public string CoverageAreaUnitOfMeasure { get; set; }
        [BsonElement("PackageSize")]
        [BsonRequired]
        public int PackageSize { get; set; }
        [BsonElement("PackageSizeUnitOfMeasure")]
        [BsonRequired]
        public string PackageSizeUnitOfMeasure { get; set; }
        [BsonElement("CompatibleGrassTypes")]
        [BsonRequired]
        public List<string> CompatibleGrassTypes { get; set; }
        [BsonElement("ConditionOfLawn")]
        [BsonRequired]
        public string ConditionOfLawn { get; set; }
        [BsonElement("ConditionOfLawn")]
        public List<string> Features { get; set; }
        [BsonElement("LongevityInWeeks")]
        [BsonRequired]
        public int LongevityInWeeks { get; set; }
        [BsonElement("PercentNitrogen")]
        [BsonRequired]
        public int PercentNitrogen { get; set; }
        [BsonElement("PercentPhosphorous")]
        [BsonRequired]
        public int PercentPhosphorous { get; set; }
        [BsonElement("PercentPotassium")]
        [BsonRequired]
        public int PercentPotassium { get; set; }
        [BsonElement("IsOrganic")]
        [BsonRequired]
        public bool IsOrganic { get; set; }
        [BsonElement("ContainsPostEmergentWeedControl")]
        [BsonRequired]
        public bool ContainsPostEmergentWeedControl { get; set; }
        [BsonElement("ContainsPreEmergentWeedControl")]
        [BsonRequired]
        public bool ContainsPreEmergentWeedControl { get; set; }
        [BsonElement("SeasonsOfUse")]
        [BsonRequired]
        public List<string> SeasonsOfUse { get; set; }

        public Fertilizer()
        {
            CompatibleGrassTypes = new List<string>();
            Features = new List<string>();
            SeasonsOfUse = new List<string>();
        }
    }
}