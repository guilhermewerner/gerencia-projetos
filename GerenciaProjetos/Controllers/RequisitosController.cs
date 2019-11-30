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
    public class RequisitosController : Controller
    {
        private GerenciaContext ctx;

        public RequisitosController(GerenciaContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Requisitos = ctx.Requisitos;

            return View();
        }

        public IActionResult New()
        {
            ViewData["Title"] = "Novo";

            ViewBag.Projetos = ctx.Projetos.OrderBy(p => p.Nome).Select(p => new SelectListItem
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            });

            return View("Form");
        }

        [HttpPost]
        public IActionResult New(Requisito req)
        {
            if (ModelState.IsValid)
            {
                req.DataCadastro = DateTime.Now;

                ctx.Requisitos.Add(req);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", req);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar";

            ViewBag.Projetos = ctx.Projetos.OrderBy(p => p.Nome).Select(p => new SelectListItem
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            });

            Requisito req = ctx.Requisitos.Find(id);

            if (req != null)
            {
                return View("Form", req);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Requisito req)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(req).Property(r => r.EFuncional).IsModified = true;
                ctx.Entry(req).Property(r => r.DataEntrega).IsModified = true;
                ctx.Entry(req).Property(r => r.Descricao).IsModified = true;
                ctx.Entry(req).Property(r => r.Observacoes).IsModified = true;
                ctx.Entry(req).Property(r => r.ProjetoId).IsModified = true;
                ctx.Entry(req).Property(r => r.DataEntrega).IsModified = true;

                ctx.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Form", req);
            }
        }

        public IActionResult Del(int id)
        {
            Requisito req = ctx.Requisitos.Find(id);

            if (req != null)
            {
                ctx.Requisitos.Remove(req);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}