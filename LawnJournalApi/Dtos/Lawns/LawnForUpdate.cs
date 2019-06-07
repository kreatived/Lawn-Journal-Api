using System.ComponentModel.DataAnnotations;
using LawnJournalApi.Models;

namespace LawnJournalApi.Dtos.Lawns
{
    public class LawnForUpdate
    {
        [Required]
        [StringLength(200)]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }
    }
}