using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string? rol = context.HttpContext.Session.GetString("Rol");

            if (rol != "ADMINISTRADOR") 
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { mensaje = "ACCESO DENEGADO" });
            }
            base.OnActionExecuted(context);
        }
    }
}
