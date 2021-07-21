using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web.Mvc;

namespace Salud.ViewModels
{
    public class VMAseguradosRegulares
    {
        public ENSaludAsegurados VMSaludAsegurado { get; set; }
        public List<ENSaludAsegurados> VMSaludAsegurados { get; set; }
    }
}