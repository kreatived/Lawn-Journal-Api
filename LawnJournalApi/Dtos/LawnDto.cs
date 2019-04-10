using System.ComponentModel.DataAnnotations;
using LawnJournalApi.Models;

namespace LawnJournalApi.Dtos
{
    public class LawnDto
    {
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public LawnDto()
        {

        }

        public LawnDto(Lawn lawn)
        {
            Id = lawn.Id;
            Name = lawn.Name;
            Description = lawn.Description;
            ImageUrl = lawn.ImageUrl;
        }
    }
}