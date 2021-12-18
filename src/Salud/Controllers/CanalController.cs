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
        public ActionResult Index(int page = 0)
        {

            var contador = LNCanal.Cantidad(Session["SociedadUsuario"].ToString());
            ViewData["todos"] = contador;
            ViewData["ultimo"] = contador / 100;

            if (page != 0)
            {
                if (page < (contador / 100))
                {
                    ViewData["pageCount"] = page;
                }
                else
                {
                    ViewData["pageCount"] = contador / 100;
                }
            }

            if (ViewData["pageCount"] == null && page == 0)
            {
                ViewData["pageCount"] = 1;
                page = 1;
            }


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
                    var lstCanales = LNCanal.ObtenerTodos(page,100,"","",sociedadSesion.ToString());
                    ViewData["Canales"] = lstCanales;
                }
                else
                {
                    var lstCanales = LNCanal.ObtenerTodos(page, 100, "", "","0");
                    ViewData["Canales"] = lstCanales;
                }
                
            }

            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Index(int page = 0,string txtBusquedaCanal = "", string mensaje = "")
        {

            var contador = LNCanal.Cantidad(Session["SociedadUsuario"].ToString());
            ViewData["todos"] = contador;
            ViewData["ultimo"] = contador / 100;

            if (page != 0)
            {
                if (page < (contador / 100))
                {
                    ViewData["pageCount"] = page;
                }
                else
                {
                    ViewData["pageCount"] = contador / 100;
                }
            }

            if (ViewData["pageCount"] == null && page == 0)
            {
                ViewData["pageCount"] = 1;
                page = 1;
            }

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial", Session["SociedadUsuario"].ToString());
            ViewData["ListaSociedades"] = lstSociedades_;

            var lstTiposComision = LNTipoComision.ObtenerTodos();
            var lstTiposComision_ = new SelectList(lstTiposComision.ToList(), "IdTipoComision", "DescripcionTipoComision", Session["SociedadUsuario"].ToString());
            ViewData["ListaTipoComision"] = lstTiposComision_;

            if (Session["SociedadUsuario"] != null)
            {
                var sociedadSesion = Session["SociedadUsuario"];
                var lstCanales = LNCanal.ObtenerTodos(1, 100, "", txtBusquedaCanal, sociedadSesion.ToString());
                ViewData["Canales"] = lstCanales;
                //TempData["Vendedores"] = lstVendedores;
            }
            else
            {
                var lstCanales = LNCanal.ObtenerTodos(1, 100, "", txtBusquedaCanal, "0");
                ViewData["Canales"] = lstCanales;
                //TempData["Vendedores"] = lstVendedores;
            }

            TempData["Seleccion"] = Session["SociedadUsuario"];
            TempData["mensaje"] = mensaje;
            return View();
        }

        //[HttpGet]
        //public ActionResult GetLista(string slcSociedad, string mensaje)
        //{
        //    var lstCanales = LNCanal.ObtenerTodos(slcSociedad);
        //    TempData["Canales"] = lstCanales;
        //    TempData["Seleccion"] = slcSociedad;
        //    TempData["mensaje"] = mensaje;
        //    return RedirectToAction("Index");
        //}

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
                return RedirectToAction("Index", new { mensaje = "Canal modificado" });
            }
            else
            {
                if (LNCanal.Insertar(canal))
                {
                    valor = canal.IdSociedad;
                    ModelState.Clear();
                }
                return RedirectToAction("Index", new { mensaje = "Canal registrado" });

            }
        }

        [HttpGet]
        public ActionResult MantenimientoComision(ENCanales vcomision,string slcSociedad)
        {
            var valor = ""; 
            if (LNCanal.InsertarComision(vcomision))
            {
                valor = Session["SociedadUsuario"].ToString();
                ModelState.Clear();
            }
            return RedirectToAction("Index", new { mensaje = "Comisión Asignada" });
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                if (LNCanal.Eliminar(Id))
                {
                    var mensaje = "Excelente, Canal eliminado.";
                    return Json(mensaje, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var mensaje = "Error";
                    return Json(mensaje, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                var mensaje = "Error, El Canal asignado tiene comisiones vigentes.";
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            }           
            
        }


    }
}