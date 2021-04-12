using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSCTRCotizacionesDetalle
    {
        public string CodigoCotizacion { get; set; }
        public string CodigoTipoEmpleado { get; set; }
        public double ImporteDerechoEmision { get; set; }
        public double ImporteDerechoEmisionPension { get; set; }
        public double ImporteIGV { get; set; }
        public double ImporteIGVPension { get; set; }
        public double ImportePrimaNeta { get; set; }
        public double ImportePrimaNetaPension { get; set; }
        public double ImportePrimaTotal { get; set; }
        public double ImportePrimaTotalPension { get; set; }
        public string Item { get; set; }
        public string MontoPlanilla { get; set; }
        public int NumeroTrabajadores { get; set; }
        public double PorcentajeCorredor { get; set; }
        public double PorcentajeCorredorPension { get; set; }
        public double PorcentajeCorredorPensionOpe { get; set; }
        public double PorcentajeTasa { get; set; }
        public double PorcentajeTasaPension { get; set; }
        public double PorcentajeTasaPensionOpe { get; set; }
    }
}
