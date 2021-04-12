using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;

namespace Salud.Controllers
{
    public class CanalesController : Controller
    {
        //private LNCanales LNCanales = new LNCanales();
        //private LNSociedades LNSociedades = new LNSociedades();

        [SessionExpire]
        public ActionResult Index()
            {
                ViewBag.Canales = LNCanales.ObtenerTodos();
                return View();
            }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)

        {
            ENCanales oENCanales = null;
            ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial");
            if (id > 0)
            {
                oENCanales = LNCanales.ObtenerUno(id);
                ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", oENCanales.IdSociedad);
            }
            else
            {
                oENCanales = new ENCanales();
            }
            return View(oENCanales);
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(ENCanales canal)
        {
            if (ModelState.IsValid)
            {
                if (canal.IDCanal > 0)
                {
                    LNCanales.Actualizar(canal);
                }
                else
                {
                    LNCanales.Insertar(canal);
                }
                return RedirectToAction("Index", "Canales");
            }
            return View();
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Eliminar(int  Id)
        {
            if (ModelState.IsValid)
            {
                LNCanales.Eliminar(Id);
                return RedirectToAction("Index", "Canales");
            }
            return View();
        }
    }
}