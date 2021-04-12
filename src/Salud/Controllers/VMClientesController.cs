using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using LogicaNegocio; 
using Utilitarios;
using Salud.ViewModels;

namespace Salud.Controllers
{
    public class VMClientesController : Controller
    {
        // GET: VMClientes
        public ActionResult Index()
        {
            //var VMCliente = new List<ENClientes>();
            //var VMUbigeo = new List<ENUbigeoCompleto>();
            var VMCliente = new ENClientes();
            var VMUbigeo = new ENUbigeoCompleto();
            var ClienteViewModel = new VMClientes
            {
                Clientes = VMCliente,
                Ubigeo = VMUbigeo
            };

            return View(ClienteViewModel);
        }
    }
}