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
                ViewBag.y = TempData["Y"];
                ViewBag.m = TempData["M"];
            }

            if (TempData["CONTRATOS"] != null)
            {
                ViewBag.Contratos = TempData["CONTRATOS"];
            }

            return View();
        }

        [HttpGet]
        public ActionResult Buscar(string anios = " ", string meses = " ", string fechadesde = " ", string fechahasta = " ", string option = " ")
        {
            var f1 = "";
            var f2 = "";
            var op = "0";

            if (fechadesde != "" && fechahasta != "")
            {
                f1 = fechadesde.Replace("-", "");
                f2 = fechahasta.Replace("-", "");
                op = "0";
            }

            TempData["Y"] = anios;
            TempData["M"] = meses;
            TempData["PREFAC"] = LNPreFacturaciones.ObtenerTodos(anios, meses, f1, f2, op);
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


        //// GET: PreFacturacion
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}