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
        public ActionResult Index()
        {
            string sCodigoCliente = "";
            ViewBag.CentroCostos = LNSaludCentroCostos.ObtenerTodos(sCodigoCliente);
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
                }
                else
                {
                    LNSaludCentroCostos.Insertar(centrocosto);
                }
                return RedirectToAction("Index", "CentroCostos");
            }
            return View();
        }

        [SessionExpire]
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Eliminar(string id = "", string idcliente = "")
        {
            //string idcliente = "";

            if (ModelState.IsValid)
            {
                LNSaludCentroCostos.Eliminar(idcliente, id);
                return RedirectToAction("Index", "CentroCostos");
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