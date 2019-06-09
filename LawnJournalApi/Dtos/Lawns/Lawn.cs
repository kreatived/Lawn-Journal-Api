using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LawnJournalApi.Models;

namespace LawnJournalApi.Dtos.Lawns
{
    public class Lawn
    {
        public string Id { get; }
        [Required]
        [StringLength(200)]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }
        public int SquareFeet => Sections.Sum(s => s.SquareFeet);
        public List<Dtos.LawnSections.LawnSection> Sections { get; }

        public Lawn(Models.Lawn lawn)
        {
            Id = lawn.Id;
            Name = lawn.Name;
            Description = lawn.Description;
            ImageUrl = lawn.ImageUrl;
            Sections = lawn.Sections.Select(s => new Dtos.LawnSections.LawnSection(s)).ToList();
        }
    }
}