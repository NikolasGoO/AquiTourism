using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AquiTourism.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/attraction")]
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionAppService _attractionAppService;

        public AttractionController(IAttractionAppService attractionAppService)
        {
            _attractionAppService = attractionAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttractionViewModel model)
        {
            var result = await _attractionAppService.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AttractionViewModel model)
        {
            model.Id = id;
            var result = _attractionAppService.Update(model);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _attractionAppService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var success = await _attractionAppService.DeactivateAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}