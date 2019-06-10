using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using LawnJournalApi.Models.Products;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LawnJournalApi.Services
{
    public class FertilizerService : IFertilizerService
    {
        private IMongoCollection<Models.Products.Fertilizer> _fertilizers;

        public FertilizerService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LawnJournalDb"));
            var database = client.GetDatabase("LawnJournalDb");
            _fertilizers = database.GetCollection<Models.Products.Fertilizer>("Fertilizers");
        }

        public async Task<Models.Products.Fertilizer> Create(FertilizerForCreate newFertilizer)
        {
            var fertilizer = new Models.Products.Fertilizer
            {
                Name = newFertilizer.Name,
                Description = newFertilizer.Description,
                ImageUrl = newFertilizer.ImageUrl,
                ProductType = "fertilizer",
                CoverageAreaSqFt = newFertilizer.CoverageAreaSqFt,
                PackageSizeLb = newFertilizer.PackageSizeLb,
                CompatibleGrassTypes = newFertilizer.CompatibleGrassTypes,
                ConditionOfLawn = newFertilizer.ConditionOfLawn,
                Features = newFertilizer.Features,
                LongevityInWeeks = newFertilizer.LongevityInWeeks,
                PercentNitrogen = newFertilizer.PercentNitrogen,
                PercentPhosphorous = newFertilizer.PercentPhosphorous,
                PercentPotassium = newFertilizer.PercentPotassium,
                IsOrganic = newFertilizer.IsOrganic,
                ContainsPostEmergentWeedControl = newFertilizer.ContainsPostEmergentWeedControl,
                ContainsPreEmergentWeedControl = newFertilizer.ContainsPreEmergentWeedControl,
                SeasonsOfUse = newFertilizer.SeasonsOfUse,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _fertilizers.InsertOneAsync(fertilizer);

            return fertilizer;
        }

        public async Task Delete(string fertilizerId)
        {
            var result = await _fertilizers.DeleteOneAsync(f => f.Id == fertilizerId);

            if(result.DeletedCount == 0)
            {
                throw new FertilizerNotFoundException(fertilizerId);
            }
        }

        public async Task<List<Models.Products.Fertilizer>> GetAllAsync()
        {
            var tasks = await _fertilizers.FindAsync(l => true);
            return await tasks.ToListAsync();
        }

        public async Task<Models.Products.Fertilizer> GetAsync(string fertilizerId)
        {
            var task = await _fertilizers.FindAsync(l => l.Id == fertilizerId);

            var fertilizer = await task.FirstOrDefaultAsync();

            if(fertilizer == null)
            {
                throw new FertilizerNotFoundException(fertilizerId);
            }

            return fertilizer;
        }

        public async Task Update(string fertilizerId, FertilizerForUpdate updatedFertilizer)
        {
            var fertilizer = new Models.Products.Fertilizer
            {
                Id = fertilizerId,
                Name = updatedFertilizer.Name,
                Description = updatedFertilizer.Description,
                ImageUrl = updatedFertilizer.ImageUrl,
                ProductType = "fertilizer",
                CoverageAreaSqFt = updatedFertilizer.CoverageAreaSqFt,
                PackageSizeLb = updatedFertilizer.PackageSizeLb,
                CompatibleGrassTypes = updatedFertilizer.CompatibleGrassTypes,
                ConditionOfLawn = updatedFertilizer.ConditionOfLawn,
                Features = updatedFertilizer.Features,
                LongevityInWeeks = updatedFertilizer.LongevityInWeeks,
                PercentNitrogen = updatedFertilizer.PercentNitrogen,
                PercentPhosphorous = updatedFertilizer.PercentPhosphorous,
                PercentPotassium = updatedFertilizer.PercentPotassium,
                IsOrganic = updatedFertilizer.IsOrganic,
                ContainsPostEmergentWeedControl = updatedFertilizer.ContainsPostEmergentWeedControl,
                ContainsPreEmergentWeedControl = updatedFertilizer.ContainsPreEmergentWeedControl,
                SeasonsOfUse = updatedFertilizer.SeasonsOfUse,
                UpdatedDate = DateTime.UtcNow
            };

            var result = await _fertilizers.ReplaceOneAsync(f => f.Id == fertilizerId, fertilizer);

            if(result.MatchedCount == 0)
            {
                throw new FertilizerNotFoundException(fertilizerId);
            }
        }
    }
}