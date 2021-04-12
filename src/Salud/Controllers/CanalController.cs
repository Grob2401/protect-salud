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
            return View();
        }

        public ActionResult GetLista()
        {
            var lstCanales = LNCanales.ObtenerTodos();
            return Json(new { data = lstCanales.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial");
                var ENCanales = new ENCanales();
                return View(ENCanales);
            }
            else
            {
                ENCanales mCanalEditar = LNCanales.ObtenerTodos().Find(smodel => smodel.IDCanal == id);
                ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", mCanalEditar.IdSociedad);
                return View(mCanalEditar);
            }
        }

        public ActionResult AddOrEdit(ENCanales pla)
        {
            if (pla.IDCanal == 0)
            {
                if (LNCanales.Insertar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (LNCanales.Actualizar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (LNCanales.Eliminar(id))
                {
                    return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
    }
}