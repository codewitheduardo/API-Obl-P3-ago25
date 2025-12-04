using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.WebApp.Filters;

namespace Obligatorio.WebApp.Controllers
{
    [Authentication]
    [AdminOGerenteFilter]
    public class UsuarioController : Controller
    {
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUObtenerEquipos _CUObtenerEquipos;

        public UsuarioController(ICUAltaUsuario cUAltaUsuario, ICUObtenerEquipos cUObtenerEquipos)
        {
            _CUAltaUsuario = cUAltaUsuario;
            _CUObtenerEquipos = cUObtenerEquipos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string mensaje)
        {
            DTOAltaUsuario dtoIda = new DTOAltaUsuario();
            dtoIda.Equipos = _CUObtenerEquipos.ObtenerEquipos();

            ViewBag.Mensaje = mensaje;
            return View(dtoIda);
        }

        [HttpPost]
        public IActionResult Create(DTOAltaUsuario dto)
        {
            try
            {
                _CUAltaUsuario.AltaUsuario(dto);

                return RedirectToAction("Create", "Usuario", new { mensaje = "Usuario creado con éxito" });
            }
            catch (Exception e)
            {
                ModelState.Clear();
                ViewBag.Mensaje = e.Message;

                DTOAltaUsuario dtoVuelta = new DTOAltaUsuario();
                dtoVuelta.Equipos = _CUObtenerEquipos.ObtenerEquipos();

                return View(dtoVuelta);
            }
        }
    }
}
