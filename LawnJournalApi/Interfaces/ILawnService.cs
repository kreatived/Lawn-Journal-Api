using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface ILawnService
    {
        Task<List<Lawn>> GetAllAsync();
        Task<Lawn> GetAsync(string id);
        Task<Lawn> Create(LawnDto lawn);
        void Update(LawnDto lawn);
        void Delete(string id);

    }
}