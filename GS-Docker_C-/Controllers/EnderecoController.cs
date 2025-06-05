using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoAlertaC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ObterTodos()
        {
            var enderecos = _enderecoService.ObterTodos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterPorId(int id)
        {
            var endereco = _enderecoService.ObterPorId(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar([FromBody] EnderecoRequest request)
        {
            var endereco = _enderecoService.Criar(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Atualizar(int id, [FromBody] EnderecoRequest request)
        {
            var sucesso = _enderecoService.Atualizar(id, request);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remover(int id)
        {
            var sucesso = _enderecoService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}

