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
    public class ProjetosController : Controller
    {
        private GerenciaContext ctx;

        public ProjetosController(GerenciaContext ctx)
        {
            this.ctx = ctx;

            Desenvolvedor dev = ctx.Desenvolvedores.Find(1);
        }

        public IActionResult Index()
        {
            ViewBag.Projetos = ctx.Projetos;

            return View();
        }

        public IActionResult New()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult New(Projeto proj)
        {
            if (ModelState.IsValid)
            {
                ctx.Projetos.Add(proj);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", proj);
            }
        }

        public IActionResult Edit(int id)
        {
            Projeto proj = ctx.Projetos.Find(id);

            if (proj != null)
            {
                return View("Form", proj);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Projeto proj)
        {
            if (ModelState.IsValid)
            {
                ctx.Projetos.Update(proj);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", proj);
            }
        }

        public IActionResult Del(int id)
        {
            Projeto proj = ctx.Projetos.Find(id);

            if (proj != null)
            {
                ctx.Projetos.Remove(proj);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}