using Entidades;
using LogicaNegocio;
using Salud.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salud.Controllers
{
    public class PerfilesController : Controller
    {
        // GET: Perfiles
        public ActionResult Index()
        {
            ViewBag.Perfiles = LNPerfiles.ObtenerTodos("");
            ViewData["TiposCliente"] = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente","09");

            if (TempData["MensajeAgregarPerfil"] != null)
            {
                ViewBag.MensajeAddAfiliado = TempData["MensajeAgregarPerfil"];
                TempData["MensajeAgregarPerfil"] = null;
            }

            return View();
        }

        //####################BUSQUEDA
        [SessionExpire]
        [HttpPost]
        public ActionResult Index(string txtBusquedaPerfiles = "")
        {
            ViewBag.Perfiles = LNPerfiles.ObtenerTodos(txtBusquedaPerfiles);
            ViewData["TiposCliente"] = new SelectList(LNTipoCliente.ObtenerTodos().ToList(), "CodigoTipoCliente", "DescripcionTipoCliente", "09");
            return View();
        }

        // POST: Perfiles/Create
        [SessionExpire]
        [HttpPost]
        public ActionResult Guardar(ENPerfiles perfil)
        {
            if (ModelState.IsValid)
            {
                perfil.CodigoTipoCliente = "04";
                perfil.GeneraOrden = "0";
                if (perfil.CodigoPerfil != "" && perfil.CodigoPerfil != null)
                {
                    LNPerfiles.Actualizar(perfil);
                    TempData["Mensaje"] = "CORRECTO : Los datos han sido actualizados";
                }
                else
                {
                    LNPerfiles.Insertar(perfil);
                    TempData["Mensaje"] = "CORRECTO : Los datos han sido registrados";
                }
                return RedirectToAction("Index", "Perfiles");
            }

            return View();
        }
        
        // POST: Perfiles/Delete/5
        [HttpPost]
        public ActionResult Eliminar(string CodigoPerfil)
        {
            try
            {
                LNPerfiles.Eliminar(CodigoPerfil);
                TempData["Mensaje"] = "CORRECTO : Los datos han sido eliminados";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
