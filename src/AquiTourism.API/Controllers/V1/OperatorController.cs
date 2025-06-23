using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AquiTourism.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/operator")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorAppService _operatorAppService;

        public OperatorController(IOperatorAppService operatorAppService)
        {
            _operatorAppService = operatorAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OperatorCreateViewModel model)
        {
            var result = await _operatorAppService.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OperatorViewModel model)
        {
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
            var result = await _operatorAppService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] OperatorLoginViewModel model)
        {
            var success = await _operatorAppService.AuthenticateAsync(model);
            if (!success)
                return Unauthorized();
            return Ok();
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