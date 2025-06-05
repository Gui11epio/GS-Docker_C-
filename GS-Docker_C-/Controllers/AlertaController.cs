using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoAlertaC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _alertaService;

        public AlertaController(AlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AlertaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AlertaResponse> Calcular([FromBody] DadosClimaticosRequest request)
        {
            try
            {
                var alerta = _alertaService.CalcularAlerta(request);
                return Ok(alerta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
