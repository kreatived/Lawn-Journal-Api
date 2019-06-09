using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Dtos.LawnSections
{
    public class LawnSection
    {
        public string Id { get; }
        [Required]
        [StringLength(200)]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }
        public int SquareFeet { get; }

        public LawnSection(Models.LawnSection lawnSection)
        {
            Id = lawnSection.Id;
            Name = lawnSection.Name;
            Description = lawnSection.Description;
            ImageUrl = lawnSection.ImageUrl;
            SquareFeet = lawnSection.SqareFeet;
            
        }
    }
}