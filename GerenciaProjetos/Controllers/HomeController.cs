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
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /* DESENVOLVEDOR */

        public IActionResult AddDev()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDev(Desenvolvedor dev)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedores.Add(dev);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("AddDev", dev);
            }
        }

        public IActionResult EditDev(int id)
        {
            Desenvolvedor dev = ctx.Desenvolvedores.Find(id);

            if (dev != null)
            {
                return View("AddDev", dev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDev(Desenvolvedor dev)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedores.Update(dev);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("AddDev", dev);
            }
        }

        public IActionResult DelDev(int id)
        {
            Desenvolvedor dev = ctx.Desenvolvedores.Find(id);

            if (dev != null)
            {
                ctx.Desenvolvedores.Remove(dev);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
