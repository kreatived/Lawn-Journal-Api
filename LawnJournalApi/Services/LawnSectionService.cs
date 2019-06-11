using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.LawnSections;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using LawnJournalApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LawnJournalApi.Services
{
    public class LawnSectionService: ILawnSectionService
    {
        private IMongoCollection<Lawn> _lawns;

        public LawnSectionService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LawnJournalDb"));
            var database = client.GetDatabase("LawnJournalDb");
            _lawns = database.GetCollection<Lawn>("Lawns");
        }

        public async Task<Models.LawnSection> Create(string lawnId, LawnSectionForCreate newLawnSection)
        {
            var lawn = await GetLawnAsync(lawnId);

            var lawnSection = new Models.LawnSection
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = newLawnSection.Name,
                Description = newLawnSection.Description,
                ImageUrl = newLawnSection.ImageUrl,
                SquareFeet = newLawnSection.SquareFeet,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            lawn.Sections.Add(lawnSection);
            await _lawns.ReplaceOneAsync(l => l.Id == lawnId, lawn);

            return lawnSection;
        }

        public async Task Delete(string lawnId, string sectionId)
        {
            var lawn = await GetLawnAsync(lawnId);
            var sectionToRemove = GetLawnSection(sectionId, lawn);

            lawn.Sections.Remove(sectionToRemove);
            await _lawns.ReplaceOneAsync(l => l.Id == lawnId, lawn);
        }

        public async Task<List<Models.LawnSection>> GetAllAsync(string lawnId)
        {
            var lawn = await GetLawnAsync(lawnId);

            return lawn.Sections;
        }

        public async Task<Models.LawnSection> GetAsync(string lawnId, string sectionId)
        {
            var lawn = await GetLawnAsync(lawnId);
            var section = GetLawnSection(sectionId, lawn);

            return section;
        }

        public async Task Update(string lawnId, string sectionId, LawnSectionForUpdate updatedLawnSection)
        {
            var lawn = await GetLawnAsync(lawnId);
            var section = GetLawnSection(sectionId, lawn);
    
            section.Name = updatedLawnSection.Name;
            section.Description = updatedLawnSection.Description;
            section.ImageUrl = updatedLawnSection.ImageUrl;
            section.SquareFeet = updatedLawnSection.SquareFeet;
            section.UpdatedDate = DateTime.UtcNow;

            await _lawns.ReplaceOneAsync(l => l.Id == lawnId, lawn);
        }

        private async Task<Lawn> GetLawnAsync(string lawnId, bool throwIfNotFound = true) 
        {
            var lawnTask = await _lawns.FindAsync(l => l.Id == lawnId);
            var lawn = await lawnTask.FirstOrDefaultAsync();

            if(throwIfNotFound && lawn == null)
            {
                throw new LawnNotFoundException(lawnId);
            }

            return lawn;
        }

        private Models.LawnSection GetLawnSection(string lawnSectionId, Lawn lawn, bool throwIfNotFound = true)
        {
            var section = lawn.Sections.FirstOrDefault(s => s.Id == lawnSectionId);

            if(throwIfNotFound && section == null)
            {
                throw new LawnSectionNotFoundException(lawnSectionId);
            }

            return section;
        }
    }
}