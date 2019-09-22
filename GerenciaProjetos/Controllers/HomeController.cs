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

            Desenvolvedor dev = ctx.Desenvolvedores.Find(1);
        }

        public IActionResult Index()
        {
            ViewBag.Desenvolvedores = ctx.Desenvolvedores;
            ViewBag.Projetos = ctx.Projetos;

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
