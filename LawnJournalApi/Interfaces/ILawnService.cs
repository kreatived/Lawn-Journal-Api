using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Models;

namespace LawnJournalApi.Interfaces
{
    public interface ILawnService
    {
        Task<List<Lawn>> GetAsync();
    }
}