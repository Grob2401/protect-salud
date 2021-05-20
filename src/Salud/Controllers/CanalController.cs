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

            if (TempData["Seleccion"] != null)
            {
                ViewData["Seleccion"] = TempData["Seleccion"];
            }

            if (TempData["mensaje"] != null)
            {
                TempData["mensaje"] = TempData["mensaje"];
            }

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial", ViewData["Seleccion"]);
            ViewData["ListaSociedades"] = lstSociedades_;

            if (TempData["Canales"] != null)
            {
                ViewData["Canales"] = TempData["Canales"];
            }

            return View();
        }


        [HttpGet]
        public ActionResult GetLista(string slcSociedad, string mensaje)
        {
            var lstCanales = LNCanal.ObtenerTodos(slcSociedad);
            TempData["Canales"] = lstCanales;
            TempData["Seleccion"] = slcSociedad;
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetListaJSON(string slcSociedad)
        {
            var lstCanales = LNCanal.ObtenerTodos(slcSociedad);
            TempData["CanalesJSON"] = new SelectList(lstCanales.ToList(), "IDCanal", "DescripcionCanal");          
            return Json(TempData["CanalesJSON"], JsonRequestBehavior.AllowGet);
        }


        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mantenimiento(ENCanales canal)
        {
            var valor = 0;
            if (canal.IDCanal > 0)
            {
                if (LNCanal.Actualizar(canal))
                {
                    valor = canal.IdSociedad;
                    ModelState.Clear();
                }
                return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Canal modificado" });
            }
            else
            {
                if (LNCanal.Insertar(canal))
                {
                    valor = canal.IdSociedad;
                    ModelState.Clear();
                }
                return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Canal registrado" });

            }           
        }

        [SessionExpire]
        [HttpPost]

        public ActionResult Eliminar(int Id)
        {
            try
            {
                if (LNCanal.Eliminar(Id))
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