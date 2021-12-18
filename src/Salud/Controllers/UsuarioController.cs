using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using Utilitarios;
using Salud.App_Start;
using System.Web.Security;

namespace Salud.Controllers
{

    public class UsuarioController : Controller
    {
        [SessionExpire]
        public ActionResult Index(int page = 0)
        {

            var contador = LNUsuario.Cantidad();
            ViewData["todos"] = contador;
            ViewData["ultimo"] = contador / 100;

            if (page != 0)
            {
                if (page < (contador / 100))
                {
                    ViewData["pageCount"] = page;
                }
                else
                {
                    ViewData["pageCount"] = contador / 100;
                }
            }

            if (ViewData["pageCount"] == null && page == 0)
            {
                ViewData["pageCount"] = 1;
                page = 1;
            }

            ViewBag.Usuarios = LNUsuario.ObtenerTodos(page, 100, "", "").OrderBy(x => x.RowNumber).ToList();

            var lista = LNSaludSexo.ObtenerTodos().ToList(); //new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
            int index = lista.FindIndex(s => s.CodigoSexo == "F");
            int index2 = lista.FindIndex(s => s.CodigoSexo == "M");

            if (index != -1)
            {
                lista[index].CodigoSexo = "0";
            }
            if (index2 != -1)
            {
                lista[index2].CodigoSexo = "1";
            }

            ViewData["Sexos"] = new SelectList(lista, "CodigoSexo", "DescripcionSexo");
            ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", Session["SociedadUsuario"]);
            ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil");

            if (TempData["Mensaje_Usuario"] != null)
            {
                ViewBag.Message = TempData["Mensaje_Usuario"];
                TempData["Mensaje_Usuario"] = "";
            }

            if (TempData["Mensaje_Usuario_Error"] != null)
            {
                ViewBag.Message1 = TempData["Mensaje_Usuario_Error"];
                TempData["Mensaje_Usuario_Error"] = "";
            }

            return View();
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Index(int page = 0, string txtBusquedaUsuarios = "")
        {
            ViewBag.Usuarios = LNUsuario.ObtenerTodos(1, 100, "", txtBusquedaUsuarios).OrderBy(x => x.RowNumber).ToList();
            var contador = LNUsuario.Cantidad();
            ViewData["todos"] = contador;
            ViewData["ultimo"] = contador / 100;

            if (page != 0)
            {
                if (page < (contador / 100))
                {
                    ViewData["pageCount"] = page;
                }
                else
                {
                    ViewData["pageCount"] = contador / 100;
                }
            }

            if (ViewData["pageCount"] == null && page == 0)
            {
                ViewData["pageCount"] = 1;
                page = 1;
            }


            var lista = LNSaludSexo.ObtenerTodos().ToList(); //new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
            int index = lista.FindIndex(s => s.CodigoSexo == "F");
            int index2 = lista.FindIndex(s => s.CodigoSexo == "M");

            if (index != -1)
            {
                lista[index].CodigoSexo = "0";
            }
            if (index2 != -1)
            {
                lista[index2].CodigoSexo = "1";
            }

            ViewData["Sexos"] = new SelectList(lista, "CodigoSexo", "DescripcionSexo");
            ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", Session["SociedadUsuario"]);
            ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil");

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Error = null;
            ViewBag.Estado = "hidden";
            if (Request.Cookies["Usuario"] != null)
            {

                var cookieUsu = Request.Cookies["Usuario"].Value;
                var cookieCla = Request.Cookies["Clave"].Value;

                if (cookieUsu != null && cookieCla != null)
                {
                    //string username = Server.HtmlEncode(cookie.Value);
                    ViewBag.Usuario = cookieUsu;
                    ViewBag.Clave = cookieCla;
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string usuario, string password, bool remember = false)
        {
            //usuario = "grojas@grojas.com";
            //password = "123456";

            HttpCookie usuCookie = new HttpCookie("Usuario");
            HttpCookie claCookie = new HttpCookie("Clave");

            if (remember == true)
            {
                usuCookie.Expires = DateTime.Now.AddMinutes(10);
                claCookie.Expires = DateTime.Now.AddMinutes(10);
            }
            else
            {
                usuCookie.Expires = DateTime.Now.AddDays(-1);
                claCookie.Expires = DateTime.Now.AddDays(-1);
            }

            Response.Cookies.Add(usuCookie);
            Response.Cookies.Add(claCookie);

            ViewBag.Error = null;
            ViewBag.Estado = "hidden";
            try
            {
                if (usuario == "" && password == "")
                {
                    ViewBag.Estado = "";
                    ViewBag.Error = "Advertencia , ingrese usuario y contraseña";
                }
                else
                {
                    ENUsuario usuarioLogin = LNUsuario.ObtenerPorCorreoElectronico(usuario);

                    if (usuarioLogin != null)
                    {
                        Crypto pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                        string decrypt = pwd.Decrypt(usuarioLogin.var_Password);
                        if (decrypt != password) 
                        {
                            ViewBag.Estado = "";
                            ViewBag.Error = "Contraseña ingresada incorrecta";
                            return View("Login");
                        }
                            
                        Session["IdUsuario"] = usuarioLogin.int_IdUsuario;
                        Session["NombreUsuario"] = string.Concat(usuarioLogin.var_Nombre, " ", usuarioLogin.var_Apellidos);
                        Session["SociedadUsuario"] = usuarioLogin.IdSociedad;
                        Session["DescripcionSociedadUsuario"] = usuarioLogin.DescripcionSociedad;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Estado = "";
                        ViewBag.Error = "Usuario ingresado incorrecto";
                    }
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


            var lista = LNSaludSexo.ObtenerTodos().ToList(); //new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
            int index = lista.FindIndex(s => s.CodigoSexo == "F");
            int index2 = lista.FindIndex(s => s.CodigoSexo == "M");

            if (index != -1)
            {
                lista[index].CodigoSexo = "0";
            }
            if (index2 != -1)
            {
                lista[index2].CodigoSexo = "1";
            }
        
            ViewData["Sexos"] = new SelectList(lista, "CodigoSexo", "DescripcionSexo");           
            ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", Session["SociedadUsuario"]);
            ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil");

            oENUsuario = new ENUsuario();
            oENUsuario.int_Estado = 1;

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

                if (usuario.CodigoSexo == "0") { usuario.bit_Sexo = false; } else { usuario.bit_Sexo = true; }

                if (usuario.var_DNI != null)
                {
                    LNUsuario.Insertar(usuario);
                    TempData["Mensaje_Usuario"] = "Usuario Registrado";
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
        public ActionResult Editar(int id = 0)
        {
            ENUsuario oENUsuario = null;

            oENUsuario = LNUsuario.ObtenerUno(id);
            var pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
            oENUsuario.var_Password = pwd.Decrypt(oENUsuario.var_Password);

            var lista = LNSaludSexo.ObtenerTodos().ToList(); //new SelectList(LNSaludSexo.ObtenerTodos().ToList(), "CodigoSexo", "DescripcionSexo");
            int index = lista.FindIndex(s => s.CodigoSexo == "F");
            int index2 = lista.FindIndex(s => s.CodigoSexo == "M");

            if (index != -1)
            {
                lista[index].CodigoSexo = "0";
            }
            if (index2 != -1)
            {
                lista[index2].CodigoSexo = "1";
            }

            if (oENUsuario.bit_Sexo != null)
            {
                if (oENUsuario.bit_Sexo == true) { oENUsuario.CodigoSexo = "1"; } else { oENUsuario.CodigoSexo = "0"; }
                ViewData["Sexos"] = new SelectList(lista, "CodigoSexo", "DescripcionSexo", oENUsuario.CodigoSexo);
            }

            ViewData["Sociedades"] = new SelectList(LNSociedades.ObtenerTodos().ToList(), "IdSociedad", "RazonSocial", oENUsuario.IdSociedad);
            ViewData["Perfiles"] = new SelectList(LNPerfiles.ObtenerTodos("").ToList(), "CodigoPerfil", "DescripcionPerfil", oENUsuario.CodigoPerfil);


            return View(oENUsuario);
        }

        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ENUsuario usuario)
        {

            if (ModelState.IsValid)
            {
                if (usuario.var_Password != null)
                {
                    var pwd = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                    usuario.var_Password = pwd.Encrypt(usuario.var_Password);
                }

                if (usuario.CodigoSexo == "0") { usuario.bit_Sexo = false; } else { usuario.bit_Sexo = true; }

                if (usuario.var_DNI != null)
                {
                    if (usuario.int_IdUsuario > 0)
                    {
                        LNUsuario.Actualizar(usuario);
                        TempData["Mensaje_Usuario"] = "Usuario Actualizado";
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
        //[ValidateAntiForgeryToken]
        public ActionResult Eliminar(int Id)
        {
            if (ModelState.IsValid)
            {
                LNUsuario.Eliminar(Id);
                var mensaje = "Excelente, Usuario Eliminado";
                //return RedirectToAction("Index", "Usuario");
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        [SessionExpire]
        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }
    }
}