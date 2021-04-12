using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ENMonedas
    {
        public string CodigoMoneda { get; set; }
        public string DescripcionMoneda { get; set; }
    }
}
