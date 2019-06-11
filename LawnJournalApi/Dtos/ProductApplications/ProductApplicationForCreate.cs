using System;
using System.ComponentModel.DataAnnotations;

namespace LawnJournalApi.Dtos.ProductApplications
{
    public class ProductApplicationForCreate
    {
        [Required]
        public string ProductId { get; }
        [Required]
        public string LawnSectionId { get; }
        [Required]
        public decimal Amount { get; }
        [Required]
        public string UnitOfMeasure { get; }
        [Required]
        public DateTime ApplicationDate { get; }
    }
}