using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Filters
{
    public class LoginFilterAttribute : Attribute, IActionFilter
    {
        public bool Restrito { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            int? IdUsuario = context.HttpContext.Session.GetInt32("Id");

            if (IdUsuario == null)
            {
                context.Result = new RedirectToRouteResult(new { controller = "Home", action = "Index" });
            }
            else if (context.HttpContext.Session.GetInt32("EAdmin") != 1 && Restrito)
            {
                context.Result = new RedirectToRouteResult(new
                {
                    controller = "Dashboard",
                    action = "Index"
                });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
