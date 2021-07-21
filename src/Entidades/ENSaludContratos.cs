using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENSaludContratos
{
public string CodigoCliente { get; set; }
public string CodigoContrato { get; set; }
public string CodigoCorredor { get; set; }
public string CodigoCotizacion { get; set; }
public string CodigoEjecutivo { get; set; }
public string CodigoTipoContrato { get; set; }
public string CodigoTipoPrima { get; set; }        
public DateTime FinVigencia { get; set; }
public string FlagTmp { get; set; }
public DateTime InicioVigencia { get; set; }
public string DescripcionCorredor { get; set; }
public string DescripcionEjecutivo { get; set; }

        [NotMapped]
        [Display(Name = "RazonSocial")]
        public string RazonSocial { get; set; }
        [NotMapped]
        [Display(Name = "RUC")]
        public string RUC { get; set; }
    }
}
