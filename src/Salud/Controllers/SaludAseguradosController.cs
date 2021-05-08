using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;
using System.Runtime.Caching;
using System.Configuration;

namespace Salud.Controllers
{
    public class SaludAseguradosController : Controller
    {
        [SessionExpire]
        public ActionResult Index()
        {
            //ViewBag.SaludAsegurados = LNSaludAsegurados.ObtenerTodos();
            return View();
        }

        [HttpGet]
        public ActionResult Crear(string idcliente = "", string idtitular = "", string idcategoria = "")
        {
            ENSaludAsegurados oENSaludAsegurados = null;
            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            if (idtitular != "" || idcategoria != "" || idcliente != "")
            {
                oENSaludAsegurados = LNSaludAsegurados.ObtenerUno(idcliente,idtitular,idcategoria);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", oENSaludAsegurados.CodigoDpto);
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(oENSaludAsegurados.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", oENSaludAsegurados.CodigoProv);
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(oENSaludAsegurados.CodigoDpto, oENSaludAsegurados.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", oENSaludAsegurados.CodigoDist);
                ViewBag.CodigoParentesco = new SelectList(LNSaludParentesco.ObtenerTodos().ToList(), "CodigoParentesco", "DescripcionParentesco", oENSaludAsegurados.CodigoParentesco);
                ViewBag.CodigoVendedor = new SelectList(LNVendedores.ObtenerTodos().ToList(), "CodigoVendedor", "DescripcionVendedor", oENSaludAsegurados.CodigoVendedor);
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos("000494").ToList(), "CodigoCentroCosto", "DescripcionCentroCosto", oENSaludAsegurados.CodigoCentroCosto);
                ViewBag.CodigoSexo = new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo", oENSaludAsegurados.CodigoSexo);
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad", oENSaludAsegurados.CodigoDocumentoIdentidad);
                ViewBag.CodigoTipoTrabajador = new SelectList(LNTipoAsegurado.ObtenerTodos().ToList(), "CodigoTipoAsegurado", "DescripcionTipoAsegurado", oENSaludAsegurados.CodigoTipoTrabajador);


                //ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludCentroCostos.CodigoCliente);
            }
            else
            {
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoParentesco = new SelectList(LNSaludParentesco.ObtenerTodos().ToList(), "CodigoParentesco", "DescripcionParentesco");
                ViewBag.CodigoVendedor = new SelectList(LNVendedores.ObtenerTodos().ToList(), "CodigoVendedor", "DescripcionVendedor");
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos("000494").ToList(), "CodigoCentroCosto", "DescripcionCentroCosto");
                ViewBag.CodigoSexo = new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad");
                ViewBag.CodigoTipoTrabajador = new SelectList(LNTipoAsegurado.ObtenerTodos().ToList(), "CodigoTipoAsegurado", "DescripcionTipoAsegurado");

                oENSaludAsegurados = new ENSaludAsegurados();
            }
            return View(oENSaludAsegurados);
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ENSaludAsegurados asegurado)
        {
            if (ModelState.IsValid)
            {
                if (asegurado.CodigoTitular != null || asegurado.Categoria != null || asegurado.CodigoCliente != null)
                {
                    LNSaludAsegurados.Actualizar(asegurado);
                }
                else
                {
                    LNSaludAsegurados.Insertar(asegurado);
                }
                return RedirectToAction("Index", "SaludAsegurados");
            }
            return View();
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Eliminar(int Id)
        {
            if (ModelState.IsValid)
            {
                LNCanales.Eliminar(Id);
                return RedirectToAction("Index", "Canales");
            }
            return View();
        }

        #region RequestsStructures
        public class AseguradoRequest
        {
            #region Asegurados
            public int Page { get; set; }
            public string Keywords { get; set; }
            public bool IsValidForList { get { return (Page > 0); } }
            #endregion

            #region Asegurado
            public string IdCliente { get; set; }
            public string IdTitular { get; set; }
            public string IdCategoria { get; set; }
            public bool IsValidForOne { get { return ((IdCliente != null) && (IdTitular != null) && (IdCategoria != null)); } }
            #endregion
        }
        #endregion

        #region AjaxMethods
        ObjectCache cache = MemoryCache.Default;
        [SessionExpire]
        [HttpGet]
        public ActionResult GetAsegurados(AseguradoRequest aseguradoRequest = null)
        {
            if (aseguradoRequest != null || aseguradoRequest.IsValidForList)
            {
                if (!int.TryParse(ConfigurationManager.AppSettings["RowsPerPage"], out int rowsPerPage)) rowsPerPage = 0;
                var listaAsegurados = LNSaludAsegurados.ObtenerTodos(aseguradoRequest.Page, rowsPerPage, aseguradoRequest.Keywords).ToList();
                return Json(listaAsegurados, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public ActionResult GetAsegurado(AseguradoRequest aseguradoRequest = null)
        {
            if (aseguradoRequest != null && aseguradoRequest.IsValidForOne)
            {
                var asegurados = LNSaludAsegurados.ObtenerUno(aseguradoRequest.IdCliente, aseguradoRequest.IdTitular, aseguradoRequest.IdCategoria);
                return Json(asegurados, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public ActionResult GetCantidad(AseguradoRequest aseguradoRequest = null)
        {
            if (aseguradoRequest != null && aseguradoRequest.IsValidForList)
            {
                if (!int.TryParse(ConfigurationManager.AppSettings["RowsPerPage"], out int rowsPerPage)) rowsPerPage = 0;
                if (!int.TryParse(ConfigurationManager.AppSettings["PagesPerCatalog"], out int pagesPerCatalog)) pagesPerCatalog = 0;
                int totalRows = LNSaludAsegurados.Cantidad(aseguradoRequest.Keywords);
                return Json(new { totalRows, rowsPerPage, pagesPerCatalog }, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult GetDepartamentos()
        {
            var listaDepartamentos = LNUbigeoDpto.ObtenerDpto().ToList();
            return Json(listaDepartamentos, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult GetProvincias(string dptoid)
        {
            var listaProvincias = LNUbigeoProv.ObtenerProv(dptoid).ToList();
            return Json(listaProvincias, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult GetDistritos(string dptoid, string provid)
        {
            var listaDistritos = LNUbigeoDist.ObtenerDist(dptoid, provid).ToList();
            return Json(listaDistritos, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpGet]
        public ActionResult CreateAsegurado(AseguradoRequest aseguradoRequest = null, ENSaludAsegurados asegurado = null)
        {
            if (aseguradoRequest.IdTitular != null || aseguradoRequest.IdCategoria != null || aseguradoRequest.IdCliente != null)
            {
                LNSaludAsegurados.Actualizar(asegurado);
            }
            else
            {
                LNSaludAsegurados.Insertar(asegurado);
            }
            return null;
        }
        #endregion
    }
}