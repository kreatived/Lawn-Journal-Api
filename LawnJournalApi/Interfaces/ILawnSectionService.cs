using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.LawnSections;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface ILawnSectionService
    {
        Task<List<Models.LawnSection>> GetAllAsync(string lawnId);
        Task<Models.LawnSection> GetAsync(string lawnId, string id);
        Task<Models.LawnSection> Create(string lawnId, LawnSectionForCreate newLawnSection);
        Task Update(string lawnId, string lawnSectionId, LawnSectionForUpdate updatedLawnSection);
        Task Delete(string lawnId, string id);

    }
}