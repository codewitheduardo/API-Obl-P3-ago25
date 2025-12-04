using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private ICUObtenerPago _CUObtenerPago;
        private ICUObtenerPagosPorUsuario _CUObtenerPagosPorUsuario;
        private ICUAltaPago _CUAltaPago;

        public PagoController(ICUObtenerPago cUObtenerPago, ICUObtenerPagosPorUsuario cUObtenerPagosPorUsuario, ICUAltaPago cUAltaPago)
        {
            _CUObtenerPago = cUObtenerPago;
            _CUObtenerPagosPorUsuario = cUObtenerPagosPorUsuario;
            _CUAltaPago = cUAltaPago;
        }

        [HttpGet("{id}")]
        public IActionResult DatosPorId(int id)
        {
            try
            {
                DTOPago retorno = _CUObtenerPago.ObtenerPago(id);
                return StatusCode(200, retorno);
            }
            catch (PagoNoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("Usuario")]
        [Authorize(Roles = "EMPLEADO, GERENTE")]
        public IActionResult PagosPorUsuario()
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                List<DTOPago> retorno = _CUObtenerPagosPorUsuario.ObtenerPagosPorUsuario(email);

                return StatusCode(200, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Alta")]
        [Authorize]
        public IActionResult Alta([FromBody] DTOAltaPago dto)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                dto.Email = email;
                _CUAltaPago.AltaPago(dto);

                return StatusCode(201);
            }
            catch (GastoNoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (UsuarioNoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (PagoNoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (DatosInvalidosException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
