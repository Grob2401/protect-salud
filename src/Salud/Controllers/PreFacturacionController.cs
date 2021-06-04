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

            if (TempData["mensaje"] != null)
            {
                TempData["mensaje"] = TempData["mensaje"];
            }

            return View(enf1);
        }

        [HttpGet]
        public ActionResult Buscar(string anio, string mes, string txtdesde, string txthasta,string mensaje,string status)
        {
            if (TempData["GENERAR"] != null)
            {
                ViewBag.generar = TempData["GENERAR"];
            }

            if (status == null )
            {
                status = "";
            }

            ENDatosPreFacBusqueda enf = new ENDatosPreFacBusqueda()
            {

                anio = anio,
                mes = mes,
                txtdesde = txtdesde,
                txthasta = txthasta,
                option = 0,
                mensajeEPF = mensaje,
                PcsStatus = status
            };

            TempData["MODEL"] = enf;
            TempData["PREFAC"] = LNPreFacturaciones.ObtenerTodos(enf);

            if (enf.mensajeEPF != null)
            {
                TempData["mensaje"] = enf.mensajeEPF;
            }

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

        [HttpPost]
        public ActionResult Generar(string anoProceso = " ",
                            string mesProceso = " ",
                            string txtdesde = " ",
                            string txthasta = " ",
                            string pcsEspecial = " ",
                            string pcsStatus = " ",
                            string CodigoCliente = " ",
                            string DescripcionTipoAsegurado = " ")
        {

            ENDatosPreFacBusqueda enf1 = new ENDatosPreFacBusqueda() { 
                
                anio = anoProceso,
                mes = mesProceso,
                txtdesde = txtdesde,
                txthasta = txthasta,
                mensajeEPF = "Registros generados",
                PcsStatus = "1"

            };

            TempData["GENERAR"] = LNPreFacturaciones.Generar(anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            return Json(enf1, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Buscar", enf1);
        }

        [HttpPost]
        public ActionResult Aprobar(string anoProceso = " ",
                            string mesProceso = " ",
                            string txtdesde = " ",
                            string txthasta = " ",
                            string pcsEspecial = " ",
                            string pcsStatus = " ",
                            string CodigoCliente = " ",
                            string DescripcionTipoAsegurado = " ")
        {

            ENDatosPreFacBusqueda enf1 = new ENDatosPreFacBusqueda()
            {

                anio = anoProceso,
                mes = mesProceso,
                txtdesde = txtdesde,
                txthasta = txthasta,
                mensajeEPF = "Registros aprobados",
                PcsStatus = "2"

            };

            TempData["GENERAR"] = LNPreFacturaciones.Aprobar(anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            //return Json(TempData["GENERAR"], JsonRequestBehavior.AllowGet);
            return Json(enf1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ctaCorriente(string anoProceso = " ",
                            string mesProceso = " ",
                            string txtdesde = " ",
                            string txthasta = " ",
                            string pcsEspecial = " ",
                            string pcsStatus = " ",
                            string CodigoCliente = " ",
                            string DescripcionTipoAsegurado = " ")
        {

            ENDatosPreFacBusqueda enf1 = new ENDatosPreFacBusqueda()
            {

                anio = anoProceso,
                mes = mesProceso,
                txtdesde = txtdesde,
                txthasta = txthasta,
                mensajeEPF = "Registros generados con Cuenta Corriente",
                PcsStatus = "3"

            };

            TempData["GENERAR"] = LNPreFacturaciones.ctaCorriente(anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            //return Json(TempData["GENERAR"], JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Buscar", new { enf = enf1, mensaje = "Registros generados con Cuenta Corriente" });
            return Json(enf1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Facturar(string anoProceso = " ",
                            string mesProceso = " ",
                            string txtdesde = " ",
                            string txthasta = " ",
                            string pcsEspecial = " ",
                            string pcsStatus = " ",
                            string CodigoCliente = " ",
                            string DescripcionTipoAsegurado = " ")
        {

            ENDatosPreFacBusqueda enf1 = new ENDatosPreFacBusqueda()
            {

                anio = anoProceso,
                mes = mesProceso,
                txtdesde = txtdesde,
                txthasta = txthasta,
                mensajeEPF = "Registros Facturados",
                PcsStatus = "4"

            };

            TempData["GENERAR"] = LNPreFacturaciones.Facturar(anoProceso, mesProceso, pcsEspecial, pcsStatus, CodigoCliente, DescripcionTipoAsegurado);
            //return Json(TempData["GENERAR"], JsonRequestBehavior.AllowGet);
            return Json(enf1, JsonRequestBehavior.AllowGet);
        }


        //// GET: PreFacturacion
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}