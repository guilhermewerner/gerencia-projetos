using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciaProjetos.Models;
using GerenciaContext = GerenciaProjetos.Data.GerenciaContext;
using Microsoft.AspNetCore.Http;

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
            return View();
        }

        [HttpPost]
        public IActionResult Index(Desenvolvedor dev)
        {
            Desenvolvedor desenvolvedor = ctx.Desenvolvedores.Where(a => a.Email == dev.Email && a.Senha == dev.Senha).FirstOrDefault();
            if (desenvolvedor != null)
            {
                HttpContext.Session.SetInt32("Id", desenvolvedor.Id);
                HttpContext.Session.SetString("Email", desenvolvedor.Email);
                HttpContext.Session.SetInt32("EAdmin", desenvolvedor.EAdmin ? 1 : 0);

                ViewBag.Projeto = ctx.Projetos;

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Mensagem = "Usuario não encontrado!";

                return View();
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Desenvolvedor dev)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedores.Add(dev);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", dev);
            }
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
