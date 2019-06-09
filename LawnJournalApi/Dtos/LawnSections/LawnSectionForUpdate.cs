using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace LawnJournalApi.Dtos.LawnSections
{
    public class LawnSectionForUpdate
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SquareFeet { get; set; }
    }
}