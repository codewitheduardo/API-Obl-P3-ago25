using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.LogicaAplicacion.CasosUso.CUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.WebApp.Filters;

namespace Obligatorio.WebApp.Controllers
{
    [Authentication]
    [AdminFilter]
    public class GastoController : Controller
    {
        private ICUObtenerGastos _CUObtenerGastos;
        private ICUAltaGasto _CUAltaGasto;
        private ICUEditarGasto _CUEditarGasto;
        private ICUObtenerGasto _CUObtenerGasto;
        private ICUEliminarGasto _CUEliminarGasto;

        public GastoController(ICUAltaGasto cUAltaGasto, ICUObtenerGastos cUObtenerGastos, ICUEditarGasto cUEditarGasto, ICUObtenerGasto cUObtenerGasto, ICUEliminarGasto cUEliminarGasto)
        {
            _CUAltaGasto = cUAltaGasto;
            _CUObtenerGastos = cUObtenerGastos;
            _CUEditarGasto = cUEditarGasto;
            _CUObtenerGasto = cUObtenerGasto;
            _CUEliminarGasto = cUEliminarGasto;
        }

        public IActionResult Index(string mensaje)
        {
            try
            {
                List<DTOGasto> listaDeGastos = _CUObtenerGastos.ObtenerGastos();
                ViewBag.Mensaje = mensaje;

                return View(listaDeGastos);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = (mensaje != null ? mensaje + " " : "") + e.Message;
                return View(new List<DTOGasto>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DTOAltaGasto dto)
        {
            try
            {
                string? email = HttpContext.Session.GetString("Email");

                _CUAltaGasto.AltaGasto(dto, email);
                
                return RedirectToAction("Index", "Gasto", new { mensaje = "Gasto creado con éxito" });
            }
            catch (UsuarioSinPermisosException e)
            {
                return RedirectToAction("Index", "Gasto", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View(dto);
            }
        }

        public IActionResult Edit(int id)
        {
            DTOGasto dto = _CUObtenerGasto.ObtenerGasto(id);
            HttpContext.Session.SetInt32("IdGastoEditar", id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(DTOGasto dto)
        {
            try
            {
                string? email = HttpContext.Session.GetString("Email");
                int? idGasto = HttpContext.Session.GetInt32("IdGastoEditar");

                if (idGasto is null)
                {
                    return RedirectToAction("Index", "Gasto");
                }

                dto.Id = (int)idGasto;

                _CUEditarGasto.EditarGasto(dto, email);
                
                return RedirectToAction("Index", "Gasto", new { mensaje = "Gasto editado con éxito" });
            }
            catch (UsuarioSinPermisosException e)
            {
                return RedirectToAction("Index", "Gasto", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View(dto);
            }
        }

        public IActionResult Delete(int id)
        {
            DTOGasto dto = _CUObtenerGasto.ObtenerGasto(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(DTOGasto dto)
        {
            try
            {
                string? email = HttpContext.Session.GetString("Email");

                if (dto is null)
                {
                    return RedirectToAction("Index", "Gasto");
                }

                _CUEliminarGasto.EliminarGasto(dto.Id, email);

                return RedirectToAction("Index", "Gasto", new { mensaje = "Gasto eliminado con éxito" });
            }
            catch (UsuarioSinPermisosException e)
            {
                return RedirectToAction("Index", "Gasto", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Gasto", new { mensaje = e.Message });
            }
        }
    }
}
