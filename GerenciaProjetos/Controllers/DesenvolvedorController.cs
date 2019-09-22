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
    public class DesenvolvedorController : Controller
    {
        private GerenciaContext ctx;

        public DesenvolvedorController(GerenciaContext ctx)
        {
            this.ctx = ctx;

            Desenvolvedor dev = ctx.Desenvolvedores.Find(1);
        }

        public IActionResult Index()
        {
            ViewBag.Desenvolvedores = ctx.Desenvolvedores;
            
            return View();
        }

        public IActionResult New()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult New(Desenvolvedor dev)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedores.Add(dev);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", dev);
            }
        }

        public IActionResult Edit(int id)
        {
            Desenvolvedor dev = ctx.Desenvolvedores.Find(id);

            if (dev != null)
            {
                return View("Form", dev);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Desenvolvedor dev)
        {
            if (ModelState.IsValid)
            {
                ctx.Desenvolvedores.Update(dev);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", dev);
            }
        }

        public IActionResult Del(int id)
        {
            Desenvolvedor dev = ctx.Desenvolvedores.Find(id);

            if (dev != null)
            {
                ctx.Desenvolvedores.Remove(dev);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}