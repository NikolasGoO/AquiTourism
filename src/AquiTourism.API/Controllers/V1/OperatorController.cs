using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AquiTourism.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/operator")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorAppService _operatorAppService;
        private readonly IConfiguration _configuration;

        public OperatorController(IOperatorAppService operatorAppService, IConfiguration configuration)
        {
            _operatorAppService = operatorAppService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OperatorCreateViewModel model)
        {
            var userIdClaim = User.FindFirst("sub") ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int creatorUserId = int.Parse(userIdClaim.Value);

            var result = await _operatorAppService.CreateAsync(model, creatorUserId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OperatorViewModel model)
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized();

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var operatorId = JwtTokenGenerator.GetOperatorIdFromToken(token);
            if (operatorId == null)
                return Unauthorized();

            if (operatorId != id)
                return Forbid();

            model.Id = id;
            var result = await _operatorAppService.UpdateAsync(id, model);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _operatorAppService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var operatorIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            //if (operatorIdClaim == null || !int.TryParse(operatorIdClaim.Value, out var operatorId))
            //    return Unauthorized();

            //if (operatorId != id)
            //    return Forbid();

            var result = await _operatorAppService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] OperatorLoginViewModel model)
        {
            var jwtSecret = _configuration["Jwt:SecretKey"];
            var token = await _operatorAppService.AuthenticateAndGenerateTokenAsync(model, jwtSecret);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { token });
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var success = await _operatorAppService.DeactivateAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] OperatorResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _operatorAppService.ResetPasswordAsync(model.Cpf, model.NewPassword, model.ConfirmPassword);

            if (!result)
                return NotFound("Operador não encontrado ou CPF inválido.");

            return Ok("Senha redefinida com sucesso.");
        }
    }
}