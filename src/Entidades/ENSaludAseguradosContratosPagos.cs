using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSaludAseguradosContratosPagos
    {
        public string IdCuota { get; set; }
        public string CodigoTitular { get; set; }
        public string CodigoCliente { get; set; }
        public string Categoria { get; set; }
        public string CodigoContrato { get; set; }
        public DateTime FechaInicioCuota { get; set; }
        public DateTime FechaFinCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public string CodigoTipoDocumentoPago { get; set; }
        public string DescripcionTipoDocumentoPago { get; set; }
        public string NumeroDocumentoPago { get; set; }
        public string Monto { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}