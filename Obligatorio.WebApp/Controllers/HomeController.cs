using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filters;
using Obligatorio.WebApp.Models;
using System.Diagnostics;

namespace Obligatorio.WebApp.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Nombre");
            return View();
        }
    }
}
