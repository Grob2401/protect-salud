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
    public class CentroCostosController : Controller
    {
        // GET: CentroCostos
        [SessionExpire]
        public ActionResult Index(int page = 0)
         {

            if (TempData["MensajeCentroCosto"] != null)
            {
                ViewBag.MensajeCentroCosto = TempData["MensajeCentroCosto"];
                ViewData["MensajeCentroCosto"] = TempData["MensajeCentroCosto"];
                //TempData["MensajeCentroCosto"] = null;

            }

            var contador = LNSaludCentroCostos.Cantidad("");
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

            //ViewBag.CentroCostos = LNSaludCentroCostos.ObtenerTodos(sCodigoCliente);
            ViewBag.CentroCostos = LNSaludCentroCostos.ObtenerTodos(page, 100, "", "","").OrderBy(x => x.RowNumber).ToList();
            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Index(int page = 0, string txtBusquedaAsegurados = "")
        {

            var contador = LNSaludCentroCostos.Cantidad("");
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

            var CENTROCOSTOS = LNSaludCentroCostos.ObtenerTodos(1, 100, "", txtBusquedaAsegurados,"");
            ViewBag.CentroCostos = CENTROCOSTOS;
            TempData["CENTROCOSTOS"] = CENTROCOSTOS;
            return View();
        }

        [SessionExpire]
        [HttpGet]
        public ActionResult Crear(string id = "", string idcliente = "")

        {
            //string idcliente = "";
            ENSaludCentroCostos oENSaludCentroCostos = null;
            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            if (id != "")
            {
                
                oENSaludCentroCostos = LNSaludCentroCostos.ObtenerUno(idcliente, id);
                ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludCentroCostos.CodigoCliente);
            }
            else
            {
                oENSaludCentroCostos = new ENSaludCentroCostos();
            }
            return View(oENSaludCentroCostos);
        }

        [SessionExpire]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Crear(ENSaludCentroCostos centrocosto)
        {
            if (ModelState.IsValid)
            {
                if (centrocosto.CodigoCentroCosto != null)
                {

                    LNSaludCentroCostos.Actualizar(centrocosto);
                    TempData["MensajeCentroCosto"] = "Excelente, El centro de costo fue actualizado.";
                }
                else
                {
                    LNSaludCentroCostos.Insertar(centrocosto);
                    TempData["MensajeCentroCosto"] = "Excelente, El centro de costo fue agregado.";
                }
                return RedirectToAction("Index", "CentroCostos");
            }
            return View();
        }

        [SessionExpire]
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Eliminar( string idcliente = "", string idCentro = "")
        {
            //string idcliente = "";

            if (ModelState.IsValid)
            {
                LNSaludCentroCostos.Eliminar(idcliente, idCentro);
                string mensaje  = "Excelente, El centro de costo fue eliminado.";
                //return RedirectToAction("Index", "CentroCostos");
                //return RedirectToAction("Index", "CentroCostos");
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


        [SessionExpire]
        //[HttpGet]
        public ActionResult CrearC(string idcliente)

        {
            ENSaludCentroCostos oENSaludCentroCostos = null;
            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            if (idcliente != "")
            {
                ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", idcliente);
            }
            else
            {
                oENSaludCentroCostos = new ENSaludCentroCostos();
            }
            return PartialView("Crear");
        }


    }
}