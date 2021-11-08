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
        public ActionResult Index(int page = 0)
        {

            if (page != 0)
            {
                ViewData["pageCount"] = page;
            }

            if (ViewData["pageCount"]  == null && page == 0)
            {
                ViewData["pageCount"] = 1;
                page = 1;
            }

            var contador = LNClientes.Cantidad();
            ViewData["todos"] = contador;
            ViewData["ultimo"] = contador / 100;

            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.Clientes = LNClientes.ObtenerTodos(page,100,"","");
            ViewBag.IdNombreTabla = "01";
            //var VMCliente = new List<ENClientes>();int page, int rows, string type, string Keywords
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
                ViewBag.Message = TempData["Mensaje_Cliente"];
            }

            //return View(ClienteViewModel);

            return View();
        }


        // GET: Clientes
        [SessionExpire]
        [HttpPost]
        public ActionResult Index(string hdCodigoTipoCliente = "", string txtBusquedaClientes = "")
        {
            ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
            ViewBag.Clientes = LNClientes.ObtenerTodos(1, 100, hdCodigoTipoCliente, txtBusquedaClientes);
            ViewBag.IdNombreTabla = hdCodigoTipoCliente.ToString();
            //var VMCliente = new List<ENClientes>();int page, int rows, string type, string Keywords
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

            return View("Index");
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
            var VMCliente = new ENClientes();
            var VMUbigeo = new ENUbigeoCompleto();

            if (TempData["Tarjeta_Add"] != null)
            {
                ViewBag.TarjetaAdd = TempData["Tarjeta_Add"];
            }

            if (TempData["Tarjeta_Update"] != null)
            {
                ViewBag.TarjetaUpdate = TempData["Tarjeta_Update"];
            }

            if (TempData["Tarjeta_Remove"] != null)
            {
                ViewBag.TarjetaRemove = TempData["Tarjeta_Remove"];
            }


            if (id != "")
            {
                VMCliente = LNClientes.ObtenerUno(id);
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto", VMCliente.CodigoDpto);
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv(VMCliente.CodigoDpto).ToList(), "CodigoProv", "DescripcionProv", VMCliente.CodigoProv);
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist(VMCliente.CodigoDpto, VMCliente.CodigoProv).ToList(), "CodigoDist", "DescripcionDist", VMCliente.CodigoDist);
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor", VMCliente.CodigoCorredor);
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo", VMCliente.CodigoEjecutivo);
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente", VMCliente.CodigoTipoCliente);
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad", VMCliente.CodigoDocumentoIdentidad);
                ViewBag.Tarjetas = LNClientes.ObtenerTarjetas(id).OrderByDescending(x => x.IdClienteTarjetas).ToList();
                ViewBag.MarcaTarjetas = new SelectList(LNMarcaTarjeta.ObtenerTodos().ToList(), "CodigoMarcaTarjeta", "DescripcionMarcaTarjeta");
                ViewBag.CodigoClienteID = id;
                //ViewBag.CodigoVendedor = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad");

            }
            else
            {
                ViewBag.CodigoDpto = new SelectList(LNUbigeoDpto.ObtenerDpto().ToList(), "CodigoDpto", "DescripcionDpto");
                ViewBag.CodigoProv = new SelectList(LNUbigeoProv.ObtenerProv("15").ToList(), "CodigoProv", "DescripcionProv");
                ViewBag.CodigoDist = new SelectList(LNUbigeoDist.ObtenerDist("15", "01").ToList(), "CodigoDist", "DescripcionDist");
                ViewBag.CodigoCorredor = new SelectList(LNSCTRCorredor.ObtenerTodos().ToList(), "CodigoCorredor", "DescripcionCorredor");
                ViewBag.CodigoEjecutivo = new SelectList(LNSCTREjecutivos.ObtenerTodos().ToList(), "CodigoEjecutivo", "NombreEjecutivo");
                ViewBag.CodigoTipoCliente = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente");
                ViewBag.CodigoDocumentoIdentidad = new SelectList(LNTipoDocumentoIdentidad.ObtenerTodos().ToList(), "CodigoDocumentoIdentidad", "DescripcionDocumentoIdentidad");
                ViewBag.MarcaTarjetas = new SelectList(LNMarcaTarjeta.ObtenerTodos().ToList(), "CodigoMarcaTarjeta", "DescripcionMarcaTarjeta");
                ViewBag.CodigoClienteID = null;
                //ViewBag.CodigoVendedor = new SelectList(LNVendedor.ObtenerTodos("0").ToList(), "CodigoVendedor", "Nombres");
            }

            var ClienteViewModel = new VMClientes
            {
                Clientes = VMCliente,
                Ubigeo = VMUbigeo
            };


            return View(ClienteViewModel);

        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Crear(VMClientes obj)
        {
            if (obj.Clientes.CodigoCliente is null)
            {

                if (LNClientes.Insertar(obj.Clientes))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                    TempData["Mensaje_Cliente"] = "Cliente registrado correctamente";
                }
                //return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);

            }
            else
            {

                if (LNClientes.Actualizar(obj.Clientes))
                {
                    ViewBag.Message = "Registro Actualizado Correctamente";
                    TempData["Mensaje_Cliente"] = "Registro Actualizado Correctamente";
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


        [SessionExpire]
        [HttpPost]
        public ActionResult AgregarTarjeta(VMClientes obj)
        {

            if (obj.Tarjeta.IdClienteTarjetas == 0)
            {
                DateTime value = new DateTime(Convert.ToInt32(obj.Tarjeta.anioFinVigencia), Convert.ToInt32(obj.Tarjeta.mesFinVigencia), 30);
                obj.Tarjeta.FechaVencimientoTarjeta = value;
                obj.Tarjeta.Token = "";
                obj.Tarjeta.FechaVencimientoToken = DateTime.Now.AddDays(1);
                obj.Tarjeta.Estado = "1";
                obj.Tarjeta.InicioVigencia = DateTime.Now;
                obj.Tarjeta.FinVigencia = value;
                LNClientes.InsertarTarjeta(obj.Tarjeta);

                TempData["Tarjeta_Add"] = "Tarjeta Agregada";

            }
            else
            {
                DateTime value = new DateTime(Convert.ToInt32(obj.Tarjeta.anioFinVigencia), Convert.ToInt32(obj.Tarjeta.mesFinVigencia), 30);
                obj.Tarjeta.FechaVencimientoTarjeta = value;
                obj.Tarjeta.Token = "";
                obj.Tarjeta.FechaVencimientoToken = DateTime.Now.AddDays(1);
                obj.Tarjeta.Estado = "1";
                obj.Tarjeta.InicioVigencia = DateTime.Now;
                obj.Tarjeta.FinVigencia = value;
                LNClientes.ActualizarTarjeta(obj.Tarjeta);

                TempData["Tarjeta_Update"] = "Tarjeta Actualizada";
            }

            
            return RedirectToAction("Crear", "Clientes", new { id = obj.Tarjeta.CodigoCliente });

        }


        [SessionExpire]
        [HttpPost]
        public ActionResult EliminarTarjeta(VMClientes obj)
        {
            LNClientes.EliminarTarjeta(obj.Tarjeta.IdClienteTarjetas.ToString());
            TempData["Tarjeta_Remove"] = "Tarjeta Eliminada";
            return RedirectToAction("Crear", "Clientes", new { id = obj.Tarjeta.CodigoCliente });
        }



    }
}