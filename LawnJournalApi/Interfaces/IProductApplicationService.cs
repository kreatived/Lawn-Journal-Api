using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Dtos.ProductApplications;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface IProductApplicationService
    {
        Task<List<Models.ProductApplication>> GetAllAsync(string lawnId);
        Task<Models.ProductApplication> GetAsync(string lawnId, string productApplicationId);
        Task<Models.ProductApplication> CreateAsync(string lawnId, ProductApplicationForCreate newFertilizer);
        Task UpdateAsync(string lawnId, string productApplicationId, ProductApplicationForUpdate updatedFertilizer);
        Task DeleteAsync(string lawnId, string productApplicationId);

    }
}