using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawnJournalApi.Dtos.Products.Fertilizers
{
    public class Fertilizer: Product
    {
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

        public Fertilizer(Models.Products.Fertilizer fertilizer): base(fertilizer.Id, fertilizer.Name, fertilizer.Description, fertilizer.ImageUrl, fertilizer.ProductType)
        {
            CoverageArea = fertilizer.CoverageArea;
            CoverageAreaUnitOfMeasure = fertilizer.CoverageAreaUnitOfMeasure;
            PackageSize = fertilizer.PackageSize;
            PackageSizeUnitOfMeasure = fertilizer.PackageSizeUnitOfMeasure;
            CompatibleGrassTypes = fertilizer.CompatibleGrassTypes;
            ConditionOfLawn = fertilizer.ConditionOfLawn;
            Features = fertilizer.Features;
            LongevityInWeeks = fertilizer.LongevityInWeeks;
            PercentNitrogen = fertilizer.PercentNitrogen;
            PercentPhosphorous = fertilizer.PercentPhosphorous;
            PercentPotassium = fertilizer.PercentPotassium;
            IsOrganic = fertilizer.IsOrganic;
            ContainsPostEmergentWeedControl = fertilizer.ContainsPostEmergentWeedControl;
            ContainsPreEmergentWeedControl = fertilizer.ContainsPreEmergentWeedControl;
            SeasonsOfUse = fertilizer.SeasonsOfUse;
        }
    }
}