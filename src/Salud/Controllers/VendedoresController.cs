using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using System.EnterpriseServices;


namespace WebPlanesCS.Controllers
{
    public class VendedoresController : Controller
    {
        private LNVendedores LNVendedores = new LNVendedores();
        private LNSociedades LNSociedades = new LNSociedades();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLista()
        {
            var lstVendedores = LNVendedores.ObtenerTodos();
            return Json(new { data = lstVendedores.ToList() }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(string id =null)
        {
            if (id is null)
            {
                ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial");
                var ENVendedores = new ENVendedores();
                return View(ENVendedores);
            }
            else
            {
                ENVendedores mVendedorEditar = LNVendedores.ObtenerTodos().Find(smodel => smodel.CodigoVendedor == id);
                ViewBag.IdSociedad = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", mVendedorEditar.IdSociedad);
                return View(mVendedorEditar);
            }
        }

        public ActionResult AddOrEdit(ENVendedores pla)
        {
            if (pla.CodigoVendedor is  null)
            {
                if (LNVendedores.Insertar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return Json(new { success = true, message = "Grabado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (LNVendedores.Actualizar(pla))
                {
                    ViewBag.Message = "Registro Grabado Correctamente";
                    ModelState.Clear();
                }
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                if (LNVendedores.Eliminar(id))
                {
                    return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }


    }
}