using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciaProjetos.Models;
using GerenciaContext = GerenciaProjetos.Data.GerenciaContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciaProjetos.Controllers
{
    public class BugsController : Controller
    {
        private GerenciaContext ctx;

        public BugsController(GerenciaContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Bugs = ctx.Bugs;

            return View();
        }

        public IActionResult New()
        {
            ViewData["Title"] = "Novo";

            ViewBag.Desenvolvedores = ctx.Desenvolvedores.OrderBy(d => d.Nome).Select(d => new SelectListItem
            {
                Text = d.Nome,
                Value = d.Id.ToString()
            });

            ViewBag.Requisitos = ctx.Requisitos.OrderBy(r => r.Descricao).Select(r => new SelectListItem
            {
                Text = r.Descricao,
                Value = r.Id.ToString()
            });

            return View("Form");
        }

        [HttpPost]
        public IActionResult New(Bug bug)
        {
            if (ModelState.IsValid)
            {
                bug.DataCadastro = DateTime.Now;

                ctx.Bugs.Add(bug);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", bug);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar";

            ViewBag.Desenvolvedores = ctx.Desenvolvedores.OrderBy(d => d.Nome).Select(d => new SelectListItem
            {
                Text = d.Nome,
                Value = d.Id.ToString()
            });

            ViewBag.Requisitos = ctx.Requisitos.OrderBy(r => r.Descricao).Select(r => new SelectListItem
            {
                Text = r.Descricao,
                Value = r.Id.ToString()
            });

            Bug bug = ctx.Bugs.Find(id);

            if (bug != null)
            {
                return View("Form", bug);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bug bug)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(bug).Property(r => r.DesenvolvedorId).IsModified = true;
                ctx.Entry(bug).Property(r => r.RequisitoId).IsModified = true;
                ctx.Entry(bug).Property(r => r.FoiResolvido).IsModified = true;
                ctx.Entry(bug).Property(r => r.Descricao).IsModified = true;
                ctx.Entry(bug).Property(r => r.Prioridade).IsModified = true;
                
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Form", bug);
            }
        }

        public IActionResult Del(int id)
        {
            Bug bug = ctx.Bugs.Find(id);

            if (bug != null)
            {
                ctx.Bugs.Remove(bug);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}