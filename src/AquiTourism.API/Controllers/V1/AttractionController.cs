using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttractionViewModel viewModel)
        {
            var userIdClaim = User.FindFirst("sub") ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);
            var result = await _attractionAppService.AddAsync(viewModel, userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AttractionViewModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var result = _attractionAppService.Update(model, userId);
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attractionAppService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var userIdClaim = User.FindFirst("sub") ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);
            var success = await _attractionAppService.DeactivateAsync(id, userId);
            if (!success) return NotFound();
            return Ok();
        }
    }
}