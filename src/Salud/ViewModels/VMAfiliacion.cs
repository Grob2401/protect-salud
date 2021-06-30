using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web.Mvc;

namespace Salud.ViewModels
{
    public class VMAfiliacion
    {

        public ENClientes VMCliente { get; set; }
        public ENSaludContratos VMContrato { get; set; }
        public ENSaludAsegurados VMSaludAsegurado { get; set; }
        public List<ENSaludAsegurados> VMSaludAsegurados { get; set; }
    }
}