using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filters
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string? logueado = context.HttpContext.Session.GetString("Email");

            if (string.IsNullOrWhiteSpace(logueado))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", new { mensaje = "Debe de iniciar sesión." });
            }
            base.OnActionExecuted(context);
        }
    }
}
