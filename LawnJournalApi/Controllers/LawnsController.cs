using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawnJournalApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawnsController: ControllerBase
    {
        private ILawnService _lawnService;

        public LawnsController(ILawnService lawnService)
        {
            _lawnService = lawnService;
        }

        [HttpGet(Name = "GetLawns")]
        public async Task<IActionResult> Get()
        {
            var lawns = await _lawnService.GetAllAsync();
            var dtos = lawns.Select(l => new LawnDto(l)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetLawn")]
        public async Task<IActionResult> Get(string id)
        {
            var lawn = await _lawnService.GetAsync(id);

            if(lawn == null)
            {
                return NotFound();
            }

            var dto = new LawnDto(lawn);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LawnDto newLawn)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawn = await _lawnService.Create(newLawn);

            return CreatedAtAction(nameof(Get), new {id = lawn.Id}, new LawnDto(lawn));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, LawnDto updatedLawn)
        {
            var lawn = await _lawnService.GetAsync(id);
            if(lawn == null)
            {
                return NotFound();
            }

            await _lawnService.Update(updatedLawn);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var lawn = await _lawnService.GetAsync(id);
            if(lawn == null)
            {
                return NotFound();
            }

            await _lawnService.Delete(id);

            return NoContent();
        }

    }
}