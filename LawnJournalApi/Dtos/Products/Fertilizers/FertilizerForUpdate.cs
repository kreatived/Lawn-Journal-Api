using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawnJournalApi.Dtos.Products.Fertilizers
{
    public class FertilizerForUpdate
    {
        [Required]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }
        [Required]
        public string ProductType { get; }
        [Required]
        public int CoverageArea { get; }
        [Required]
        public string CoverageAreaUnitOfMeasure { get; }
        [Required]
        public int PackageSize { get; }
        [Required]
        public string PackageSizeUnitOfMeasure { get; }
        [Required]
        public List<string> CompatibleGrassTypes { get; }
        [Required]
        public string ConditionOfLawn { get; }
        public List<string> Features { get; }
        [Required]
        public int LongevityInWeeks { get; }
        [Required]
        public int PercentNitrogen { get; }
        [Required]
        public int PercentPhosphorous { get; }
        [Required]
        public int PercentPotassium { get; }
        [Required]
        public bool IsOrganic { get; }
        [Required]
        public bool ContainsPostEmergentWeedControl { get; }
        [Required]
        public bool ContainsPreEmergentWeedControl { get; }
        [Required]
        public List<string> SeasonsOfUse { get; }
    }
}