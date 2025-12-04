using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.iCULogin;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _CULogin;
        private IConfiguration _Config;

        public AuthController(ICULogin cULogin, IConfiguration config)
        {
            _CULogin = cULogin;
            _Config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody] DTOLogin dto)
        {
            try
            {
                DTOUsuario u = _CULogin.VerificarExistencia(dto);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, u.Email),
                    new Claim(ClaimTypes.Role, u.Rol),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //identifica el token, es unico, si el mismo user loguea 2 veces, son 2 tokens distintos
                };

                var key = _Config["Jwt:Key"]!;
                var expire = int.Parse(_Config["Jwt:ExpireMinutes"]);
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512);

                // Emite token
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expire),
                    signingCredentials: credentials
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                // respuesta
                return StatusCode(200, new
                {
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Rol = u.Rol,
                    token = jwt,
                    expira = expire
                });
            }
            catch (DatosInvalidosException e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
