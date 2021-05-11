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
    public class CanalController : Controller
    {
        private LNCanales LNCanales = new LNCanales();
        private LNSociedades LNSociedades = new LNSociedades();
        public ActionResult Index()
        {
            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial");
            ViewData["ListaSociedades"] = lstSociedades_;

            if (TempData["Canales"] != null)
            {
                ViewData["Canales"] = TempData["Canales"];
            }

            return View();
        }


        [HttpGet]
        public ActionResult GetLista(String slcSociedad = "")
        {
            //var lstCanales = LNCanal.ObtenerTodos();
            //return Json(new { data = lstCanales.ToList() }, JsonRequestBehavior.AllowGet);

            var lstCanales = LNCanal.ObtenerTodos();
            TempData["Canales"] = lstCanales;
            return RedirectToAction("Index");
        }     
    }
}