using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Exceptions;
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
            var dtos = lawns.Select(l => new Lawn(l)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{lawnId}", Name = "GetLawn")]
        public async Task<IActionResult> Get(string lawnId)
        {
            try {
                var lawn = await _lawnService.GetAsync(lawnId);
                var dto = new Lawn(lawn);
                return Ok(dto);
            } 
            catch(LawnNotFoundException) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LawnForCreate newLawn)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawn = await _lawnService.Create(newLawn);

            return CreatedAtAction(nameof(Get), new {lawnId = lawn.Id}, new Lawn(lawn));
        }

        [HttpPut("{lawnId}")]
        public async Task<IActionResult> Update(string lawnId, LawnForUpdate updatedLawn)
        {
            try {
                var lawn = await _lawnService.GetAsync(lawnId);
                await _lawnService.Update(lawnId, updatedLawn);
                return Ok();
            }
            catch(LawnNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{lawnId}")]
        public async Task<IActionResult> Delete(string lawnId)
        {
            try {
                var lawn = await _lawnService.GetAsync(lawnId);
                await _lawnService.Delete(lawnId);
                return NoContent();
            }
            catch(LawnNotFoundException)
            {
                return NotFound();
            }
        }

    }
}