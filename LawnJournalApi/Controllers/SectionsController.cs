using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawnJournalApi.Dtos;
using LawnJournalApi.Dtos.Lawns;
using LawnJournalApi.Dtos.LawnSections;
using LawnJournalApi.Exceptions;
using LawnJournalApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawnJournalApi.Controllers 
{
    [Route("api/lawns/{lawnId}/sections")]
    [ApiController]
    public class LawnSectionsController: ControllerBase
    {
        private ILawnSectionService _lawnSectionService;

        public LawnSectionsController(ILawnSectionService lawnSectionService)
        {
            _lawnSectionService = lawnSectionService;
        }

        [HttpGet(Name = "GetLawnSections")]
        public async Task<IActionResult> Get(string lawnId)
        {
            try {
                var sections = await _lawnSectionService.GetAllAsync(lawnId);
                var dtos = sections.Select(s => new LawnSection(s)).ToList();
                return Ok(dtos);
            }
            catch(LawnNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{sectionId}", Name = "GetLawn")]
        public async Task<IActionResult> Get(string lawnId, string sectionId)
        {
            try {
                var section = await _lawnSectionService.GetAsync(lawnId, sectionId);
                var dto = new LawnSection(section);
                return Ok(dto);
            }
            catch(LawnNotFoundException)
            {
                return BadRequest($"No lawn found with id {lawnId}");
            }
            catch(LawnSectionNotFoundException)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(string lawnId, LawnSectionForCreate newSection)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var section = await _lawnSectionService.Create(lawnId, newSection);

            return CreatedAtAction(nameof(Get), new {lawnId = lawnId, sectionId = section.Id}, new LawnSection(section));
        }

        [HttpPut("{sectionId}")]
        public async Task<IActionResult> Update(string lawnId, string sectionId, LawnSectionForUpdate updatedLawnSection)
        {
            try {
                var section = await _lawnSectionService.GetAsync(lawnId, sectionId);
                await _lawnSectionService.Update(lawnId, sectionId, updatedLawnSection);
                return Ok();
            }
            catch(LawnNotFoundException)
            {
                return BadRequest($"No lawn found with id {lawnId}");
            }
            catch(LawnSectionNotFoundException)
            {
                return NotFound();
            }
            
        }

        [HttpDelete("{sectionId}")]
        public async Task<IActionResult> Delete(string lawnId, string sectionId)
        {
            try{
                var section = await _lawnSectionService.GetAsync(lawnId, sectionId);
                await _lawnSectionService.Delete(lawnId, sectionId);
                return NoContent();
            }
            catch(LawnNotFoundException)
            {
                return BadRequest($"No lawn found with id {lawnId}");
            }
            catch(LawnSectionNotFoundException)
            {
                return NotFound();
            }
        }
    }
}