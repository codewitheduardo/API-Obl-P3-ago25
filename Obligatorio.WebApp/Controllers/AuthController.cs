using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.iCULogin;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;

namespace Obligatorio.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private ICULogin _CULogin;

        public AuthController(ICULogin cULogin)
        {
            _CULogin = cULogin;
        }

        public IActionResult Login(string mensaje)
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(DTOLogin dto)
        {
            try
            {
                DTOUsuario user = _CULogin.VerificarExistencia(dto);

                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Rol", user.Rol);
                HttpContext.Session.SetString("Nombre", user.Nombre);
                HttpContext.Session.SetString("Apellido", user.Apellido);

                return RedirectToAction("Index", "Home");
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Problema inesperado, intente luego";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
