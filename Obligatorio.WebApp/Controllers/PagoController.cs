using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.WebApp.Filters;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    [Authentication]
    public class PagoController : Controller
    {
        private ICUObtenerGastosActivos _CUObtenerGastosActivos;
        private IServicioMetodoPago _ServicioMetodoPago;
        private ICUAltaPago _CUAltaPago;
        private ICUObtenerPagosPorMesAnio _CUListarPagosMensuales;
        private ICUObtenerUsuarioPorMonto _CUObtenerUsuarioPorMonto;

        public PagoController(ICUObtenerGastosActivos cUObtenerGastosActivos, IServicioMetodoPago servicioMetodoPago, ICUAltaPago cUAltaPago, ICUObtenerPagosPorMesAnio cUListarPagosMensuales, ICUObtenerUsuarioPorMonto CUObtenerUsuarioPorMonto)
        {
            _CUObtenerGastosActivos = cUObtenerGastosActivos;
            _ServicioMetodoPago = servicioMetodoPago;
            _CUAltaPago = cUAltaPago;
            _CUListarPagosMensuales = cUListarPagosMensuales;
            _CUObtenerUsuarioPorMonto = CUObtenerUsuarioPorMonto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View(CrearVMConListas());
        }

        [HttpPost]
        public IActionResult Create(AltaPagoVM vm)
        {
            try
            {
                if (!decimal.TryParse(Request.Form["Dto.Monto"], out decimal monto))
                {
                    throw new MontoNoValidoException("El monto debe ser un número válido");
                }

                string? email = HttpContext.Session.GetString("Email");
                vm.Dto.Email = email;
                vm.Dto.Monto = monto;
                _CUAltaPago.AltaPago(vm.Dto);

                return RedirectToAction("Create", "Pago", new { mensaje = "Pago creado con éxito" });
            }
            catch (Exception e)
            {
                ModelState.Clear();
                ViewBag.Mensaje = e.Message;
                return View(CrearVMConListas());
            }
        }
        private AltaPagoVM CrearVMConListas()
        {
            return new AltaPagoVM
            {
                TodosLosGastos = _CUObtenerGastosActivos.ObtenerGastosActivos(),
                TodosLosMetodosDePago = _ServicioMetodoPago.ObtenerMetodos()
            };
        }


        [GerenteFilter]
        public IActionResult ListarPagosPorMesAnio(string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View(new List<DTOPago>());
        }

        [GerenteFilter]
        [HttpPost]
        public IActionResult ListarPagosPorMesAnio(int mes, int anio)
        {
            try
            {
                List<DTOPago> listaDePagos = _CUListarPagosMensuales.ObtenerPagosPorMesAnio(mes, anio);

                return View(listaDePagos);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;

                return View(new List<DTOPago>());
            }
        }

        [GerenteFilter]
        public IActionResult ListarUsuariosPorMonto(string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View(new List<DTOUsuario>());
        }

        [GerenteFilter]
        [HttpPost]
        public IActionResult ListarUsuariosPorMonto(decimal monto)
        {
            try
            {
                List<DTOUsuario> lista = _CUObtenerUsuarioPorMonto.ObtenerUsuarioPorMonto(monto);

                return View(lista);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View(new List<DTOUsuario>());
            }
        }
    }
}
