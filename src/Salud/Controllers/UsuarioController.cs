using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;

namespace Salud.Controllers
{

    public class UsuarioController : Controller
    {
        [SessionExpire]
        public ActionResult Index()
        {
            ViewBag.Usuarios = LNUsuario.ObtenerTodos();
            ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial");
            ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil");
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string usuario, string password)
        {
            //usuario = "grojas@grojas.com";
            //password = "123456";
            try
            {
                ENUsuario usuarioLogin = LNUsuario.ObtenerPorCorreoElectronico(usuario);

                if (usuarioLogin != null)
                {
                    Crypto pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                    string decrypt = pwd.Decrypt(usuarioLogin.var_Password);
                    if (decrypt != password)
                        return View("Login");
                    Session["NombreUsuario"] = string.Concat(usuarioLogin.var_Nombre, " ", usuarioLogin.var_Apellidos);
                    Session["SociedadUsuario"] = usuarioLogin.IdSociedad;
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception ex)
            {
                return View("Login");
            }

            return View("Login");
        }
        [SessionExpire]
        public ActionResult Crear(int id = 0)
        {
            ENUsuario oENUsuario = null;
            if (id > 0) 
            { 
                oENUsuario = LNUsuario.ObtenerUno(id);
                var pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                oENUsuario.var_Password = pwd.Decrypt(oENUsuario.var_Password);
                ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", oENUsuario.IdSociedad);
                ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil", oENUsuario.CodigoPerfil);
            }
            else
            {
                oENUsuario = new ENUsuario();
                oENUsuario.int_Estado = 1;
            }
            return View(oENUsuario);
        }
        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ENUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.var_Password != null)
                {
                    var pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                    usuario.var_Password = pwd.Encrypt(usuario.var_Password);
                }

                if (usuario.var_DNI != null)
                {
                    if (usuario.int_IdUsuario > 0)
                    {
                        LNUsuario.Actualizar(usuario);
                    }
                    else
                    {

                        LNUsuario.Insertar(usuario);
                    }

                    return RedirectToAction("Index", "Usuario");
                }

                else
                {
                    usuario.bit_Sexo = true;
                }
                

            }

            return View();
        }
        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int Id)
        {
            if (ModelState.IsValid)
            {
                    LNUsuario.Eliminar(Id);
               
                return RedirectToAction("Index", "Usuario");
            }

            return View();
        }
    }
}