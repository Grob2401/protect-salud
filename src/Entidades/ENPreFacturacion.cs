using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENPreFacturacion
    {
        public string CodigoCliente { get; set; }
        public string RucDni { get; set; }
        public string RazonSocial { get; set; }
        public string DescripcionTipoAsegurado { get; set; }
        public string RegCounts { get; set; }
        public double AporteAfiliados { get; set; }
        public double AporteEmpresas { get; set; }
    }
}
