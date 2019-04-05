using System.ComponentModel.DataAnnotations;
using LawnJournalApi.Models;

namespace LawnJournalApi.Dtos
{
    internal class LawnDto
    {
        public string Id { get; }
        [Required]
        [StringLength(200)]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }

        public LawnDto(Lawn lawn)
        {
            Id = lawn.Id;
            Name = lawn.Name;
            Description = lawn.Description;
            ImageUrl = lawn.ImageUrl;
        }
    }
}