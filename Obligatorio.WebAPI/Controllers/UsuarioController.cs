using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ICUResetearPassword _CUResetearPassword;

        public UsuarioController(ICUResetearPassword cUResetearPassword)
        {
            _CUResetearPassword = cUResetearPassword;
        }

        [HttpPost("ResetearPassword")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult ResetearPassword([FromBody] DTOResetearPassword dto)
        {
            try
            {
                string retorno = _CUResetearPassword.ResetearPassword(dto.Email);

                return StatusCode(200, retorno);
            }
            catch (UsuarioNoEncontradoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
