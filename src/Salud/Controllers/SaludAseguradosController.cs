﻿using System;
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
using Salud.ViewModels;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Salud.Controllers
{
    public class SaludAseguradosController : Controller
    {
        [SessionExpire]
        public ActionResult Index()
        {

            var ASEGURADOS = LNSaludAsegurados.ObtenerSaludAsegurados("TODOS", "", "", "", "");
            ViewBag.Asegurados = ASEGURADOS;
            TempData["ASEGURADOS"] = ASEGURADOS;
            return View();
        }


        public ActionResult Afiliacion()
        {
            ENSaludContratos oENSaludContratos = null;
            VMSaludContratos oVMSaludContratos = null;
            //Prueba
            var VMContratos = new ENSaludContratos();
            var VMPlanes = new ENSaludPlanes();
            var VMListaPlanes = new List<ENSaludPlanes>();

            var oContratoViewModel = new VMSaludContratos
            {
                SaludContratosVM = VMContratos,
                SaludPlanesVM = VMPlanes,
                VMListaSaludPlanes = VMListaPlanes
            };

            string sCodigoCliente = "";
            oENSaludContratos = new ENSaludContratos();
            oVMSaludContratos = new VMSaludContratos();

            oContratoViewModel.SaludContratosVM.InicioVigencia = DateTime.Now;
            oContratoViewModel.SaludContratosVM.FinVigencia = oContratoViewModel.SaludContratosVM.InicioVigencia.AddYears(1);

            //oVMSaludContratos.SaludContratosVM.InicioVigencia= DateTime.Now;
            //oVMSaludContratos.SaludContratosVM.FinVigencia = oVMSaludContratos.SaludContratosVM.InicioVigencia.AddYears(1);

            oENSaludContratos.InicioVigencia = DateTime.Now; // valores default para nuevos
            oENSaludContratos.FinVigencia = oENSaludContratos.InicioVigencia.AddYears(1); // valores default para nuevos
                                                                                          //oENSaludContratos.FinVigencia = DateTime.Parse("31/12/2100"); // valores default para nuevos

            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            ViewBag.CodigoTipoContrato = new SelectList(LNTipoContrato.ObtenerTodos().ToList(), "CodigoTipoContrato", "DescripcionTipoContrato");
            ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor");
            ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo");
            ViewBag.SaludContratos = LNSaludContratos.ObtenerTodos(sCodigoCliente);
            return View();
        }


        [HttpGet]
        public ActionResult Crear(string idcliente = "", string idtitular = "", string idcategoria = "", string idcontrato = "")
        {
            if (idcliente != "" && idcontrato != "")
            {
                ViewBag.Cliente = idcliente;
                ViewBag.Contrato = idcontrato;
            }

            if (TempData["MensajeAgregarAFiliado"] != null)
            {
                ViewBag.MensajeAddAfiliado = TempData["MensajeAgregarAFiliado"];
                TempData["MensajeAgregarAFiliado"] = null;
            }

            if (idtitular != "")
            {
                TempData["CodigoTitular"] = idtitular;
            }
            else
            {
                TempData["CodigoTitular"] = null;
            }

            if (idcategoria != "")
            {
                TempData["Categoria"] = idcategoria;
            }


            ENSaludAsegurados oENSaludAsegurados = null;
            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            if (idtitular != "" && idcategoria != "" && idcliente != "")
            {
                oENSaludAsegurados = LNSaludAsegurados.ObtenerUno(idcliente, idtitular, idcategoria);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", oENSaludAsegurados.CodigoDpto);
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(oENSaludAsegurados.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", oENSaludAsegurados.CodigoProv);
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(oENSaludAsegurados.CodigoDpto, oENSaludAsegurados.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", oENSaludAsegurados.CodigoDist);
                ViewBag.CodigoParentesco = new SelectList(LNSaludParentesco.ObtenerTodos().ToList(), "CodigoParentesco", "DescripcionParentesco", oENSaludAsegurados.CodigoParentesco);
                ViewBag.CodigoVendedor = new SelectList(LNVendedores.ObtenerTodos().ToList(), "CodigoVendedor", "DescripcionVendedor", oENSaludAsegurados.CodigoVendedor);
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos("000494").ToList(), "CodigoCentroCosto", "DescripcionCentroCosto", oENSaludAsegurados.CodigoCentroCosto);
                ViewBag.CodigoSexo = new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo", oENSaludAsegurados.CodigoSexo);
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad", oENSaludAsegurados.CodigoDocumentoIdentidad);
                ViewBag.CodigoTipoTrabajador = new SelectList(LNTipoAsegurado.ObtenerTodos().ToList(), "CodigoTipoAsegurado", "DescripcionTipoAsegurado", oENSaludAsegurados.CodigoTipoTrabajador);
                ViewBag.CodigoPlan = new SelectList(LNSaludContratoPlan.ObtenerTodos(idcliente, idcontrato).ToList(), "CodigoPlanSC", "DescripcionPlanSC", oENSaludAsegurados.CodigoPlan);

                //ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludCentroCostos.CodigoCliente);
            }
            else
            {
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");

                if (idtitular != "")
                {
                    var parentescos = LNSaludParentesco.ObtenerTodos().Where(u => u.CodigoParentesco != "T");
                    ViewBag.CodigoParentesco = new SelectList(parentescos, "CodigoParentesco", "DescripcionParentesco");

                }
                else
                {
                    ENSaludParentesco paren = LNSaludParentesco.ObtenerTodos().Find(smodel => smodel.CodigoParentesco == "T");
                    ViewBag.CodigoParentesco = new SelectList(LNSaludParentesco.ObtenerTodos().ToList(), "CodigoParentesco", "DescripcionParentesco", paren.CodigoParentesco);
                }




                ViewBag.CodigoVendedor = new SelectList(LNVendedores.ObtenerTodos().ToList(), "CodigoVendedor", "DescripcionVendedor");
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos("000494").ToList(), "CodigoCentroCosto", "DescripcionCentroCosto");
                ViewBag.CodigoSexo = new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad");
                ViewBag.CodigoTipoTrabajador = new SelectList(LNTipoAsegurado.ObtenerTodos().ToList(), "CodigoTipoAsegurado", "DescripcionTipoAsegurado");
                ViewBag.CodigoPlan = new SelectList(LNSaludContratoPlan.ObtenerTodos(idcliente, idcontrato).ToList(), "CodigoPlanSC", "DescripcionPlanSC");

                oENSaludAsegurados = new ENSaludAsegurados();
            }
            return View(oENSaludAsegurados);
        }

        [HttpGet]
        public ActionResult Mantenimiento(string CodigoCLiente = "", string CodigoTitular = "", string CodigoContrato = "",string origen = "")
        {
            var VMContratos = new ENSaludContratos();
            var VMClientes = new ENClientes();
            var VMAsegurado = new ENSaludAsegurados();
            var VMAsegurados = new List<ENSaludAsegurados>();

            if (TempData["MensajeAgregarAFiliado"] != null)
            {
                ViewBag.MensajeAddAfiliado = TempData["MensajeAgregarAFiliado"];
                TempData["MensajeAgregarAFiliado"] = null;
            }

            if (CodigoTitular != "")
            {
                ViewBag.MuestraBtnDependiente = 1;
                ViewBag.CodigoTitular = CodigoTitular.ToString();
                ViewBag.CodigoCliente = CodigoCLiente.ToString();
                ViewBag.CodigoContratoID = CodigoContrato.ToString();
            }

            if (origen != "")
            {
                ViewBag.Origen = origen;
            }


            ENSaludContratos oENSaludContratos = null;
            ENClientes oENClientes = null;

            var oContratoViewModel = new VMAfiliacion
            {
                VMCliente = VMClientes,
                VMContrato = VMContratos,
                VMSaludAsegurado = VMAsegurado,
                VMSaludAsegurados = VMAsegurados
            };

            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados("GRUPOFAMILIAR", CodigoCLiente, CodigoTitular, "", CodigoContrato).ToList();
            ViewBag.Asegurados = listaAsegurados;


            oENClientes = LNClientes.ObtenerTodos().Find(smodel => smodel.CodigoCliente == CodigoCLiente);
            oENSaludContratos = LNSaludContratos.ObtenerTodos(CodigoCLiente).Find(smodel => smodel.CodigoContrato == CodigoContrato);
            ViewBag.CodigoContrato = new SelectList(LNSaludContratos.ObtenerTodos(CodigoCLiente).ToList(), "CodigoContrato", "CodigoContrato", oENSaludContratos.CodigoContrato);
            oContratoViewModel.VMCliente.CodigoCliente = oENClientes.CodigoCliente;
            oContratoViewModel.VMCliente.RazonSocial = oENClientes.RazonSocial;
            oContratoViewModel.VMCliente.RucDni = oENClientes.RucDni;
            oContratoViewModel.VMContrato.InicioVigencia = oENSaludContratos.InicioVigencia;
            oContratoViewModel.VMContrato.FinVigencia = oENSaludContratos.FinVigencia;
            return View(oContratoViewModel);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Guardar(ENSaludAsegurados asegurado, string registrar, string editar)
        {          
            var format = "yyyy-MM-dd";
            //------------------------
             var fecnac = asegurado.FechaNacimiento.ToString("yyyy-MM-dd").Split('-');
            var anio = Convert.ToInt32(fecnac[0]);
            var mes = Convert.ToInt32(fecnac[1]);
            var dia = Convert.ToInt32(fecnac[2]);
            DateTime fecnacFormat = new DateTime(anio, mes, dia);
            var fechaformateada = fecnacFormat.ToString("yyyy-MM-dd");
            var fechaNacimiento = DateTime.ParseExact(fechaformateada, format, CultureInfo.InvariantCulture);
            //------------------------
            var ini = DateTime.Now.ToString("yyyy-MM-dd");
            var ini2 = DateTime.ParseExact(ini, format, CultureInfo.InvariantCulture);

            ENSaludAsegurados obj = new ENSaludAsegurados()
            {
                CodigoCliente = asegurado.CodigoCliente,
                CodigoTitular = asegurado.CodigoTitular,
                Categoria = asegurado.Categoria,
                CodigoContrato = asegurado.CodigoContrato,
                CodigoPlan = asegurado.CodigoPlan,
                CodigoTrabajador = asegurado.CodigoTrabajador,
                CodigoTipoTrabajador = asegurado.CodigoTrabajador,//verificar
                ApellidoPaterno = asegurado.ApellidoPaterno,
                ApellidoMaterno = asegurado.ApellidoMaterno,
                Nombres = asegurado.Nombres,
                CodigoSexo = asegurado.CodigoSexo,
                FechaNacimiento = fechaNacimiento,
                CodigoDocumentoIdentidad = asegurado.CodigoDocumentoIdentidad,
                NumeroDocumentoIdentidad = asegurado.NumeroDocumentoIdentidad,
                InicioVigencia = ini2,
                FinVigencia = ini2,
                CodigoCentroCosto = asegurado.CodigoCentroCosto,
                CodigoParentesco = asegurado.CodigoParentesco,
                Talla = asegurado.Talla,
                Peso = asegurado.Peso,
                CodigoProv = asegurado.CodigoProv,
                CodigoDist = asegurado.CodigoDist,
                CodigoDpto = asegurado.CodigoDpto,
                CodigoMedico = "0",
                FechaIniAdscrip = ini2,
                PreExistCodigos = "",
                PreExistOtros = "",
                AppUserCodigo = "CROJAS",
                Telefono = asegurado.Telefono,
                Direccion = asegurado.Direccion,
                Celular = asegurado.Celular,
                Email = asegurado.Email,
                CodigoPlanOriginal = asegurado.CodigoPlan,
                FechaInicioLatencia = ini2,
                FechaFinLatencia = ini2,
                FechaAlta = ini2,
                FechaBaja = ini2,
                FechaEmisionCarnet = ini2,
                FechaReemisionCarnet = ini2,
                RegAddDate = ini2,
                RegEdtDate = ini2
            };

            string resultado = "";

            if (!string.IsNullOrEmpty(registrar))
            {
                //Insertar Asegurado
                if (asegurado.CodigoParentesco == "C" || asegurado.CodigoParentesco == "M" || asegurado.CodigoParentesco == "P")
                {
                    var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados("DEPENDIENTES", asegurado.CodigoCliente, asegurado.CodigoTitular, asegurado.Categoria, asegurado.CodigoContrato).ToList();
                    
                    if (listaAsegurados.Count > 0)
                    {
                        List<ENSaludAsegurados> listado = listaAsegurados.ToList();
                        var parentescotxt = listado[0].DescripcionParentesco;
                        TempData["MensajeAgregarAFiliado"] = "AVISO : El tipo de afiliado "+ parentescotxt.ToString() +" ya existe en el grupo familiar.";
                        return RedirectToAction("Crear", new { idcliente = asegurado.CodigoCliente, idtitular = asegurado.CodigoTitular, idcategoria = "", idcontrato = asegurado.CodigoContrato });
                    }
                }

                resultado = LNSaludAsegurados.Insertar(obj,"insertar");
            }
            if (!string.IsNullOrEmpty(editar))
            {
                //Edicion Asegurado
                resultado = LNSaludAsegurados.Insertar(obj,"editar");
            }
           
            string[] resultados = { };
            resultados = resultado.Split('-');

            if (resultados[0] == "1")
            {
                TempData["MensajeAgregarAFiliado"] = "CORRECTO : Los datos del asegurado han sido registrados";
                return RedirectToAction("Mantenimiento", new { CodigoCLiente = obj.CodigoCliente, CodigoTitular = resultados[1].ToString(), CodigoContrato = obj.CodigoContrato });
            }
            else
            {
                TempData["MensajeAgregarAFiliado"] = "AVISO : " + resultados[0].ToString();
                return RedirectToAction("Crear", new { idcliente = obj.CodigoCliente, idtitular = obj.CodigoTitular, idcategoria = obj.Categoria, idcontrato = obj.CodigoContrato });
            }
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
                LNSaludAsegurados.Insertar(asegurado,"insertar");
            }
            return null;
        }

        //############################
        //MYG
        //############################
        [SessionExpire]
        [HttpGet]
        public ActionResult getSaludAsegurados(string tipoConsulta, string codCliente, string codTitular, string codDependiente, string codContrato)
        {

            ENSaludContratos contrato = new ENSaludContratos();
            contrato = LNSaludContratos.ObtenerUno(codCliente, codContrato);

            var inicioVigencia = (contrato.InicioVigencia == null ? DateTime.Now : contrato.InicioVigencia);
            var finVigencia = (contrato.FinVigencia == null ? DateTime.Now : contrato.FinVigencia);
            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(tipoConsulta, codCliente, codTitular, codDependiente, codContrato).ToList();

            object[] variables = { inicioVigencia, finVigencia, listaAsegurados };
            //var json = new JavaScriptSerializer().Serialize(variables);

            return Json(variables, JsonRequestBehavior.AllowGet);


        }

        [SessionExpire]
        [HttpGet]
        public ActionResult getSoloAsegurados(string tipoConsulta, string codCliente, string codTitular, string codDependiente, string codContrato)
        {
            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(tipoConsulta, codCliente, codTitular, codDependiente, codContrato)
                .ToList()
                .Select(i => new
                {
                    i.CodigoCliente,
                    i.Categoria,
                    i.CodigoTipoTrabajador,
                    i.DescripcionParentesco,
                    i.ApellidosNombres,
                    i.Edad,
                    i.FechaAlta,
                    i.FechaBaja,
                    i.CodigoUbigeo,
                    i.Estado
                });
            return Json(listaAsegurados, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}