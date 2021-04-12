using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web.Mvc;


namespace Salud.ViewModels
{
    public class VMSaludContratos
    {
        public List<ENSaludContratos> VMListaSaludContratos { get; set; }
        public ENSaludContratos SaludContratosVM { get; set; }
        public List<ENSaludPlanes> VMListaSaludPlanes { get; set; }
        public ENSaludPlanes SaludPlanesVM { get; set; }
     
        public ENSaludContratoPlan SaludContratosPlanVM { get; set; }
        public List<ENSaludContratoPlan> VMListaSaludContratosPlan { get; set; }

    }
}