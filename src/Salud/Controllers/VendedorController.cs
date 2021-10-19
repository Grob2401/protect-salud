using Entidades;
using LogicaNegocio;
using Salud.App_Start;
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

            if (TempData["Seleccion"] != null)
            {
                ViewData["Seleccion"] = TempData["Seleccion"];
                Session["Seleccion"] = TempData["Seleccion"];
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

            if (TempData["Vendedores"] != null)
            {
                ViewData["Vendedores"] = TempData["Vendedores"];
            }
            else
            {
                var lstVendedores = LNVendedor.ObtenerTodos("0");
                ViewData["Vendedores"] = lstVendedores;
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetLista(string slcSociedad, string mensaje)
        {
            var lstVendedores = LNVendedor.ObtenerTodos(slcSociedad);
            TempData["Vendedores"] = lstVendedores;
            TempData["Seleccion"] = slcSociedad;
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
            //return Json(new { data = lstVendedores.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public ActionResult Mantenimiento(ENVendedores pla)
        {
            var valor = 0;
            if (pla.CodigoVendedor is null)
            {
                if (LNVendedor.Insertar(pla))
                {
                    valor = pla.IdSociedad;
                    ModelState.Clear();
                    TempData["Seleccion"] = valor;
                    TempData["mensaje"] = "Vendedor registrado";
                }
                return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Vendedor registrado" });
                //return Json(new { pla, message = "Vendedor registrado" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (LNVendedor.Actualizar(pla))
                {
                    valor = pla.IdSociedad;
                    ModelState.Clear();
                    TempData["Seleccion"] = valor;
                    TempData["mensaje"] = "Vendedor modificado";
                }
                return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Vendedor modificado" });
                //return Json(new { pla, message = "Vendedor modificado" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult MantenimientoComision(ENVendedores vcomision)
        {
            var valor = "";
            if (LNVendedor.InsertarComision(vcomision))
            {
                valor = Session["Seleccion"].ToString();
                ModelState.Clear();
            }
            return RedirectToAction("GetLista", new { slcSociedad = valor, mensaje = "Comisión Asignada" });
        }

        [HttpPost]
        public ActionResult Eliminar(string id)
        {
            try
            {
                if (LNVendedor.Eliminar(id))
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

        [HttpGet]
        public ActionResult Asignacion(string slcSociedad)
        {

            if (TempData["Seleccion"] != null)
            {
                ViewData["Seleccion"] = TempData["Seleccion"];
            }
            else
            {
                ViewData["Seleccion"] = Session["SociedadUsuario"];
            }

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial", ViewData["Seleccion"]);
            TempData["ListaSociedades"] = lstSociedades_;

            if (TempData["Vendedores"] != null)
            {
                ViewData["Vendedores"] = TempData["Vendedores"];
            }
            else
            {
                var lstVendedores = LNVendedor.ObtenerTodos("0");
                ViewData["Vendedores"] = lstVendedores;
            }

            if (TempData["Asignados"] != null)
            {
                ViewData["Asignados"] = TempData["Asignados"];
            }
            else
            {
                var lstVendedoresAsignados = LNVendedor.ObtenerAsignados("0");
                ViewData["Asignados"] = lstVendedoresAsignados;
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetVendedoresSinAsignar(string slcSociedad)
        {
            var lstVendedores = LNVendedor.ObtenerTodos(slcSociedad);
            var lstVendedoresAsignados = LNVendedor.ObtenerAsignados(slcSociedad);
            TempData["Vendedores"] = lstVendedores;
            TempData["Asignados"] = lstVendedoresAsignados;
            return RedirectToAction("Asignacion", new { slcSociedad = slcSociedad });
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Asignar(ENCanalesVendedores en)
        {
            var valor = 0;
            if (LNVendedor.Asignar(en))
            {
                valor = en.CV_IDCanal;
                ModelState.Clear();
            }
            return RedirectToAction("GetVendedoresSinAsignar", new { slcSociedad = en.CV_IdSociedad.ToString() });
        }
    }
}