using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENPrefacturacionDetalleContratos
    {
        public string CodigoCliente { get; set; }
        public string CodigoPlan { get; set; }
        public string CodigoTitular { get; set; }
        public string Categoria { get; set; }
        public string CodigoTipoTrabajador { get; set; }
        public DateTime FchIniAsgContrato { get; set; }
        public DateTime FchNacimiento { get; set; }
        public string Titular { get; set; }
        public string Asegurado { get; set; }
        public string DescripcionTipoAsegurado { get; set; }
        public string CodigoPrima { get; set; }
        public string DescripcionPrima { get; set; }
        public double AporteAfiliado { get; set; }
        public int PcsStatus { get; set; }
        public string estado { get; set; }

    }
}
