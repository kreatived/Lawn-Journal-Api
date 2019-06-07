using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface ILawnService
    {
        Task<List<Models.Lawn>> GetAllAsync();
        Task<Models.Lawn> GetAsync(string lawnId);
        Task<Models.Lawn> Create(LawnForCreate newLawn);
        Task Update(string lawnId, LawnForUpdate updatedLawn);
        Task Delete(string lawnId);

    }
}