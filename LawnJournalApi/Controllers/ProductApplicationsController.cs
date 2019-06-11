using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Dtos.ProductApplications;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawnJournalApi.Controllers 
{
    [Route("api/lawns/{lawnId}/product_applications")]
    [ApiController]
    public class ProductApplicationsController: ControllerBase
    {
        private IProductApplicationService _productApplicationService;

        public ProductApplicationsController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        [HttpGet(Name = "GetProductApplications")]
        public async Task<IActionResult> Get(string lawnId)
        {
            var applications = await _productApplicationService.GetAllAsync(lawnId);
            var dtos = applications.Select(a => new ProductApplication(a)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{productApplicationId}", Name = "GetProductApplication")]
        public async Task<IActionResult> Get(string lawnId, string productApplicationId)
        {
            try {
                var application = await _productApplicationService.GetAsync(lawnId, productApplicationId);
                var dto = new ProductApplication(application);
                return Ok(dto);
            } 
            catch(ProductApplicationNotFoundException) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string lawnId, ProductApplicationForCreate newProductApplication)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var application = await _productApplicationService.CreateAsync(lawnId, newProductApplication);

            return CreatedAtAction(nameof(Get), new {productApplicationId = application.Id}, new ProductApplication(application));
        }

        [HttpPut("{productApplicationId}")]
        public async Task<IActionResult> Update(string lawnId, string productApplicationId, ProductApplicationForUpdate updatedProductApplication)
        {
            try {
                await _productApplicationService.UpdateAsync(lawnId, productApplicationId, updatedProductApplication);
                return Ok();
            }
            catch(ProductApplicationNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{productApplicationId}")]
        public async Task<IActionResult> Delete(string lawnId, string productApplicationId)
        {
            try {
                await _productApplicationService.DeleteAsync(lawnId, productApplicationId);
                return NoContent();
            }
            catch(FertilizerNotFoundException)
            {
                return NotFound();
            }
        }
    }
}