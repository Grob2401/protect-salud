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
    //[HandleError(View="Error") ]
    public class SCTRCotizacionController : Controller
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
            ViewBag.SCTRCotizacion = LNSCTRCotizaciones.ObtenerTodos();
            return View();
        }
        [SessionExpire]
        public ActionResult Crear(string id = "")
        {
            ENSCTRCotizaciones oENSCTRCotizaciones = null;
            if (id != "")
            {
                oENSCTRCotizaciones = LNSCTRCotizaciones.ObtenerUnoConDetalle(id);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", oENSCTRCotizaciones.CodigoDpto);
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(oENSCTRCotizaciones.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", oENSCTRCotizaciones.CodigoProv);
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(oENSCTRCotizaciones.CodigoDpto, oENSCTRCotizaciones.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", oENSCTRCotizaciones.CodigoDist);
                ViewBag.CodigoDptoR = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", oENSCTRCotizaciones.CodigoDpto);
                ViewBag.CodigoProvR = new SelectList(LNUbigeoProv.ObtenerProv(oENSCTRCotizaciones.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", oENSCTRCotizaciones.CodigoProv);
                ViewBag.CodigoDistR = new SelectList(LNUbigeoDist.ObtenerDist(oENSCTRCotizaciones.CodigoDpto, oENSCTRCotizaciones.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", oENSCTRCotizaciones.CodigoDist);
                ViewBag.GrupoCIIU = new SelectList(LNCIIUPrincipal.ObtenerCIIUPrincipal().ToList(), "CodigoCIIU", "DescripcionCIIU", oENSCTRCotizaciones.GrupoCIIU);
                ViewBag.CodigoCIIU = new SelectList(LNCIIUEspecifica.ObtenerCIIUEspecifica(oENSCTRCotizaciones.GrupoCIIU).ToList(), "CodigoCIIU", "DescripcionCIIU", oENSCTRCotizaciones.CodigoCIIU);
                ViewBag.CodigoMoneda = new SelectList(LNMonedas.ObtenerTodos().ToList(), "CodigoMoneda", "DescripcionMoneda", oENSCTRCotizaciones.CodigoMoneda);
                //Guardar Codigo Cliente para Emisión
                System.Web.HttpContext.Current.Session["codigocliente"] = oENSCTRCotizaciones.CodigoCliente;
            }
            else
            {
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoDptoR = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProvR = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDistR = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.GrupoCIIU = new SelectList(LNCIIUPrincipal.ObtenerCIIUPrincipal().ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoCIIU = new SelectList(LNCIIUEspecifica.ObtenerCIIUEspecifica("17120").ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoMoneda = new SelectList(LNMonedas.ObtenerTodos().ToList(), "CodigoMoneda", "DescripcionMoneda");
                oENSCTRCotizaciones = new ENSCTRCotizaciones();
                oENSCTRCotizaciones.dtm_FechaInicio = DateTime.Now; // valores default para nuevos
                oENSCTRCotizaciones.dtm_FechaFin = DateTime.Parse("31/12/2021"); // valores default para nuevos
                //Solo Para pruebas
                oENSCTRCotizaciones.EmpresaRUC = "20508863475";
                oENSCTRCotizaciones.EmpresaNombre = "GLINFOSAC";
                oENSCTRCotizaciones.Direccion = "SANTA CRUZ 376";
                oENSCTRCotizaciones.DetMontoPlanillaAdm = 20000;
                oENSCTRCotizaciones.DetMontoPlanillaOpe = 15000;
                oENSCTRCotizaciones.DetNumeroTrabajadoresAdm = 20;
                oENSCTRCotizaciones.DetNumeroTrabajadoresOpe = 15;
            }
            return View(oENSCTRCotizaciones);

        }


        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ENSCTRCotizaciones cotizacion, string BotonCotizar, string BotonGrabar)
        {
            ENSCTRCotizaciones oENSCTRCotizaciones = null;
            oENSCTRCotizaciones = new ENSCTRCotizaciones();
            if (ModelState.IsValid)
            {
                if (BotonCotizar != null)
                {
                    oENSCTRCotizaciones = Cotizar2(cotizacion);
                }
                if (BotonGrabar != null)
                {
                    if (cotizacion.CodigoCotizacion != null)
                    {
                        LNSCTRCotizaciones.Actualizar(cotizacion);
                        oENSCTRCotizaciones = cotizacion;
                        //return View(cotizacion);
                    }
                    else
                    {
                        LNSCTRCotizaciones.Insertar(cotizacion);
                        oENSCTRCotizaciones = cotizacion;
                        //return View(cotizacion);
                    }
                    return RedirectToAction("Index", "SCTRCotizacion");
                } //aqui
            }
            return View(oENSCTRCotizaciones);
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string id = "")
        {
            if (ModelState.IsValid)
            {
                LNSCTRCotizaciones.Eliminar(id);
                return RedirectToAction("Index", "SCTRCotizacion");
            }
            return View();
        }

        [SessionExpire]
        public ActionResult Cotizar(ENSCTRCotizaciones cotizacion)
        {
            ENSCTRCotizaciones oENSCTRCotizaciones = null;

            if (ModelState.IsValid)
            {
                LNSCTRCotizaciones.Cotizar(cotizacion);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDpto, cotizacion.CodigoProv).ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoDptoR = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProvR = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDptoR).ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDistR = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDptoR, cotizacion.CodigoProvR).ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.GrupoCIIU = new SelectList(LNCIIUPrincipal.ObtenerCIIUPrincipal().ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoCIIU = new SelectList(LNCIIUEspecifica.ObtenerCIIUEspecifica(cotizacion.GrupoCIIU).ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoMoneda = new SelectList(LNMonedas.ObtenerTodos().ToList(), "CodigoMoneda", "DescripcionMoneda");
                oENSCTRCotizaciones = new ENSCTRCotizaciones();
                // Traer datos de cotizacion y copiar en oENSCTRCotizaciones
                //Obteniendo propiedades de la clase - declarando lista
                PropertyInfo[] lstProp = typeof(ENSCTRCotizaciones).GetProperties();
                foreach (PropertyInfo oProperty in lstProp)
                {
                    string NombreAtributo = oProperty.Name;
                    string Tipo = oProperty.PropertyType.Name.ToString();

                    var val1 = cotizacion.GetType().GetProperty(NombreAtributo).GetValue(cotizacion, null);

                    if (val1 != null)
                    {

                        if (Tipo == "Int32")
                        {
                            int valor = Convert.ToInt32(oProperty.GetValue(cotizacion));
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "String")
                        {
                            string valor = oProperty.GetValue(cotizacion).ToString();
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "DateTime")
                        {
                            DateTime valor = DateTime.Parse(oProperty.GetValue(cotizacion).ToString());
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "Double")
                        {
                            Double valor = Convert.ToDouble(oProperty.GetValue(cotizacion));
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                    }
                }
            }
            return Json(oENSCTRCotizaciones, JsonRequestBehavior.AllowGet);
        }

        public ENSCTRCotizaciones Cotizar2(ENSCTRCotizaciones cotizacion)
        {
            ENSCTRCotizaciones oENSCTRCotizaciones = null;
            if (ModelState.IsValid)
            {
                LNSCTRCotizaciones.Cotizar(cotizacion);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDpto, cotizacion.CodigoProv).ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoDptoR = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProvR = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDptoR).ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDistR = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDptoR, cotizacion.CodigoProvR).ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.GrupoCIIU = new SelectList(LNCIIUPrincipal.ObtenerCIIUPrincipal().ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoCIIU = new SelectList(LNCIIUEspecifica.ObtenerCIIUEspecifica(cotizacion.GrupoCIIU).ToList(), "CodigoCIIU", "DescripcionCIIU");
                ViewBag.CodigoMoneda = new SelectList(LNMonedas.ObtenerTodos().ToList(), "CodigoMoneda", "DescripcionMoneda");
                oENSCTRCotizaciones = new ENSCTRCotizaciones();
                // Traer datos de cotizacion y copiar en oENSCTRCotizaciones
                //Obteniendo propiedades de la clase - declarando lista
                PropertyInfo[] lstProp = typeof(ENSCTRCotizaciones).GetProperties();
                foreach (PropertyInfo oProperty in lstProp)
                {
                    string NombreAtributo = oProperty.Name;
                    string Tipo = oProperty.PropertyType.Name.ToString();

                    var val1 = cotizacion.GetType().GetProperty(NombreAtributo).GetValue(cotizacion, null);

                    if (val1 != null)
                    {

                        if (Tipo == "Int32")
                        {
                            int valor = Convert.ToInt32(oProperty.GetValue(cotizacion));
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "String")
                        {
                            string valor = oProperty.GetValue(cotizacion).ToString();
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "DateTime")
                        {
                            DateTime valor = DateTime.Parse(oProperty.GetValue(cotizacion).ToString());
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                        if (Tipo == "Double")
                        {
                            Double valor = Convert.ToDouble(oProperty.GetValue(cotizacion));
                            oProperty.SetValue(oENSCTRCotizaciones, valor);
                        }
                    }
                }
            }
            // return View(oENSCTRCotizaciones);
            //return View(cotizacion);
            return (oENSCTRCotizaciones);
        }

        #region AjaxMethods
        [SessionExpire]
        [HttpPost]
        public ActionResult GetParentesco()
        {
            var listaParentescos = LNSaludParentesco.ObtenerTodos().ToList();
            if (ModelState.IsValid)
            {
                return Json(listaParentescos, JsonRequestBehavior.AllowGet);
            }
            return Json(listaParentescos, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetVendedor()
        {
            var listaVendedores = LNVendedores.ObtenerTodos().ToList();
            if (ModelState.IsValid)
            {
                return Json(listaVendedores, JsonRequestBehavior.AllowGet);
            }
            return Json(listaVendedores, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetDocumentoIdentidad()
        {
            var listaDocumentosIdentidad = LNTipoDocumentoIdentidad.ObtenerTodos().ToList();
            if (ModelState.IsValid)
            {
                return Json(listaDocumentosIdentidad, JsonRequestBehavior.AllowGet);
            }
            return Json(listaDocumentosIdentidad, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetSexo()
        {
            var listaSexos = LNSaludSexo.ObtenerTodos().ToList();
            if (ModelState.IsValid)
            {
                return Json(listaSexos, JsonRequestBehavior.AllowGet);
            }
            return Json(listaSexos, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetDepartamento()
        {
            var listaDepartamentos = LNUbigeoDpto.ObtenerDpto().ToList();
            if (ModelState.IsValid)
            {
                return Json(listaDepartamentos, JsonRequestBehavior.AllowGet);
            }
            return Json(listaDepartamentos, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetProvincia(string dptoid)
        {
            var listaProvincias = LNUbigeoProv.ObtenerProv(dptoid).ToList();
            if (ModelState.IsValid)
            {
                return Json(listaProvincias, JsonRequestBehavior.AllowGet);
            }
            return Json(listaProvincias, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult GetDistrito(string dptoid, string provid)
        {
            var listaDistritos = LNUbigeoDist.ObtenerDist(dptoid, provid).ToList();
            if (ModelState.IsValid)
            {
                return Json(listaDistritos, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [SessionExpire]
        [HttpPost]
        //[ValidateAntiForgeryToken] Se quitó porque da error
        public ActionResult GetCIIUEspecifica(string grupoid)
        {
            var lista = LNCIIUEspecifica.ObtenerCIIUEspecifica(grupoid).ToList();
            if (ModelState.IsValid)
            {
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        //[ValidateAntiForgeryToken] Se quitó porque da error
        public ActionResult GetCentroCosto(string codigocliente)
        {
            var lista = LNSaludCentroCostos.ObtenerTodos(codigocliente).ToList();
            if (ModelState.IsValid)
            {
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        [SessionExpire]
        [HttpPost]
        public ActionResult GetCotizacionDetalle(string cotizacionid, string item)
        {
            var lista = LNSCTRCotizaciones.ObtenerUnoConDetalle(cotizacionid);
            if (ModelState.IsValid)
            {
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [SessionExpire]
        public JsonResult Cotizar1(string empresaruc, string empresanombre, string codigocorredor, string codigociiu, double montooperativos, int numerooperativos, double montoadministrativos, int numeroadministrativos, string codigomoneda, DateTime fechainicio, DateTime fechafin, int tiempocobertura, double porcentajetasa, double porcentajecorredor, string numerocotizacion, string usuario, string ubigeoriesgo, string codigodpto, string codigoprov, string codigodist, string codigodptor, string codigoprovr, string codigodistr, string grupociiu)
        {
            ENSCTRCotizaciones cotizacion = new ENSCTRCotizaciones();
            cotizacion.EmpresaRUC = empresaruc;
            cotizacion.EmpresaNombre = empresanombre;
            cotizacion.CodigoCIIU = codigociiu;
            cotizacion.DetMontoPlanillaOpe = montooperativos;
            cotizacion.DetNumeroTrabajadoresOpe = numerooperativos;
            cotizacion.DetMontoPlanillaAdm = montoadministrativos;
            cotizacion.DetNumeroTrabajadoresAdm = numeroadministrativos;
            cotizacion.CodigoMoneda = codigomoneda;
            cotizacion.FechaInicio = String.Format("{0:yyyyMMdd}", fechainicio);
            cotizacion.FechaFin = String.Format("{0:yyyyMMdd}", fechafin);
            cotizacion.TiempoCobertura = tiempocobertura;
            cotizacion.PorcentajeTasa = porcentajetasa;
            cotizacion.CodigoUsuarioRegistro = usuario;
            cotizacion.UbigeoRiesgo = ubigeoriesgo;
            cotizacion.CodigoDpto = codigodpto;
            cotizacion.CodigoDptoR = codigodptor;
            cotizacion.CodigoProv = codigoprov;
            cotizacion.CodigoProvR = codigoprovr;
            cotizacion.CodigoDist = codigodist;
            cotizacion.CodigoDistR = codigodistr;
            cotizacion.GrupoCIIU = grupociiu;

            LNSCTRCotizaciones.Cotizar(cotizacion);
            ENRespuestaCotizacion eNRespuestaCotizacion = new ENRespuestaCotizacion();

            eNRespuestaCotizacion.ImportePrimaNeta = Math.Truncate(cotizacion.ImportePrimaNeta * 100) / 100;
            eNRespuestaCotizacion.ImporteIGV = Math.Truncate(cotizacion.ImporteIGV * 100) / 100;
            eNRespuestaCotizacion.ImportePrimaTotal = Math.Truncate(cotizacion.ImportePrimaTotal * 100) / 100;
            eNRespuestaCotizacion.ImporteDerechoEmision = Math.Truncate(cotizacion.ImporteDerechoEmision * 100) / 100;
            eNRespuestaCotizacion.PorcentajeCorredor = Math.Truncate(cotizacion.PorcentajeCorredor * 100) / 100;
            eNRespuestaCotizacion.PorcentajeTasa = Math.Truncate(cotizacion.PorcentajeTasa * 100) / 100;
            if (ModelState.IsValid)
            {
                return Json(eNRespuestaCotizacion, JsonRequestBehavior.AllowGet);
            }
            return Json(eNRespuestaCotizacion, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ValidaRuc(string empresaruc)
        {
            var lista = LNClientes.ObtenerUnoporRUC(empresaruc);
            //ENClientes oEnClientes = new ENClientes();
            //oEnClientes.RucDni = rucid;
            if (ModelState.IsValid)
            {
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)

            {
                v_codigocotizacion = System.Web.HttpContext.Current.Session["codigocotizacion"].ToString();
                v_empresanombre = System.Web.HttpContext.Current.Session["empresanombre"].ToString();
                v_empresaruc = System.Web.HttpContext.Current.Session["empresaruc"].ToString();
                v_codigocliente = System.Web.HttpContext.Current.Session["codigocliente"].ToString();
                v_detmontoplanillaadm = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaadm"]);
                v_detmontoplanillaope = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaope"]);
                v_codigocentrocosto = System.Web.HttpContext.Current.Session["codigocentrocosto"].ToString();
                v_descripcioncentrocosto = System.Web.HttpContext.Current.Session["descripcioncentrocosto"].ToString();
                ViewData["txtEmpresaRUC"] = v_empresaruc;
                ViewData["txtEmpresaNombre"] = v_empresanombre;
                ViewData["txtCodigoCotizacion"] = v_codigocotizacion;
                ViewData["txtCodigoCliente"] = v_codigocliente;
                ViewData["txtPlanillaMensual"] = v_detmontoplanillaadm + v_detmontoplanillaope;
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos(v_codigocliente).ToList(), "CodigoCentroCosto", "DescripcionCentroCosto", v_codigocentrocosto);
           
                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;
                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Formato de archivo incorrecto.");
                        return View();
                    }
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false
                        }
                    };
                    DataTable dt = new DataTable();

                    DataSet result = reader.AsDataSet();
                    DataSet resultordenado = new DataSet();//Data to be sorted.
                    //Sort data.
                    result.Tables[0].DefaultView.Sort = "Column5 ASC";
                    //Store in new Dataset
                    resultordenado.Tables.Add(result.Tables[0].DefaultView.ToTable());
                    string sMensaje ="" ;
                    dt = resultordenado.Tables[0];
                    dt.Columns["Column0"].ColumnName = "Nombres";
                    dt.Columns["Column1"].ColumnName = "Paterno";
                    dt.Columns["Column2"].ColumnName = "Materno";
                    dt.Columns["Column3"].ColumnName = "TipoTrab";
                    dt.Columns["Column4"].ColumnName = "TipoDoc";
                    dt.Columns["Column5"].ColumnName = "NroDoc";
                    dt.Columns["Column6"].ColumnName = "Sexo";
                    dt.Columns["Column7"].ColumnName = "EstadoCivil";
                    dt.Columns["Column8"].ColumnName = "Direccion";
                    dt.Columns["Column9"].ColumnName = "Telefono";
                    dt.Columns["Column10"].ColumnName = "FechaNac";
                    dt.Columns["Column11"].ColumnName = "Correo";
                    dt.Columns["Column12"].ColumnName = "Moneda";
                    dt.Columns["Column13"].ColumnName = "Sueldo";
                    dt.Columns["Column14"].ColumnName = "Estado";
                    int j = 0;
                    int k= 0;
                 

                    for (int i = 0; i < dt.Rows.Count-1; i++)
                    {
                        string datoNombres= dt.Rows[i]["Nombres"].ToString();
                        string datoPaterno = dt.Rows[i]["Paterno"].ToString();
                        string datoMaterno = dt.Rows[i]["Materno"].ToString();
                        string datoTipoTrab = dt.Rows[i]["TipoTrab"].ToString();
                        string datoTipoDoc = dt.Rows[i]["TipoDoc"].ToString();
                        string datoNroDoc = dt.Rows[i]["NroDoc"].ToString();

                        string datoNroDocAnt="";
                        if (i > 0) 
                        {
                             datoNroDocAnt = dt.Rows[i - 1]["NroDoc"].ToString();
                        }
                            DataRow dr = dt.Rows[i];
                        if (datoNombres == "Nombres" | datoPaterno == "Paterno")
                            {
                            dr.Delete();
                            dt.AcceptChanges();
                            }
                        if (datoNombres == "" | datoPaterno == "" | datoMaterno == "" | datoTipoTrab == "" | datoTipoDoc == "" | datoNroDoc == "")
                        {
                            dt.Rows[i]["Estado"] = "Error: Faltan Datos  ";
                            j = j + 1;
                        }
                        else if (datoNroDoc== datoNroDocAnt)
                            { dt.Rows[i]["Estado"] = "Error : NroDoc Duplicado";
                              dt.Rows[i-1]["Estado"] = "Error : NroDoc Duplicado";
                            k = k + 1;
                            }
                        else
                        { dt.Rows[i]["Estado"] = "Correcto"; }
                    }
                    reader.Close();
                    if (j == 0 & k == 0)
                    {
                        sMensaje = "Datos Correctos";
                    }
                    else
                    {
                        sMensaje = "Existen errores en los datos, corrija y vuelva a cargar el archivo";
                    }
                    ViewBag.Mensaje = sMensaje;
                    ViewBag.Message = sMensaje;
                    string v_key = "";
                    v_key= System.Web.HttpContext.Current.Session.SessionID.ToString() + "dtEmiteSCTR";
                    System.Web.HttpContext.Current.Cache[v_key] = dt;
                 
                    return View(dt); 
                }
                else
                {
                    ModelState.AddModelError("File", "Seleccione un archivo");
                }
            }

            //return View();
            return PartialView();
        }

        public ActionResult Upload(string empresaruc, string empresanombre, string codigocotizacion,string codigocliente,double detmontoplanillaadm, double detmontoplanillaope)
        {
            v_codigocliente = System.Web.HttpContext.Current.Session["codigocliente"].ToString();
            var lista = LNSaludCentroCostos.ObtenerTodos(v_codigocliente).ToList();
            ViewData["drpCentroCosto"] = new SelectList(lista, "CodigoCentroCosto", "DescripcionCentroCosto");
           
            ViewData["txtEmpresaRUC"] = empresaruc;
            ViewData["txtEmpresaNombre"] = empresanombre;
            ViewData["txtCodigoCotizacion"] = codigocotizacion;
            ViewData["txtCodigoCliente"] = codigocliente;
            ViewData["txtPlanillaMensual"] = detmontoplanillaadm + detmontoplanillaope;

            System.Web.HttpContext.Current.Session["empresaruc"] = empresaruc;
            System.Web.HttpContext.Current.Session["empresanombre"] = empresanombre;
            System.Web.HttpContext.Current.Session["codigocotizacion"] = codigocotizacion;
            System.Web.HttpContext.Current.Session["codigocliente"] = codigocliente;
            System.Web.HttpContext.Current.Session["detmontoplanillaadm"] = detmontoplanillaadm;
            System.Web.HttpContext.Current.Session["detmontoplanillaope"] = detmontoplanillaope;
            return View();
        }

        [HttpPost]
        public JsonResult SetSession(string codigocentrocosto, string descripcioncentrocosto)
        {
            System.Web.HttpContext.Current.Session["codigocentrocosto"] = codigocentrocosto;
            System.Web.HttpContext.Current.Session["descripcioncentrocosto"] = descripcioncentrocosto;
            return Json(codigocentrocosto);
        }

        [HttpGet]
        [SessionExpire]
        public ActionResult ProcesaEmision()
        {
            string[] ArExcel = new string[21];
            DataRow dr;
            DataTable dtEmision = new DataTable();
            bool sErrFila = false;
            List<ENDatosError> oListaError = new List<ENDatosError>();

            if (ModelState.IsValid)
            {



            dtEmision = (DataTable)System.Web.HttpContext.Current.Cache.Get(System.Web.HttpContext.Current.Session.SessionID.ToString() + "dtEmiteSCTR");
            v_codigocentrocosto = System.Web.HttpContext.Current.Session["codigocentrocosto"].ToString();
            v_descripcioncentrocosto = System.Web.HttpContext.Current.Session["descripcioncentrocosto"].ToString();
            v_codigocotizacion = System.Web.HttpContext.Current.Session["codigocotizacion"].ToString();
            //



            //

            for (int i= 0; i < dtEmision.Rows.Count - 1; i++)
            {
                dr = dtEmision.Rows[i];

                if (dtEmision.Columns.Count > 0)
                {
                    ArExcel[0] = dtEmision.Rows[i]["Nombres"].ToString();
                    ArExcel[1] = dtEmision.Rows[i]["Paterno"].ToString();
                    ArExcel[2] = dtEmision.Rows[i]["Materno"].ToString();
                    ArExcel[3] = dtEmision.Rows[i]["TipoTrab"].ToString();
                    ArExcel[4] = dtEmision.Rows[i]["TipoDoc"].ToString();
                    ArExcel[5] = dtEmision.Rows[i]["NroDoc"].ToString();
                    ArExcel[6] = dtEmision.Rows[i]["Sexo"].ToString();
                    ArExcel[7] = dtEmision.Rows[i]["EstadoCivil"].ToString();
                    ArExcel[8] = dtEmision.Rows[i]["Direccion"].ToString();
                    ArExcel[9] = dtEmision.Rows[i]["Telefono"].ToString();
                    ArExcel[10] = dtEmision.Rows[i]["FechaNac"].ToString();
                    ArExcel[11] = dtEmision.Rows[i]["Correo"].ToString();
                    ArExcel[12] = dtEmision.Rows[i]["Moneda"].ToString();
                    ArExcel[13] = dtEmision.Rows[i]["Sueldo"].ToString();
                    if (sErrFila)
                        ArExcel[14] = "E";
                    else
                        ArExcel[14] = " ";
                    ArExcel[15] = v_codigocentrocosto + "-" + v_descripcioncentrocosto;
                    ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal = null;
                    oENSCTR_EmisionTemporal = new ENSCTR_EmisionTemporal();
                    oENSCTR_EmisionTemporal.NumeroCotizacion = v_codigocotizacion;
                    oENSCTR_EmisionTemporal.C01 = dtEmision.Rows[i]["Nombres"].ToString();
                    oENSCTR_EmisionTemporal.C02 = dtEmision.Rows[i]["Paterno"].ToString();
                    oENSCTR_EmisionTemporal.C03 = dtEmision.Rows[i]["Materno"].ToString();
                    oENSCTR_EmisionTemporal.C04 = dtEmision.Rows[i]["TipoTrab"].ToString();
                    oENSCTR_EmisionTemporal.C05 = dtEmision.Rows[i]["TipoDoc"].ToString();
                    oENSCTR_EmisionTemporal.C06 = dtEmision.Rows[i]["NroDoc"].ToString();
                    oENSCTR_EmisionTemporal.C07 = dtEmision.Rows[i]["Sexo"].ToString();
                    oENSCTR_EmisionTemporal.C08 = dtEmision.Rows[i]["EstadoCivil"].ToString();
                    oENSCTR_EmisionTemporal.C09 = dtEmision.Rows[i]["Direccion"].ToString();
                    oENSCTR_EmisionTemporal.C10 = dtEmision.Rows[i]["Telefono"].ToString();
                    oENSCTR_EmisionTemporal.C11 = dtEmision.Rows[i]["FechaNac"].ToString();
                    oENSCTR_EmisionTemporal.C12 = dtEmision.Rows[i]["Correo"].ToString();
                    oENSCTR_EmisionTemporal.C13 = dtEmision.Rows[i]["Moneda"].ToString();
                    oENSCTR_EmisionTemporal.C14 = dtEmision.Rows[i]["Sueldo"].ToString();
                    oENSCTR_EmisionTemporal.C15 = ArExcel[14];
                    oENSCTR_EmisionTemporal.C16 = ArExcel[15];
                    //var listaResultado = LNSCTR_EmisionTemporal.ListaSCTREmitirIndividual(oENSCTR_EmisionTemporal).ToList();
                     oListaError = LNSCTR_EmisionTemporal.ListaSCTREmitirIndividual(oENSCTR_EmisionTemporal).ToList();
                    }

            }

        }
           
            v_codigocotizacion = System.Web.HttpContext.Current.Session["codigocotizacion"].ToString();
            v_empresanombre = System.Web.HttpContext.Current.Session["empresanombre"].ToString();
            v_empresaruc = System.Web.HttpContext.Current.Session["empresaruc"].ToString();
            v_codigocliente = System.Web.HttpContext.Current.Session["codigocliente"].ToString();
            v_detmontoplanillaadm = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaadm"]);
            v_detmontoplanillaope = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaope"]);
            v_codigocentrocosto = System.Web.HttpContext.Current.Session["codigocentrocosto"].ToString();
            v_descripcioncentrocosto = System.Web.HttpContext.Current.Session["descripcioncentrocosto"].ToString();
            ViewData["txtEmpresaRUC"] = v_empresaruc;
            ViewData["txtEmpresaNombre"] = v_empresanombre;
            ViewData["txtCodigoCotizacion"] = v_codigocotizacion;
            ViewData["txtCodigoCliente"] = v_codigocliente;
            ViewData["txtPlanillaMensual"] = v_detmontoplanillaadm + v_detmontoplanillaope;
            ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos(v_codigocliente).ToList(), "CodigoCentroCosto", "DescripcionCentroCosto", v_codigocentrocosto);
            ViewBag.Message = "Registros Procesados Correctamente";
            //return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);
            return PartialView("Upload");
        }

        public ActionResult ProcesaEmisionTest()
        {
            if (ModelState.IsValid)
            {
                return PartialView("Upload");
            }
            return PartialView("Upload");
        }

        #region Emitir
        public ActionResult ValoresIniciales(ENSCTRCotizaciones cotizacion)

        {
            ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
            ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv");
            ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDpto, cotizacion.CodigoProv).ToList(), "CodigoDist", "DescripcionDist");
            ViewBag.CodigoDptoR = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
            ViewBag.CodigoProvR = new SelectList(LNUbigeoProv.ObtenerProv(cotizacion.CodigoDptoR).ToList(), "CodigoProv", "DescripcionProv");
            ViewBag.CodigoDistR = new SelectList(LNUbigeoDist.ObtenerDist(cotizacion.CodigoDptoR, cotizacion.CodigoProvR).ToList(), "CodigoDist", "DescripcionDist");
            ViewBag.GrupoCIIU = new SelectList(LNCIIUPrincipal.ObtenerCIIUPrincipal().ToList(), "CodigoCIIU", "DescripcionCIIU");
            ViewBag.CodigoCIIU = new SelectList(LNCIIUEspecifica.ObtenerCIIUEspecifica(cotizacion.GrupoCIIU).ToList(), "CodigoCIIU", "DescripcionCIIU");
            ViewBag.CodigoMoneda = new SelectList(LNMonedas.ObtenerTodos().ToList(), "CodigoMoneda", "DescripcionMoneda");
            return View();
        }

        public JsonResult AjaxGetCall()
        {
            Employee employee = new Employee
            {
                Name = "Gnanavel Sekar",
                Designation = "Software Engineer",
                Location = "Chennai",
                ImportePrima = "100"
            };
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpire]
        public ActionResult Emitir(string empresaruc, string empresanombre, string codigocotizacion, string codigocliente, double detmontoplanillaadm, double detmontoplanillaope)
        {
            v_codigocliente = System.Web.HttpContext.Current.Session["codigocliente"].ToString();
            var lista = LNSaludCentroCostos.ObtenerTodos(v_codigocliente).ToList();
            ViewData["drpCentroCosto"] = new SelectList(lista, "CodigoCentroCosto", "DescripcionCentroCosto");

            ViewData["txtEmpresaRUC"] = empresaruc;
            ViewData["txtEmpresaNombre"] = empresanombre;
            ViewData["txtCodigoCotizacion"] = codigocotizacion;
            ViewData["txtCodigoCliente"] = codigocliente;
            ViewData["txtPlanillaMensual"] = detmontoplanillaadm + detmontoplanillaope;

            System.Web.HttpContext.Current.Session["empresaruc"] = empresaruc;
            System.Web.HttpContext.Current.Session["empresanombre"] = empresanombre;
            System.Web.HttpContext.Current.Session["codigocotizacion"] = codigocotizacion;
            System.Web.HttpContext.Current.Session["codigocliente"] = codigocliente;
            System.Web.HttpContext.Current.Session["detmontoplanillaadm"] = detmontoplanillaadm;
            System.Web.HttpContext.Current.Session["detmontoplanillaope"] = detmontoplanillaope;

            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Emitir(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)

            {

                v_codigocotizacion = System.Web.HttpContext.Current.Session["codigocotizacion"].ToString();
                v_empresanombre = System.Web.HttpContext.Current.Session["empresanombre"].ToString();
                v_empresaruc = System.Web.HttpContext.Current.Session["empresaruc"].ToString();
                v_codigocliente = System.Web.HttpContext.Current.Session["codigocliente"].ToString();
                v_detmontoplanillaadm = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaadm"]);
                v_detmontoplanillaope = Convert.ToDouble(System.Web.HttpContext.Current.Session["detmontoplanillaope"]);


                ViewData["txtEmpresaRUC"] = v_empresaruc;
                ViewData["txtEmpresaNombre"] = v_empresanombre;
                ViewData["txtCodigoCotizacion"] = v_codigocotizacion;
                ViewData["txtCodigoCliente"] = v_codigocliente;
                ViewData["txtPlanillaMensual"] = v_detmontoplanillaadm + v_detmontoplanillaope;

                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;
                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Formato de archivo incorrecto.");
                        return View();
                    }
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false
                        }
                    };
                    DataTable dt = new DataTable();

                    DataSet result = reader.AsDataSet();
                    DataSet resultordenado = new DataSet();//Data to be sorted.
                    //Sort data.
                    result.Tables[0].DefaultView.Sort = "Column5 ASC";
                    //Store in new Dataset
                    resultordenado.Tables.Add(result.Tables[0].DefaultView.ToTable());
                    string sMensaje = "";
                    dt = resultordenado.Tables[0];
                    dt.Columns["Column0"].ColumnName = "Nombres";
                    dt.Columns["Column1"].ColumnName = "Paterno";
                    dt.Columns["Column2"].ColumnName = "Materno";
                    dt.Columns["Column3"].ColumnName = "TipoTrab";
                    dt.Columns["Column4"].ColumnName = "TipoDoc";
                    dt.Columns["Column5"].ColumnName = "NroDoc";
                    dt.Columns["Column6"].ColumnName = "Sexo";
                    dt.Columns["Column7"].ColumnName = "EstadoCivil";
                    dt.Columns["Column8"].ColumnName = "Direccion";
                    dt.Columns["Column9"].ColumnName = "Telefono";
                    dt.Columns["Column10"].ColumnName = "FechaNac";
                    dt.Columns["Column11"].ColumnName = "Correo";
                    dt.Columns["Column12"].ColumnName = "Moneda";
                    dt.Columns["Column13"].ColumnName = "Sueldo";
                    dt.Columns["Column14"].ColumnName = "Estado";
                    int j = 0;
                    int k = 0;


                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string datoNombres = dt.Rows[i]["Nombres"].ToString();
                        string datoPaterno = dt.Rows[i]["Paterno"].ToString();
                        string datoMaterno = dt.Rows[i]["Materno"].ToString();
                        string datoTipoTrab = dt.Rows[i]["TipoTrab"].ToString();
                        string datoTipoDoc = dt.Rows[i]["TipoDoc"].ToString();
                        string datoNroDoc = dt.Rows[i]["NroDoc"].ToString();

                        string datoNroDocAnt = "";
                        if (i > 0)
                        {
                            datoNroDocAnt = dt.Rows[i - 1]["NroDoc"].ToString();
                        }
                        DataRow dr = dt.Rows[i];
                        if (datoNombres == "Nombres" | datoPaterno == "Paterno")
                        {
                            dr.Delete();
                            dt.AcceptChanges();
                        }
                        if (datoNombres == "" | datoPaterno == "" | datoMaterno == "" | datoTipoTrab == "" | datoTipoDoc == "" | datoNroDoc == "")
                        {
                            dt.Rows[i]["Estado"] = "Error: Faltan Datos  ";
                            j = j + 1;
                        }
                        else if (datoNroDoc == datoNroDocAnt)
                        {
                            dt.Rows[i]["Estado"] = "Error : NroDoc Duplicado";
                            dt.Rows[i - 1]["Estado"] = "Error : NroDoc Duplicado";
                            k = k + 1;
                        }
                        else
                        { dt.Rows[i]["Estado"] = "Correcto"; }
                    }
                    reader.Close();
                    if (j == 0 & k == 0)
                    {
                        sMensaje = "Datos Correctos";
                    }
                    else
                    {
                        sMensaje = "Existen errores en los datos, corrija y vuelva a cargar el archivo";
                    }
                    ViewBag.Mensaje = sMensaje;
                    ViewBag.Message = sMensaje;
                    //ViewBag.showSuccessAlert = true;
                    return PartialView(dt);
                }
                else
                {
                    ModelState.AddModelError("File", "Seleccione un archivo");
                }
            }
            return PartialView();
        }
        #endregion
    }
}


