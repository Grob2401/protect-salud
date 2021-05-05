using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;
using System.Reflection;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Runtime.Caching;
using System.Web.SessionState;

namespace Salud.Controllers
{
    public class PreFacturacionController : Controller
    {

        // GET: SCTRCotizacion
        private LNUbigeoDpto LNUbigeoDpto = new LNUbigeoDpto();
        private LNUbigeoProv LNUbigeoProv = new LNUbigeoProv();
        private LNUbigeoDist LNUbigeoDist = new LNUbigeoDist();
        private LNSCTRCotizacionesDetalle LNSCTRCotizacionesDetalle = new LNSCTRCotizacionesDetalle();
        private ENDatosEmitir oEnDatosEmitir = new ENDatosEmitir();
        public string v_empresaruc = "";
        public string v_empresanombre = "";
        public string v_codigocotizacion = "";

        public string v_codigocliente = "";
        public double v_detmontoplanillaadm = 0;
        public double v_detmontoplanillaope = 0;
        public string v_codigocentrocosto = "";
        public string v_descripcioncentrocosto = "";

        ObjectCache cache = MemoryCache.Default;
        [SessionExpire]
        public ActionResult Index()
        {
            if (TempData["PREFAC"] != null)
            {
                ViewBag.PreFacturaciones = TempData["PREFAC"];
            }

            if (TempData["GENERAR"] != null)
            {
                ViewBag.generar = TempData["GENERAR"];
            }

            if (TempData["CONTRATOS"] != null)
            {
                ViewBag.Contratos = TempData["CONTRATOS"];
            }

            ENDatosPreFacBusqueda enf1 = new ENDatosPreFacBusqueda();
            if (TempData["MODEL"] != null)
            {
                enf1 = (ENDatosPreFacBusqueda)TempData["MODEL"];
            }

            return View(enf1);
        }

        [HttpGet]
        public ActionResult Buscar(ENDatosPreFacBusqueda enf)
        {

            enf.option = 0;

            if (TempData["GENERAR"] != null)
            {
                ViewBag.generar = TempData["GENERAR"];
            }

            TempData["MODEL"] = enf;
            TempData["PREFAC"] = LNPreFacturaciones.ObtenerTodos(enf);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Detalle(string anoProceso = " ",
                                    string mesProceso = " ",
                                    string pcsEspecial = " ",
                                    string pcsStatus = " ",
                                    string CodigoCliente = " ",
                                    string DescripcionTipoAsegurado = " ")
        {

            TempData["CONTRATOS"] = LNPreFacturaciones.Contratos(anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            return Json(TempData["CONTRATOS"], JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Generar(string anoProceso = " ",
                            string mesProceso = " ",
                            string txtdesde = " ",
                            string txthasta = " ",
                            string pcsEspecial = " ",
                            string pcsStatus = " ",
                            string CodigoCliente = " ",
                            string DescripcionTipoAsegurado = " ")
        {

            ENDatosPreFacBusqueda enf = new ENDatosPreFacBusqueda() { 
                
                anio = anoProceso,
                mes = mesProceso,
                txtdesde = txtdesde,
                txthasta = txthasta

            };

            TempData["GENERAR"] = LNPreFacturaciones.Actualizar (anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            return Json(TempData["GENERAR"], JsonRequestBehavior.AllowGet);
        }


        //// GET: PreFacturacion
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}