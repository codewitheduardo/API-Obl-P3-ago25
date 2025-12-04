using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsAuditoria;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.CustomExceptions.CEAuditoria;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private ICUObtenerAuditoriasPorGasto _CUObtenerAuditoriasPorGasto;

        public AuditoriaController(ICUObtenerAuditoriasPorGasto cuObtenerAuditoriasPorGasto)
        {
            _CUObtenerAuditoriasPorGasto = cuObtenerAuditoriasPorGasto;
        }

        [HttpGet("Gasto/{idGasto}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult GetByGasto([FromRoute] int idGasto)
        {
            try
            {
                List<DTOAuditoria> retorno = _CUObtenerAuditoriasPorGasto.ObtenerAuditorias(idGasto);

                return StatusCode(200, retorno);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
