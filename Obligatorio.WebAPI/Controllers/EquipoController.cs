using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private ICUObtenerEquiposPagosUnicosPorMonto _cuObtenerEquiposPagosUnicosPorMonto;

        public EquipoController(ICUObtenerEquiposPagosUnicosPorMonto cuObtenerEquiposPagosUnicosPorMonto)
        {
            _cuObtenerEquiposPagosUnicosPorMonto = cuObtenerEquiposPagosUnicosPorMonto;
        }


        [HttpGet("PagosUnicosMayores")]
        [Authorize(Roles = "GERENTE")]
        public IActionResult GetEquiposConPagosUnicosMayores([FromQuery]decimal monto)
        {
            try 
            {
                List<DTOEquipo> retorno = _cuObtenerEquiposPagosUnicosPorMonto.ObtenerEquiposConPagosUnicosMayores(monto);

                return StatusCode(200, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            
        }
    }
}
