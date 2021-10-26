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
            else
            {
                ViewData["Seleccion"] = Session["SociedadUsuario"];
            }

            if (TempData["mensaje"] != null)
            {
                TempData["mensaje"] = TempData["mensaje"];
            }

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial", ViewData["Seleccion"]);
            ViewData["ListaSociedades"] = lstSociedades_;

            var lstTiposComision = LNTipoComision.ObtenerTodos();
            var lstTiposComision_ = new SelectList(lstTiposComision.ToList(), "IdTipoComision", "DescripcionTipoComision");
            ViewData["ListaTipoComision"] = lstTiposComision_;

            if (TempData["Canales"] != null)
            {
                ViewData["Canales"] = TempData["Canales"];
            }
            else
            {
                if (Session["SociedadUsuario"] != null)
                {
                    var sociedadSesion = Session["SociedadUsuario"];
                    var lstCanales = LNCanal.ObtenerTodos(sociedadSesion.ToString());
                    ViewData["Canales"] = lstCanales;
                }
                else
                {
                    var lstCanales = LNCanal.ObtenerTodos("0");
                    ViewData["Canales"] = lstCanales;
                }
                
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

        [HttpGet]
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

        [HttpGet]
        public ActionResult MantenimientoComision(ENCanales vcomision,string slcSociedad)
        {
            var valor = "";
            if (LNCanal.InsertarComision(vcomision))
            {
                valor = slcSociedad;
                ModelState.Clear();
            }
            return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Comisión Asignada" });
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