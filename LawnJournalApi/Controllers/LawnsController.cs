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

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("I'm alive!"); 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lawns = await _lawnService.GetAllAsync();
            var dtos = lawns.Select(l => new LawnDto(l)).ToList();
            return Ok(lawns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var lawn = await _lawnService.GetAsync(id);

            if(lawn == null)
            {
                return NotFound();
            }

            var dto = new LawnDto(lawn);
            return Ok(lawn);
        }
    }
}