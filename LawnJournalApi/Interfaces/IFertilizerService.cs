using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface IFertilizerService
    {
        Task<List<Models.Products.Fertilizer>> GetAllAsync();
        Task<Models.Products.Fertilizer> GetAsync(string fertilizerId);
        Task<Models.Products.Fertilizer> Create(FertilizerForCreate newFertilizer);
        Task Update(string fertilizerId, FertilizerForUpdate updatedFertilizer);
        Task Delete(string fertilizerId);

    }
}