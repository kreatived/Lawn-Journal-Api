using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawnJournalApi.Dtos.ProductApplications;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using LawnJournalApi.Models;
using LawnJournalApi.Models.Products;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LawnJournalApi.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private IMongoCollection<Models.ProductApplication> _productApplications;

        public ProductApplicationService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LawnJournalDb"));
            var database = client.GetDatabase("LawnJournalDb");
            _productApplications = database.GetCollection<Models.ProductApplication>("ProductApplications");
        }

        public async Task<Models.ProductApplication> CreateAsync(string lawnId, ProductApplicationForCreate newProductApplication)
        {
            var application = new Models.ProductApplication
            {
                ProductId = newProductApplication.ProductId,
                LawnId = lawnId,
                LawnSectionId = newProductApplication.LawnSectionId,
                Amount = newProductApplication.Amount,
                UnitOfMeasure = newProductApplication.UnitOfMeasure,
                ApplicationDate = newProductApplication.ApplicationDate,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _productApplications.InsertOneAsync(application);

            return application;
        }

        public async Task DeleteAsync(string lawnId, string productApplicationId)
        {
            var result = await _productApplications.DeleteOneAsync(a => a.LawnId == lawnId && a.Id == productApplicationId);

            if(result.DeletedCount == 0)
            {
                throw new ProductApplicationNotFoundException(lawnId, productApplicationId);
            }
        }

        public async Task<List<Models.ProductApplication>> GetAllAsync(string lawnId)
        {
            var applicationsTask = await _productApplications.FindAsync(a => a.Id == lawnId);

            return await applicationsTask.ToListAsync();
        }

        public async Task<Models.ProductApplication> GetAsync(string lawnId, string productApplicationId)
        {
            var application = await GetProductApplicationAsync(lawnId, productApplicationId);

            return application;
        }

        public async Task UpdateAsync(string lawnId, string productApplicationId, ProductApplicationForUpdate updatedProductApplication)
        {
            var application = await GetProductApplicationAsync(lawnId, productApplicationId);

            application.ProductId = updatedProductApplication.ProductId;
            application.LawnSectionId = updatedProductApplication.LawnSectionId;
            application.Amount = updatedProductApplication.Amount;
            application.UnitOfMeasure = updatedProductApplication.UnitOfMeasure;
            application.ApplicationDate = updatedProductApplication.ApplicationDate;
            application.UpdatedDate = DateTime.UtcNow;

            await _productApplications.ReplaceOneAsync(a => a.LawnId == lawnId && a.Id == productApplicationId, application);
        }

        private async Task<Models.ProductApplication> GetProductApplicationAsync(string lawnId, string productApplicationId)
        {
            var applicationTask = await _productApplications.FindAsync(a => a.LawnId == lawnId && a.Id == productApplicationId);

            var application = await applicationTask.FirstOrDefaultAsync();
            if(application == null)
            {
                throw new ProductApplicationNotFoundException(lawnId, productApplicationId);
            }

            return application;
        }
    }
}