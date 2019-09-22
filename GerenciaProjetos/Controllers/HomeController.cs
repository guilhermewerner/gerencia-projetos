using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciaProjetos.Models;
using GerenciaContext = GerenciaProjetos.Data.GerenciaContext;

namespace GerenciaProjetos.Controllers
{
    public class HomeController : Controller
    {
        private GerenciaContext ctx;
        
        public HomeController(GerenciaContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Desenvolvedores = ctx.Desenvolvedores;
            ViewBag.Projetos = ctx.Projetos;
            ViewBag.Requisitos = ctx.Requisitos;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
