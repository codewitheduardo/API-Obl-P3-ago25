using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsServicio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private IServicioMetodoPago _servicioMetodoPago;

        public MetodoPagoController(IServicioMetodoPago servicioMetodoPago)
        {
            _servicioMetodoPago = servicioMetodoPago;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetMetodosDePago()
        {
            try
            {
                List<DTOMetodoPago> retorno = _servicioMetodoPago.ObtenerMetodos();

                return StatusCode(200, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
