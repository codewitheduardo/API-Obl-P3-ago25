using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private ICUObtenerGastosActivos _cuObtenerGastosActivos;

        public GastoController(ICUObtenerGastosActivos cuObtenerGastosActivos)
        {
            _cuObtenerGastosActivos = cuObtenerGastosActivos;
        }

        [Authorize]
        [HttpGet("Activos")]
        public IActionResult GetGastosActivos()
        {
            try
            {
                List<DTOGasto> retorno = _cuObtenerGastosActivos.ObtenerGastosActivos();

                return StatusCode(200, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
