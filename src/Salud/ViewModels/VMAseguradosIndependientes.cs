using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salud.ViewModels
{
    public class VMAseguradosIndependientes
    {
        public ENSaludAsegurados VMSaludAsegurado { get; set; }
        public ENSaludContratos VMSaludContrato { get; set; }
        public ENSaludAseguradosContratosPagos VMSaludAseguradosContratos { get; set; }
    }
}