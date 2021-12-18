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
        [SessionExpire]
        public ActionResult Index(int page = 0)
        {

            var contador = LNVendedor.Cantidad(Session["SociedadUsuario"].ToString());
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


            if (Session["SociedadUsuario"] != null)
            {
                var sociedadSesion = Session["SociedadUsuario"];
                var lstVendedores = LNVendedor.ObtenerTodos(page, 100, "", "", sociedadSesion.ToString());
                ViewData["Vendedores"] = lstVendedores;
            }
            else
            {
                var lstVendedores = LNVendedor.ObtenerTodos(page, 100, "", "", "0");
                ViewData["Vendedores"] = lstVendedores;
            }

            //if (TempData["Vendedores"] != null)
            //{
            //    ViewData["Vendedores"] = TempData["Vendedores"];
            //}
            //else
            //{
                
                

            //}

            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Index(int page = 0, string txtBusquedaVendedor = "", string mensaje = "")
        {
            var contador = LNVendedor.Cantidad(Session["SociedadUsuario"].ToString());
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
                var lstVendedores = LNVendedor.ObtenerTodos(1, 100, "", txtBusquedaVendedor, sociedadSesion.ToString());
                ViewData["Vendedores"] = lstVendedores;
                //TempData["Vendedores"] = lstVendedores;
            }
            else
            {
                var lstVendedores = LNVendedor.ObtenerTodos(1, 100, "", txtBusquedaVendedor, "0");
                ViewData["Vendedores"] = lstVendedores;
                //TempData["Vendedores"] = lstVendedores;
            }

            TempData["Seleccion"] = Session["SociedadUsuario"];
            TempData["mensaje"] = mensaje;
            return View();

        }

        [HttpGet]
        public ActionResult Mantenimiento(ENVendedores pla)
        {
            var valor = 0;
            if (pla.CodigoVendedor is null)
            {
                if (LNVendedor.Insertar(pla))
                {
                    valor = pla.IdSociedad;
                    ModelState.Clear();
                    TempData["Seleccion"] = Session["SociedadUsuario"].ToString();
                    TempData["mensaje"] = "Vendedor registrado";
                }
                return RedirectToAction("Index", new { mensaje = "Vendedor registrado" });
                //return RedirectToAction("GetLista", new { mensaje = "Vendedor registrado" });
                //return Json(new { pla, message = "Vendedor registrado" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (LNVendedor.Actualizar(pla))
                {
                    valor = pla.IdSociedad;
                    ModelState.Clear();
                    TempData["Seleccion"] = Session["SociedadUsuario"].ToString();
                    TempData["mensaje"] = "Vendedor modificado";
                }
                return RedirectToAction("Index", new { mensaje = "Vendedor modificado" });
                //return RedirectToAction("GetLista", new { mensaje = "Vendedor modificado" });
                //return Json(new { pla, message = "Vendedor modificado" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult MantenimientoComision(ENVendedores vcomision)
        {
            var valor = "";
            if (LNVendedor.InsertarComision(vcomision))
            {

                if (ViewData["Seleccion"] != null)
                {
                    valor = ViewData["Seleccion"].ToString();
                }
                else
                {
                    valor = Session["SociedadUsuario"].ToString();
                }
                
                ModelState.Clear();
            }
            return RedirectToAction("Index", new { mensaje = "Comisión Asignada" });
            //return RedirectToAction("GetLista", new {mensaje = "Comisión Asignada" });
        }

        [HttpPost]
        public ActionResult Eliminar(string id)
        {
            try
            {
                if (LNVendedor.Eliminar(id))
                {
                    var mensaje = "Excelente, Vendedor eliminado.";
                    return Json(mensaje, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var mensaje = "Error";
                    return Json(mensaje, JsonRequestBehavior.AllowGet);
                }
                return View();
            }
            catch (Exception ex)
            {
                var mensaje = "Error, el vendedor tiene asignado un canal o pertenece a un contrato vigente.";
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Asignacion(int page = 0)
        {


            if (page != 0)
            {
                ViewData["pageCount"] = page;
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

            var lstSociedades = LNSociedades.ObtenerTodos();
            var lstSociedades_ = new SelectList(lstSociedades.ToList(), "IdSociedad", "RazonSocial", ViewData["Seleccion"]);
            TempData["ListaSociedades"] = lstSociedades_;

            if (TempData["Vendedores"] != null)
            {
                ViewData["Vendedores"] = TempData["Vendedores"];
            }
            else
            {


                if (Session["SociedadUsuario"] != null)
                {
                    var lstVendedores = LNVendedor.ObtenerTodos(page, 100, "", "", Session["SociedadUsuario"].ToString());
                    ViewData["Vendedores"] = lstVendedores;
                }
                else
                {
                    var lstVendedores = LNVendedor.ObtenerTodos(page, 100, "", "", "0");
                    ViewData["Vendedores"] = lstVendedores;
                }

            }

            if (TempData["Asignados"] != null)
            {
                ViewData["Asignados"] = TempData["Asignados"];
            }
            else
            {

                if (Session["SociedadUsuario"] != null)
                {
                    var sociedadSesion = Session["SociedadUsuario"];
                    var lstVendedoresAsignados = LNVendedor.ObtenerAsignados(sociedadSesion.ToString());
                    ViewData["Asignados"] = lstVendedoresAsignados;
                }
                else
                {
                    var lstVendedoresAsignados = LNVendedor.ObtenerAsignados("0");
                    ViewData["Asignados"] = lstVendedoresAsignados;
                }


                
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetVendedoresSinAsignar(string slcSociedad)
        {
            var lstVendedores = LNVendedor.ObtenerTodos(Session["SociedadUsuario"].ToString());
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