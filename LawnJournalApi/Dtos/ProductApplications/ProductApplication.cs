using System;
using System.ComponentModel.DataAnnotations;

namespace LawnJournalApi.Dtos.ProductApplications
{
    public class ProductApplication
    {
        [Required]
        public string Id { get; }
        [Required]
        public string ProductId { get; }
        [Required]
        public string LawnId { get; }
        public string LawnSectionId { get; }
        [Required]
        public decimal Amount { get; }
        [Required]
        public string UnitOfMeasure { get; }
        [Required]
        public DateTime ApplicationDate { get; }

        public ProductApplication(Models.ProductApplication productApplication)
        {
            Id = productApplication.Id;
            ProductId = productApplication.ProductId;
            LawnId = productApplication.LawnId;
            LawnSectionId = productApplication.LawnSectionId;
            Amount = productApplication.Amount;
            UnitOfMeasure = productApplication.UnitOfMeasure;
            ApplicationDate = productApplication.ApplicationDate;
        }
    }
}