using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSaludCentroCostos
    {
        public int RowNumber { get; set; }
        public string CodigoCentroCosto { get; set; }

        public string CodigoCliente { get; set; }
        public string DescripcionCentroCosto { get; set; }

        [NotMapped]
        [Display(Name = "RazonSocial")]
        public string RazonSocial { get; set; }

        [NotMapped]
        [Display(Name = "RUC")]
        public string RUC { get; set; }

    }
}