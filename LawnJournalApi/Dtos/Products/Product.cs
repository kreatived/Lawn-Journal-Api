using System.ComponentModel.DataAnnotations;

namespace LawnJournalApi.Dtos.Products
{
    public abstract class Product
    {
        public string Id { get; }
        [Required]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public string ImageUrl { get; }
        [Required]
        public string ProductType { get; }

        public Product(string id, string name, string description, string imageUrl, string productType)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            ProductType = productType;
        }
    }
}