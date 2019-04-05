using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Interfaces;
using LawnJournalApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LawnJournalApi.Services
{
    public class LawnService: ILawnService
    {
        private IMongoCollection<Lawn> _lawns;

        public LawnService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LawnJournalDb"));
            var database = client.GetDatabase("LawnJournalDb");
            _lawns = database.GetCollection<Lawn>("Lawns");
        }

        public async Task<List<Lawn>> GetAsync()
        {
            var task = await _lawns.FindAsync(l => true);
            return await task.ToListAsync();
        }
    }
}