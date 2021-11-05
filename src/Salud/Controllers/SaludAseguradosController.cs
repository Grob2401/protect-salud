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
using Salud.ViewModels;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Salud.Controllers
{
    public class SaludAseguradosController : Controller
    {

        #region INDEXS
        //####################ASEGURADOS
        //##############################
        [SessionExpire]
        public ActionResult Index()
        {
            var ASEGURADOS = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "", "TITULARES", "", "", "", "", "");
            ViewBag.Asegurados = ASEGURADOS;
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.IdNombreTabla = "01";
            ViewBag.TipoDocumentoPago = new SelectList(LNTipoDocumentoPago.ObtenerTodos().ToList(), "CodigoTipoDocumentoPago", "DescripcionTipoDocumentoPago");
            ViewBag.MotivosBaja = new SelectList(LNMotivoBaja.ObtenerTodos().ToList(), "CodigoMotivoBaja", "Descripcion");

            TempData["ASEGURADOS"] = ASEGURADOS;
            return View();
        }
        //####################ASEGURADOS POST
        //##############################"####
        [SessionExpire]
        [HttpPost]
        public ActionResult Index(string hdCodigoTipoCliente, string txtBusquedaAsegurados = "")
        {
            var ASEGURADOS = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, txtBusquedaAsegurados, "TITULARES", hdCodigoTipoCliente, "", "", "", "");
            ViewBag.Asegurados = ASEGURADOS;
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.IdNombreTabla = hdCodigoTipoCliente.ToString();
            ViewBag.TipoDocumentoPago = new SelectList(LNTipoDocumentoPago.ObtenerTodos().ToList(), "CodigoTipoDocumentoPago", "DescripcionTipoDocumentoPago");
            TempData["ASEGURADOS"] = ASEGURADOS;
            return View();
        }

        //#####ASEGURADOS INDEPENDIENTES
        //##############################
        [HttpGet]
        [SessionExpire]
        public ActionResult Independientes()
        {
            var ASEGURADOS = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "", "POTESTATIVOS", "", "", "", "", "");
            ViewBag.Asegurados = ASEGURADOS;
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.TipoDocumentoPago = new SelectList(LNTipoDocumentoPago.ObtenerTodos().ToList(), "CodigoTipoDocumentoPago", "DescripcionTipoDocumentoPago");
            return View();
        }

        //#####ASEGURADOS INDEPENDIENTES POST
        //##############################
        [HttpPost]
        [SessionExpire]
        public ActionResult Independientes(string hdCodigoTipoCliente, string txtBusquedaAsegurados = "")
        {
            var ASEGURADOS = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, txtBusquedaAsegurados, "POTESTATIVOS", hdCodigoTipoCliente, "", "", "", "");
            ViewBag.Asegurados = ASEGURADOS;
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.TipoDocumentoPago = new SelectList(LNTipoDocumentoPago.ObtenerTodos().ToList(), "CodigoTipoDocumentoPago", "DescripcionTipoDocumentoPago");
            return View();
        }

        public ActionResult ValidarAgregarCuotas(string cliente, string titular, string categoria, string idCuota,string codigoContrato, string fechaInicio ,string fechaFin, double monto, string tipoDocPago, string nroDocPago)
        {
            var mensaje = "";

            if (!LNSaludAsegurados.validarCuotas(cliente,titular,categoria,fechaFin))
            {
                mensaje = "No se puede cancelar esta cuota debido a que el asegurado se encuentra de baja.";                
            }

            if (nroDocPago == null || nroDocPago == string.Empty)
            {
                mensaje = "Debe ingresar un numero de documento de pago, favor de revisar los items seleccionados.";
            }

            if (!LNSaludAsegurados.VerificarMontoIndependientes(cliente, titular, categoria, codigoContrato,  fechaInicio,  monto))
            {
                mensaje = "Los montos ingresados no corresponden con el valor de la prima.";
            }

            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GuardarCuotas()
        //{

        //}

        //####################AFILIACION
        //##############################
        [HttpGet]
        [SessionExpire]
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

        //#################MANTENIMIENTO
        //##############################
        [HttpGet]
        [SessionExpire]
        public ActionResult Mantenimiento(string CodigoCLiente = "", string CodigoTitular = "", string CodigoContrato = "", string origen = "")
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

            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "", "GRUPOFAMILIAR", "", CodigoCLiente, CodigoTitular, "", CodigoContrato).ToList();
            ViewBag.Asegurados = listaAsegurados;


            oENClientes = LNClientes.ObtenerTodos().Find(smodel => smodel.CodigoCliente == CodigoCLiente);
            oENSaludContratos = LNSaludContratos.ObtenerTodos(CodigoCLiente).Find(smodel => smodel.CodigoContrato == CodigoContrato);
            ViewBag.MotivosBaja = new SelectList(LNMotivoBaja.ObtenerTodos().ToList(), "CodigoMotivoBaja", "Descripcion");
            ViewBag.CodigoContrato = new SelectList(LNSaludContratos.ObtenerTodos(CodigoCLiente).ToList(), "CodigoContrato", "CodigoContrato", oENSaludContratos.CodigoContrato);
            oContratoViewModel.VMCliente.CodigoCliente = oENClientes.CodigoCliente;
            oContratoViewModel.VMCliente.RazonSocial = oENClientes.RazonSocial;
            oContratoViewModel.VMCliente.RucDni = oENClientes.RucDni;
            oContratoViewModel.VMContrato.InicioVigencia = oENSaludContratos.InicioVigencia;
            oContratoViewModel.VMContrato.FinVigencia = oENSaludContratos.FinVigencia;
            return View(oContratoViewModel);
        }

        #endregion



        #region PAGOS

        //INDEPENDIENTES PAGOS

        [SessionExpire]
        public ActionResult IndependientesPagos(string contrato)
        {
            var INDEPENDIENTESXCONTRATO = LNSaludAsegurados.ObtenerSaludAseguradosIndependientesPagos(contrato);           
            return Json(INDEPENDIENTESXCONTRATO, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        public ActionResult ObtenerCuotasNoPagadas(string cliente, string titular, string categoria, string contrato)
        {
            var CUOTASNOPAGADAS = LNSaludAsegurados.ObtenerSaludAseguradosCuotasNoPagadas(cliente, titular, categoria, contrato);
            return Json(CUOTASNOPAGADAS, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        public ActionResult ObtenerTodasCuotas(string cliente, string titular, string categoria, string contrato)
        {
            var CUOTASNOPAGADAS = LNSaludAsegurados.ObtenerAseguradosTodasCuotas(cliente, titular, categoria, contrato);
            return Json(CUOTASNOPAGADAS, JsonRequestBehavior.AllowGet);
        }

        //REGULARES PAGOS

        [SessionExpire]
        public ActionResult RegularesPagos(string cliente,string contrato)
        {
            var INDEPENDIENTESXCONTRATO = LNSaludAsegurados.ObtenerSaludAseguradosRegularesPagos(cliente,contrato);
            return Json(INDEPENDIENTESXCONTRATO, JsonRequestBehavior.AllowGet);
        }

        //[SessionExpire]
        //public ActionResult ObtenerCuotasNoPagadas(string cliente, string titular, string categoria, string contrato)
        //{
        //    var CUOTASNOPAGADAS = LNSaludAsegurados.ObtenerSaludAseguradosCuotasNoPagadas(cliente, titular, categoria, contrato);
        //    return Json(CUOTASNOPAGADAS, JsonRequestBehavior.AllowGet);
        //}

        //[SessionExpire]
        //public ActionResult ObtenerTodasCuotas(string cliente, string titular, string categoria, string contrato)
        //{
        //    var CUOTASNOPAGADAS = LNSaludAsegurados.ObtenerAseguradosTodasCuotas(cliente, titular, categoria, contrato);
        //    return Json(CUOTASNOPAGADAS, JsonRequestBehavior.AllowGet);
        //}

        #endregion


        [HttpGet]
        [SessionExpire]
        public ActionResult Crear(string idcliente = "", string idtitular = "", string idcategoria = "", string idcontrato = "", string origen = "")
        {
            if (idcliente != "" && idcontrato != "")
            {
                ViewBag.Cliente = idcliente;
                ViewBag.Contrato = idcontrato;
            }

            if (origen != "")
            {
                ViewBag.Origen = origen;
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
                ViewBag.CodigoCentroCosto = new SelectList(LNSaludCentroCostos.ObtenerTodos(idcliente).ToList(), "CodigoCentroCosto", "DescripcionCentroCosto", oENSaludAsegurados.CodigoCentroCosto);
                ViewBag.CodigoSexo = new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo", oENSaludAsegurados.CodigoSexo);
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad", oENSaludAsegurados.CodigoDocumentoIdentidad);
                ViewBag.CodigoTipoTrabajador = new SelectList(LNTipoAsegurado.ObtenerTodos().ToList(), "CodigoTipoAsegurado", "DescripcionTipoAsegurado", oENSaludAsegurados.CodigoTipoTrabajador);
                ViewBag.CodigoPlan = new SelectList(LNSaludContratoPlan.ObtenerTodos(idcliente, idcontrato).ToList(), "CodigoPlanSC", "DescripcionPlanSC", oENSaludAsegurados.CodigoPlan);
                ViewBag.CodigoTipoEstadoCivil = new SelectList(LNSaludEstadoCivil.ObtenerTodos().ToList(), "CodigoTipoEstadoCivil", "DescripcionTipoEstadoCivil", oENSaludAsegurados.CodigoTipoEstadoCivil);
                ViewBag.CodigoPais = new SelectList(LNTipoPais.ObtenerTodos().ToList(), "CodigoTipoPais", "DescripcionTipoPais", oENSaludAsegurados.Pais);
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
                ViewBag.CodigoTipoEstadoCivil = new SelectList(LNSaludEstadoCivil.ObtenerTodos().ToList(), "CodigoTipoEstadoCivil", "DescripcionTipoEstadoCivil");
                ViewBag.CodigoPais = new SelectList(LNTipoPais.ObtenerTodos().ToList(), "CodigoTipoPais", "DescripcionTipoPais");

                oENSaludAsegurados = new ENSaludAsegurados();
            }
            return View(oENSaludAsegurados);
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
                CodigoTipoEstadoCivil = asegurado.CodigoTipoEstadoCivil,
                Talla = asegurado.Talla == null ? "" : asegurado.Talla,
                Peso = asegurado.Peso == null ? "" : asegurado.Peso,
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
                RegEdtDate = ini2,
                Pais = asegurado.Pais,
            };

            string resultado = "";

            if (!string.IsNullOrEmpty(registrar))
            {
                //Insertar Asegurado
                if (asegurado.CodigoParentesco == "C" || asegurado.CodigoParentesco == "M" || asegurado.CodigoParentesco == "P")
                {
                    var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "","DEPENDIENTES", "", asegurado.CodigoCliente, asegurado.CodigoTitular, asegurado.Categoria, asegurado.CodigoContrato).ToList();
                    
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
        public ActionResult Baja(string fechaBaja, string codigoCliente, string codigoTitular, string codigoCategoria, string codigoContrato, string motivo, string motivoOtro)
        {
            var format = "yyyy-MM-dd";
            //------------------------
            var fecbaja = fechaBaja.Split('-');
            var anio = Convert.ToInt32(fecbaja[0]);
            var mes = Convert.ToInt32(fecbaja[1]);
            var dia = Convert.ToInt32(fecbaja[2]);
            DateTime fecbajaFormat = new DateTime(anio, mes, dia);
            var fechaformateada = fecbajaFormat.ToString("yyyy-MM-dd");
            var fechaBajaUlt = DateTime.ParseExact(fechaformateada, format, CultureInfo.InvariantCulture);
            //------------------------

            string usuario = "";

            if (Session["IdUsuario"] != null)
            {
               usuario = Session["IdUsuario"].ToString();
            }
            

            //Session["IdUsuario"]
            bool resultado = LNSaludAsegurados.DarBaja(fechaformateada, codigoCliente,codigoTitular,codigoCategoria,codigoContrato, usuario, motivo, motivoOtro);

            if (resultado == true)
            {
                TempData["MensajeAgregarAFiliado"] = "El asegurado fue dado de baja.";
                return Json(resultado, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Mantenimiento", new { CodigoCLiente = codigoCliente, CodigoTitular = codigoTitular, CodigoContrato = codigoContrato });
            }
            else
            {
                TempData["MensajeAgregarAFiliado"] = "Ocurrió un error, intente nuevamente.";
                return Json(resultado, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Mantenimiento", new { CodigoCLiente = codigoCliente, CodigoTitular = codigoTitular, CodigoContrato = codigoContrato });
            }

        }


        [SessionExpire]
        [HttpGet]
        public ActionResult Consumir_LPService(string metodo = "", string idcliente = "", string idtitular = "", string idcategoria = "")
        {
            LPService.Respuesta[] rptResponse = null;
            //VARIABLES GLOBALES
            string USUARIO_WS = ConfigurationManager.AppSettings["USUARIO"];
            string CONTRASENA_WS = ConfigurationManager.AppSettings["CONTRASENA"];
            string CLIENTE_WS = ConfigurationManager.AppSettings["COD_CLIENTE"]; 
            //DATOS DEL ASEGURADO
            var objAsegurado = LNSaludAsegurados.ObtenerUno(idcliente, idtitular, idcategoria);
            //DATOS PETICION RESPUESTA
            var peticion = "";
            var respuesta = "";
            var mensaje = "";
            var resultado = false;
            var usuario_sistema = "";

            //SI ES VACÍO NO MANDA NADA
            if (objAsegurado.CodigoCliente == null)
            {
                return Json("No existen datos para enviar, intente nuevamente", JsonRequestBehavior.AllowGet);
            }
            else
            {
                //VALIDACION POR MÉTODOS DE WS LP
                if (metodo == "WS_Registrar")
                {
                    usuario_sistema = Session["NombreUsuario"].ToString();
                    LPService.ServicioWebLPSoapClient LPS = new LPService.ServicioWebLPSoapClient();
                    rptResponse = LPS.WS_Registrar(
                        USUARIO_WS, CONTRASENA_WS, CLIENTE_WS, objAsegurado.CodigoTitular, objAsegurado.Categoria,
                        objAsegurado.CodigoCentroCosto, objAsegurado.CodigoPlan, objAsegurado.Nombres, objAsegurado.ApellidoPaterno, objAsegurado.ApellidoMaterno,
                        objAsegurado.CodigoSexo, objAsegurado.FechaNacimiento.ToString("dd/MM/yyyy"), objAsegurado.FechaAlta.ToString("dd/MM/yyyy"), objAsegurado.FechaBaja.ToString("dd/MM/yyyy"), objAsegurado.FechaAlta.ToString("dd/MM/yyyy"),
                        objAsegurado.Email, objAsegurado.CodigoDocumentoIdentidad, objAsegurado.NumeroDocumentoIdentidad, objAsegurado.Direccion,
                        objAsegurado.Telefono, objAsegurado.Telefono, objAsegurado.CodigoTipoEstadoCivil, objAsegurado.CodigoContrato, "1", "1", "1"                        
                        );

                    peticion =  USUARIO_WS + " | " + CONTRASENA_WS + " | " + CLIENTE_WS + " | " + objAsegurado.CodigoTitular + " | " + objAsegurado.Categoria + " | " +
                                objAsegurado.CodigoCentroCosto + " | " + objAsegurado.CodigoPlan + " | " + objAsegurado.Nombres + " | " + objAsegurado.ApellidoPaterno + " | " + objAsegurado.ApellidoMaterno + " | " +
                                objAsegurado.CodigoSexo + " | " + objAsegurado.FechaNacimiento.ToString("dd/MM/yyyy") + " | " + objAsegurado.FechaAlta.ToString("dd/MM/yyyy") + " | " + objAsegurado.FechaBaja.ToString("dd/MM/yyyy") + " | " + objAsegurado.FechaAlta.ToString("dd/MM/yyyy") + " | " +
                                objAsegurado.Email + " | " + objAsegurado.CodigoDocumentoIdentidad + " | " + objAsegurado.NumeroDocumentoIdentidad + " | " + objAsegurado.Direccion + " | " +
                                objAsegurado.Telefono + " | " + objAsegurado.Telefono + " | " + objAsegurado.CodigoTipoEstadoCivil + " | " + objAsegurado.CodigoContrato + " | " + "1" + " | " + "1" + " | " + "1";
                    respuesta = String.Join(",", rptResponse.Select(c => c.Codigo + "|" + c.Descripcion).ToArray());
                    resultado = LNSaludAsegurados.WebService_Log(objAsegurado.CodigoCliente, objAsegurado.CodigoTitular, objAsegurado.Categoria, metodo, peticion, respuesta, rptResponse[0].Codigo.ToString(), rptResponse[0].Descripcion.ToString(), usuario_sistema);
                    mensaje = respuesta;
                    return Json(mensaje, JsonRequestBehavior.AllowGet);

                }
                else if (metodo == "WS_Actualizar")
                {
                    LPService.ServicioWebLPSoapClient LPS = new LPService.ServicioWebLPSoapClient();
                    rptResponse = LPS.WS_Actualizar(
                        USUARIO_WS, CONTRASENA_WS, CLIENTE_WS, objAsegurado.CodigoTitular, objAsegurado.Categoria,
                        objAsegurado.FechaAlta.ToString("dd/MM/yyyy"), objAsegurado.FechaBaja.ToString("dd/MM/yyyy"),objAsegurado.FechaAlta.ToString("dd/MM/yyyy"),
                        objAsegurado.Email,objAsegurado.Direccion,objAsegurado.Telefono,objAsegurado.Telefono,objAsegurado.CodigoTipoEstadoCivil
                        );
                    return Json("Datos enviados", JsonRequestBehavior.AllowGet);
                }
                else if (metodo == "WS_Actualizar_Estado")
                {
                    LPService.ServicioWebLPSoapClient LPS = new LPService.ServicioWebLPSoapClient();
                    rptResponse = LPS.WS_Actualizar_Estado(
                        USUARIO_WS, CONTRASENA_WS, CLIENTE_WS, objAsegurado.CodigoTitular, objAsegurado.Categoria,
                        objAsegurado.Estado,objAsegurado.FechaBaja.ToString("dd/MM/yyyy"),"Causal Baja"
                        );
                    return Json("Datos enviados", JsonRequestBehavior.AllowGet);
                }
                else if (metodo == "WS_Renovar_contrato")
                {
                    LPService.ServicioWebLPSoapClient LPS = new LPService.ServicioWebLPSoapClient();
                    rptResponse = LPS.WS_Renovar_Contrato(
                        USUARIO_WS, CONTRASENA_WS, CLIENTE_WS, objAsegurado.CodigoTitular, objAsegurado.Categoria,
                        objAsegurado.FechaAlta.ToString("dd/MM/yyyy"),                        
                        objAsegurado.FechaBaja.ToString("dd/MM/yyyy")
                        );
                    return Json("Datos enviados", JsonRequestBehavior.AllowGet);
                }

                return Json("No se cargaron los datos, intente nuevamente", JsonRequestBehavior.AllowGet);
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
        public ActionResult getSaludAsegurados(string tipoConsulta, string tipoCliente, string codCliente, string codTitular, string codDependiente, string codContrato)
        {

            ENSaludContratos contrato = new ENSaludContratos();
            contrato = LNSaludContratos.ObtenerUno(codCliente, codContrato);

            var inicioVigencia = (contrato.InicioVigencia == null ? DateTime.Now : contrato.InicioVigencia);
            var finVigencia = (contrato.FinVigencia == null ? DateTime.Now : contrato.FinVigencia);
            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "",tipoConsulta, tipoCliente, codCliente, codTitular, codDependiente, codContrato).ToList();

            object[] variables = { inicioVigencia, finVigencia, listaAsegurados };
            //var json = new JavaScriptSerializer().Serialize(variables);

            return Json(variables, JsonRequestBehavior.AllowGet);


        }

        [SessionExpire]
        [HttpGet]
        public ActionResult getSoloAsegurados(string tipoConsulta,string tipoCliente, string codCliente, string codTitular, string codDependiente, string codContrato)
        {
            var listaAsegurados = LNSaludAsegurados.ObtenerSaludAsegurados(1, 100, "",tipoConsulta, tipoCliente, codCliente, codTitular, codDependiente, codContrato)
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