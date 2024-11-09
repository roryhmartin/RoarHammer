using Microsoft.AspNetCore.Mvc;
using roarHammerBackend.Models;
using roarHammerBackend.Services;

namespace RoarhammerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DarkAngelsController : ControllerBase
    {
        private readonly DarkAngelService _darkAngelService;

        public DarkAngelsController(DarkAngelService darkAngelService)
        {
            _darkAngelService = darkAngelService;
        }

        [HttpGet]
        public async Task<List<DarkAngel>> Get()
        {
            return await _darkAngelService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DarkAngel newDarkAngel)
        {
            await _darkAngelService.CreateAsync(newDarkAngel);
            return CreatedAtAction(nameof(Get), new { id = newDarkAngel.name }, newDarkAngel);
        }
    }
}