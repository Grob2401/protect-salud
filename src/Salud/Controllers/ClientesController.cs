using Entidades;
using System;
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
    public class ClientesController : Controller
    {
        private LNUbigeoDpto LNUbigeoDpto = new LNUbigeoDpto();
        private LNUbigeoProv LNUbigeoProv = new LNUbigeoProv();
        private LNUbigeoDist LNUbigeoDist = new LNUbigeoDist();

        // GET: Clientes
        [SessionExpire]
        public ActionResult Index()
        {
            ViewBag.Clientes = LNClientes.ObtenerTodos();
            //var VMCliente = new List<ENClientes>();
            //var VMUbigeo = new List<ENUbigeoCompleto>();
            var VMCliente = new ENClientes();
            var VMUbigeo = new ENUbigeoCompleto();

            var ClienteViewModel = new VMClientes
            {
                Clientes = VMCliente,
                Ubigeo = VMUbigeo
            };

            if (TempData["Mensaje_Cliente"] != null)
            {
                ViewBag.Message = "Cliente registrado correctamente";
            }

            //return View(ClienteViewModel);

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult _Prueba()
        {
            return View();
        }


        public ActionResult Buscar()

        {
            ViewBag.Clientes = LNClientes.ObtenerTodos();
            return PartialView("_BusquedaClientes", LNClientes.ObtenerTodos());
        }

        [HttpGet]
        public ActionResult Crear(string id = "")
        {
            ENClientes oENClientes = null;
            var VMCliente = new ENClientes();
            var VMUbigeo = new ENUbigeoCompleto();

            var ClienteViewModel = new VMClientes
            {
                Clientes = VMCliente,
                Ubigeo = VMUbigeo
            };


            if (id != "")
            {
                oENClientes = LNClientes.ObtenerUno(id);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", oENClientes.CodigoDpto);
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(oENClientes.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", oENClientes.CodigoProv);
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(oENClientes.CodigoDpto, oENClientes.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", oENClientes.CodigoDist);
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor", oENClientes.CodigoCorredor);
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo", oENClientes.CodigoEjecutivo);
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente", oENClientes.CodigoTipoCliente);

            }
            else
            {
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor");
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo");
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");

                oENClientes = new ENClientes();
           }

            return View(oENClientes);

        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Crear(ENClientes cliente)
        {
            if (cliente.CodigoCliente is null)
            {

                if (LNClientes.Insertar(cliente))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                    TempData["Mensaje_Cliente"] = "Cliente registrado correctamente";
                }
                //return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);

            }
            else
            {

                if (LNClientes.Actualizar(cliente))
                {
                    ViewBag.Message = "Registro Actualizado Correctamente";
                    ModelState.Clear();
                }
                //return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);

            }
            return RedirectToAction("Index", "Clientes");
        }

        [SessionExpire]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(string id = "")
        {
            if (ModelState.IsValid)
            {
                LNClientes.Eliminar(id);
                return RedirectToAction("Index", "Clientes");
            }
            return View();
        }



    }
}