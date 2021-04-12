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
            return View();
        }

        public ActionResult Crear(string id = "", string idcliente = "")

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
            ViewBag.CodigoPlanSC = new SelectList(LNSaludContratoPlan.ObtenerTodos(idcliente,id).ToList(), "CodigoPlanSC", "DescripcionPlanSC");

            if (id != "")
            {
                oENSaludContratos = LNSaludContratos.ObtenerUno(idcliente, id);
                ViewBag.CodigoCliente = new SelectList(LNClientes.ObtenerTodos().ToList(), "CodigoCliente", "RazonSocial", oENSaludContratos.CodigoCliente);
                ViewBag.CodigoTipoContrato = new SelectList(LNTipoContrato.ObtenerTodos().ToList(), "CodigoTipoContrato", "DescripcionTipoContrato", oENSaludContratos.CodigoTipoContrato);
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor", oENSaludContratos.CodigoCorredor);
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo", oENSaludContratos.CodigoEjecutivo);
                oContratoViewModel.SaludContratosVM.InicioVigencia = oENSaludContratos.InicioVigencia;
                oContratoViewModel.SaludContratosVM.FinVigencia = oENSaludContratos.FinVigencia;
                oContratoViewModel.SaludContratosVM.CodigoContrato = oENSaludContratos.CodigoContrato;
            }
            else
            {
                oENSaludContratos = new ENSaludContratos();
                oVMSaludContratos = new VMSaludContratos();

                oContratoViewModel.SaludContratosVM.InicioVigencia= DateTime.Now;
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
                }
                else
                {
                    LNSaludContratos.Insertar(contrato);
                }
                return RedirectToAction("Index", "SaludContratos");
            }
            return View();
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