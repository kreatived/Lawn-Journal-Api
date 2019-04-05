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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lawns = await _lawnService.GetAsync();
            var dtos = lawns.Select(l => new LawnDto(l)).ToList();
            return Ok(lawns);
        }
    }
}