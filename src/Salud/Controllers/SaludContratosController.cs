using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;
using Salud.ViewModels;

namespace Salud.Controllers
{
    public class SaludContratosController : Controller
    {
        // GET: SaludContratos
        public ActionResult Index()
        {
            string sCodigoCliente = "";
            ViewBag.SaludContratos = LNSaludContratos.ObtenerTodos(sCodigoCliente);
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Index(string hdCodigoTipoCliente, string txtBusquedaContratos = "")
        {
            string sCodigoCliente = "";
            ViewBag.SaludContratos = LNSaludContratos.ObtenerTodos(1, 100, hdCodigoTipoCliente, txtBusquedaContratos);
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            return View();
        }

        public ActionResult Administrar(string id = "", string idcliente = "",string mensaje = "")

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

            //Fin
            ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial");
            ViewBag.CodigoPlan = new SelectList(LNSaludPlanes.ObtenerTodos().ToList(), "CodigoPlan", "DescripcionPlan");
            var planess = LNSaludPlanes.ObtenerTodos();
            TempData["planess"] = planess;
            ViewBag.CodigoPlanSC = new SelectList(LNSaludContratoPlan.ObtenerTodos(idcliente, id).ToList(), "CodigoPlanSC", "DescripcionPlanSC");

            var mensajeAsignacion = Session["mensajeAsignacion"];
            if (mensajeAsignacion != null)
            {
                TempData["ReceivedId"] = mensajeAsignacion;
                Session["mensajeAsignacion"] = null;
                mensajeAsignacion = null;
            }
            else
            {
                TempData["ReceivedId"] = null;
            }



            if (id != "")
            {
                oENSaludContratos = LNSaludContratos.ObtenerUno(idcliente, id);
                ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludContratos.CodigoCliente);
                ViewBag.CodigoTipoContrato = new SelectList(LNTipoContrato.ObtenerTodos().ToList(), "CodigoTipoContrato", "DescripcionTipoContrato", oENSaludContratos.CodigoTipoContrato);
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor", oENSaludContratos.CodigoCorredor);
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo", oENSaludContratos.CodigoEjecutivo);
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
                oContratoViewModel.SaludContratosVM.InicioVigencia = oENSaludContratos.InicioVigencia;
                oContratoViewModel.SaludContratosVM.FinVigencia = oENSaludContratos.FinVigencia;
                oContratoViewModel.SaludContratosVM.CodigoContrato = oENSaludContratos.CodigoContrato;
            }

            else
            {
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
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
                //ViewBag.CodigoPlan = new SelectList(LNSaludPlanes.ObtenerTodos().ToList(), "CodigoPlan", "Descripcion");

            }
            //return View(oENSaludContratos);
            return View(oContratoViewModel);
            //return View(oVMSaludContratos);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Administrar(string contrato, string plan, string fecini, string fecfin)
        {

            var arr = fecini.Split('-');

            var dia1 = Convert.ToInt32(arr[2]);
            var mes1 = Convert.ToInt32(arr[1]);
            var anio1 = Convert.ToInt32(arr[0]);

            var arr2 = fecfin.Split('-');

            var dia2 = Convert.ToInt32(arr2[2]);
            var mes2 = Convert.ToInt32(arr2[1]);
            var anio2 = Convert.ToInt32(arr2[0]);

            DateTime dtini = new DateTime(anio1, mes1, dia1);
            DateTime dtfin = new DateTime(anio2, mes2, dia2);

            ENSaludContratoPlan oContratoPlan = new ENSaludContratoPlan()
            {
                CodigoContrato = contrato,
                CodigoPlanSC = plan,
                FechaInicioContratoPlan = dtini,
                FechaFinContratoPlan = dtfin,
            };

            bool todoOK = false;
            if (oContratoPlan.CodigoPlanSC != null)
            {
                todoOK = LNSaludContratoPlan.Insertar(oContratoPlan);
            }

            if (todoOK)
            {
                Session["mensajeAsignacion"] = "Datos registrados correctamente";
                return Json(TempData["mensajeAsignacion"], JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["mensajeAsignacion"] = "Error al asignar planes";
                return View();
            }
        }

        public ActionResult Crear(string idcontrato = "", string idcliente = "")
        {

            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"];
            }


                ENSaludContratos oENSaludContratos = null;
            VMSaludContratos oVMSaludContratos = null;
            ////Prueba
            var VMContratos = new ENSaludContratos();
            var VMPlanes = new ENSaludPlanes();
            var VMListaPlanes = new List<ENSaludPlanes>();

            var oContratoViewModel = new VMSaludContratos
            {
                SaludContratosVM = VMContratos,
                SaludPlanesVM = VMPlanes,
                VMListaSaludPlanes = VMListaPlanes
            };

            if (idcontrato != "")
            {
                oENSaludContratos = LNSaludContratos.ObtenerUno(idcliente, idcontrato);
                ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludContratos.CodigoCliente);
                ViewBag.CodigoContrato = idcontrato;
                ViewBag.CodigoTipoContrato = new SelectList(LNTipoContrato.ObtenerTodos().ToList(), "CodigoTipoContrato", "DescripcionTipoContrato", oENSaludContratos.CodigoTipoContrato);
                ViewBag.CodigoTipoPrima = new SelectList(LNTipoPrima.ObtenerTodos().ToList(), "CodigoTipoPrima", "DescripcionTipoPrima", oENSaludContratos.CodigoTipoPrima);
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor", oENSaludContratos.CodigoCorredor);
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo", oENSaludContratos.CodigoEjecutivo);
                ViewBag.InicioVigencia = oENSaludContratos.InicioVigencia;
                ViewBag.FinVigencia = oENSaludContratos.FinVigencia;
                ViewBag.CodigoContrato = oENSaludContratos.CodigoContrato;
                ViewBag.CodigoCotizacion = oENSaludContratos.CodigoCotizacion;
            }
            else
            {
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
                ViewBag.CodigoContrato = new SelectList(LNSaludContratos.ObtenerTodos("").ToList(), "CodigoContrato", "CodigoContrato");
                ViewBag.CodigoTipoContrato = new SelectList(LNTipoContrato.ObtenerTodos().ToList(), "CodigoTipoContrato", "DescripcionTipoContrato");
                ViewBag.CodigoTipoPrima = new SelectList(LNTipoPrima.ObtenerTodos().ToList(), "CodigoTipoPrima", "DescripcionTipoPrima");
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor");
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo");
                //ViewBag.CodigoPlan = new SelectList(LNSaludPlanes.ObtenerTodos().ToList(), "CodigoPlan", "Descripcion");

            }
            //return View(oENSaludContratos);
            return View(oContratoViewModel);
            //return View(oVMSaludContratos);


        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Crear(ENSaludContratos contrato)
        {
            if (ModelState.IsValid)
            {
                if (contrato.CodigoContrato != null)
                {
                    LNSaludContratos.Actualizar(contrato);
                    TempData["mensaje"] = "Contrato Actualizado";
                }
                else
                {
                    LNSaludContratos.Insertar(contrato);
                    TempData["mensaje"] = "Contrato Registrado";
                }
                return RedirectToAction("Crear", "SaludContratos");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Obtener(string id)
        {
            ENClientes cliente = new ENClientes();
            cliente = LNClientes.ObtenerUno(id);
            var contratos = new SelectList(LNSaludContratos.ObtenerTodos(id).ToList(), "CodigoContrato", "CodigoContrato");

            var razon = (cliente.RazonSocial == null ? "" : cliente.RazonSocial);
            var direccion = (cliente.Direccion == null ? "" : cliente.Direccion);
            var telefono1 = (cliente.Telefono1 == null ? "" : cliente.Telefono1);
            var contacto = (cliente.PersonaContacto == null ? "" : cliente.PersonaContacto);
            var telefono2 = (cliente.Telefono2 == null ? "" : cliente.Telefono2);
            var email = (cliente.Email == null ? "" : cliente.Email);

            object[] variables = { razon, direccion, telefono1, contacto, telefono2, email, contratos };

            return Json(variables, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarLimpiarPlanes(string contrato)
        {
            //var arr = fecini.Split('-');

            //var dia1 = Convert.ToInt32(arr[2]);
            //var mes1 = Convert.ToInt32(arr[1]);
            //var anio1 = Convert.ToInt32(arr[0]);

            //DateTime dtini = new DateTime(anio1, mes1, dia1);

            bool vali = LNSaludContratoPlan.Eliminar(contrato);

            return Json(vali, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObtenerDatosContrato(string Codcliente, string idContrato)
        {
            ENSaludContratos contrato = new ENSaludContratos();
            contrato = LNSaludContratos.ObtenerUno(Codcliente, idContrato);

            ENSaludContratoPlan plan = new ENSaludContratoPlan();
            List<ENSaludContratoPlan> planes = new List<ENSaludContratoPlan>();

            var inicioVigencia = (contrato.InicioVigencia == null ? DateTime.Now : contrato.InicioVigencia);
            var finVigencia = (contrato.FinVigencia == null ? DateTime.Now : contrato.FinVigencia);
            var corredor = (contrato.CodigoCorredor == null ? "" : contrato.CodigoCorredor);
             planes = LNSaludContratoPlan.ObtenerTodos(Codcliente,idContrato);

            object[] variables = { inicioVigencia, finVigencia, corredor, planes };

            return Json(variables, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        public ActionResult Eliminar(string id = "", string idcliente = "")
        {
            if (ModelState.IsValid)
            {
                LNSaludContratos.Eliminar(idcliente, id);
                return RedirectToAction("Index", "SaludContratos");
            }
            return View();
        }

    }
}