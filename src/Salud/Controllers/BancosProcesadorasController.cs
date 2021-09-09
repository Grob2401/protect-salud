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
using System.IO;

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

        public ActionResult Recepcion()
        {
            ViewBag.Bancos = new SelectList(LNBanco.ObtenerTodos().ToList(), "IdBanco", "NombreBanco");
            var lista = LNLote.ObtenerTodos();
            ViewBag.Lotes = lista;
            ViewBag.Loteid = lista.FirstOrDefault().IdLote;
            ViewBag.tramas = null;
            if (TempData["Tramas"] != null)
            {
                ViewBag.tramas = TempData["Tramas"];
            }
            
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

        [HttpPost]
        [SessionExpire]
        public ActionResult LeerTexto(HttpPostedFileBase fileArchivo)
        {
            var str = new StreamReader(fileArchivo.InputStream).ReadToEnd();
            List<ENLote> archivo = new List<ENLote>();

            foreach (var item in str.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                ENLote linea = new ENLote();
                linea.RegDatos = item;
                archivo.Add(linea);
            }
            archivo.RemoveAt(0);
            TempData["Tramas"] = archivo;


            //List<string> list = new List<string>(str.Split(new string[] { "\r\n" },StringSplitOptions.None));

            //list.RemoveAt(0);
            //TempData["Tramas"] = list;

            return RedirectToAction("Recepcion");
        }

//        @using(Html.BeginForm("Index", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
//{
//    <input type = "file" name="file" />
//    <input type = "submit" value="OK" />
//}
        
    }
}