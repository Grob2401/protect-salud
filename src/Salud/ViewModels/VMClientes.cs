using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;

namespace Salud.ViewModels
{
    public class VMClientes
    {
        public List<ENClientes> ListaClientes { get; set; }
        public ENClientes Clientes { get; set; }
        public List<ENUbigeoCompleto> ListaUbigeo { get; set; }
        public ENUbigeoCompleto Ubigeo { get; set; }
        public ENTarjeta Tarjeta { get; set; }
        public List<ENTarjeta> ListaTarjetas { get; set; }

    }
}