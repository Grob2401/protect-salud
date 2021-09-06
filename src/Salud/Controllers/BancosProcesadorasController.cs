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
    public class BancosProcesadorasController : Controller
    {
        // GET: BancosProcesadoras
        public ActionResult Index()
        {
            ViewBag.Bancos = new SelectList(LNBanco.ObtenerTodos().ToList(), "IdBanco", "NombreBanco");
            var lista = LNLote.ObtenerTodos();
            ViewBag.Lotes = lista;
            ViewBag.Loteid = lista.FirstOrDefault().IdLote;

            return View();
        }

        [HttpGet]
        [SessionExpire]
        public ActionResult GenerarTexto(string banco, string lote)
        {
            var trama = LNLote.generarTexto(banco,lote);
            var ruta = LNLote.TraeValores(banco);

            var texto = "";

            foreach (var item in trama)
            {
                texto += item.RegDatos + System.Environment.NewLine;
            }

            object[] arr = new object[2];
            arr[0] = texto;
            arr[1] = ruta;

            return Json(arr, JsonRequestBehavior.AllowGet);
        }
    }
}