using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salud.Controllers
{
    public class VendedorController : Controller
    {
        private LNVendedores LNVendedores = new LNVendedores();
        private LNSociedades LNSociedades = new LNSociedades();
        // GET: Vendedor
        public ActionResult Index()
        {

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial");
            ViewData["ListaSociedades"] = lstSociedades_;

            if (TempData["Vendedores"] != null)
            {
                ViewData["Vendedores"] = TempData["Vendedores"];
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetLista(String slcSociedad = "")
        {
            var lstVendedores = LNVendedor.ObtenerTodos(slcSociedad);
            TempData["Vendedores"] = lstVendedores;
            return RedirectToAction("Index");
            //return Json(new { data = lstVendedores.ToList() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Mantenimiento(ENVendedores pla)
        {
            if (pla.CodigoVendedor is null)
            {
                if (LNVendedor.Insertar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return RedirectToAction("GetLista");
                //return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (LNVendedores.Actualizar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return RedirectToAction("GetLista");
                //return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Asignacion()
        {

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial");
            ViewData["ListaSociedades"] = lstSociedades_;

            var lstCanales = LNCanal.ObtenerTodos();
            var lstCanales_ = new SelectList(lstCanales.ToList(), "IdCanal", "DescripcionCanal");
            ViewData["ListaCanales"] = lstCanales_;

            if (TempData["Vendedores"] != null)
            {
                ViewData["Vendedores"] = TempData["Vendedores"];
            }

            return View();
        }

    }
}