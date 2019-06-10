using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Dtos.Products.Fertilizers;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawnJournalApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class FertilizersController: ControllerBase
    {
        private IFertilizerService _fertilizerService;

        public FertilizersController(IFertilizerService fertilizerService)
        {
            _fertilizerService = fertilizerService;
        }

        [HttpGet(Name = "GetFertilizers")]
        public async Task<IActionResult> Get()
        {
            var fertilizers = await _fertilizerService.GetAllAsync();
            var dtos = fertilizers.Select(l => new Fertilizer(l)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{fertilizerId}", Name = "GetFertilizer")]
        public async Task<IActionResult> Get(string fertilizerId)
        {
            try {
                var fertilizer = await _fertilizerService.GetAsync(fertilizerId);
                var dto = new Fertilizer(fertilizer);
                return Ok(dto);
            } 
            catch(FertilizerNotFoundException) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(FertilizerForCreate newFertilizer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fertilizer = await _fertilizerService.Create(newFertilizer);

            return CreatedAtAction(nameof(Get), new {fertilizerId = fertilizer.Id}, new Fertilizer(fertilizer));
        }

        [HttpPut("{fertilizerId}")]
        public async Task<IActionResult> Update(string fertilizerId, FertilizerForUpdate updatedFertilizer)
        {
            try {
                var fertilizer = await _fertilizerService.GetAsync(fertilizerId);
                await _fertilizerService.Update(fertilizerId, updatedFertilizer);
                return Ok();
            }
            catch(FertilizerNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{fertilizerId}")]
        public async Task<IActionResult> Delete(string fertilizerId)
        {
            try {
                var fertilizer = await _fertilizerService.GetAsync(fertilizerId);
                await _fertilizerService.Delete(fertilizerId);
                return NoContent();
            }
            catch(FertilizerNotFoundException)
            {
                return NotFound();
            }
        }

    }
}