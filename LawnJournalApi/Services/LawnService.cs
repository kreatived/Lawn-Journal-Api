using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Interfaces;
using LawnJournalApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LawnJournalApi.Services
{
    public class LawnService: ILawnService
    {
        private IMongoCollection<Models.Lawn> _lawns;

        public LawnService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LawnJournalDb"));
            var database = client.GetDatabase("LawnJournalDb");
            _lawns = database.GetCollection<Models.Lawn>("Lawns");
        }

        public async Task<Models.Lawn> Create(LawnForCreate newLawn)
        {
            var lawn = new Models.Lawn
            {
                Name = newLawn.Name,
                Description = newLawn.Description,
                ImageUrl = newLawn.ImageUrl,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _lawns.InsertOneAsync(lawn);

            return lawn;
        }

        public async Task Delete(string id)
        {
            await _lawns.DeleteOneAsync(l => l.Id == id);
        }

        public async Task<List<Models.Lawn>> GetAllAsync()
        {
            var tasks = await _lawns.FindAsync(l => true);
            return await tasks.ToListAsync();
        }

        public async Task<Models.Lawn> GetAsync(string id)
        {
            var task = await _lawns.FindAsync(l => l.Id == id);

            return await task.FirstOrDefaultAsync();
        }

        public async Task Update(string lawnId, LawnForUpdate updatedLawn)
        {
            var lawn = new Models.Lawn
            {
                Id = lawnId,
                Name = updatedLawn.Name,
                Description = updatedLawn.Description,
                ImageUrl = updatedLawn.ImageUrl,
                UpdatedDate = DateTime.UtcNow
            };

            await _lawns.ReplaceOneAsync(l => l.Id == lawnId, lawn);
        }
    }
}