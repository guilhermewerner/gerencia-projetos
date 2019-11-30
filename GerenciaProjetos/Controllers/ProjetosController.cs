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
        }

        public IActionResult Index()
        {
            ViewBag.Projetos = ctx.Projetos;

            return View();
        }

        public IActionResult New()
        {
            ViewData["Title"] = "Novo";

            return View("Form");
        }

        [HttpPost]
        public IActionResult New(Projeto proj)
        {
            if (ModelState.IsValid)
            {
                ctx.Projetos.Add(proj);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", proj);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar";

            Projeto proj = ctx.Projetos.Find(id);

            if (proj != null)
            {
                return View("Form", proj);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
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

                return RedirectToAction("Index", "Dashboard");
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

            return RedirectToAction("Index", "Dashboard");
        }
    }
}