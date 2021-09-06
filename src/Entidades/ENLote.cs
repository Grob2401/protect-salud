using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENLote
    {
        public string IdLote { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoContrato { get; set; }
        public string TitularCodigo { get; set; }
        public string TitularCategoria { get; set; }
        public string TitularTipoDocumento { get; set; }
        public string TitularNumeroDocumento { get; set; }
        public string TitularNombre { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteTipoIdentificacion { get; set; }
        public string ClienteNumeroIdentificacion { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicioCuota { get; set; }
        public DateTime FechaFinCuota { get; set; }
        public double ValorPrima { get; set; }
        public string IdCuota { get; set; }
        public string IdCuotaOrden { get; set; }
        public string IdTransaccion { get; set; }
        public string LOGCREUSER { get; set; }
        public string Estado { get; set; }
        public DateTime LOGCREDATE { get; set; }

        //Generacion_Texto
        public string RegDatos { get; set; }
        public string codigoTipoContrato { get; set; }
        public string FlagTmp { get; set; }
        public string TipoCliente { get; set; }
        public string IdBanco { get; set; }


    }
}