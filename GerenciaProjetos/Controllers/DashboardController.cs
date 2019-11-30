using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaProjetos.Data;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaProjetos.Controllers
{
    public class DashboardController : Controller
    {
        private GerenciaContext ctx;

        public DashboardController(GerenciaContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Desenvolvedores = ctx.Desenvolvedores;
            ViewBag.Projetos = ctx.Projetos;
            ViewBag.Requisitos = ctx.Requisitos;
            ViewBag.Bugs = ctx.Bugs;

            return View();
        }
    }
}