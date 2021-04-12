using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSCTREjecutivos
    {
        public string CodigoEjecutivo { get; set; }
        public string CodigoVendedor { get; set; }
        public string Destino { get; set; }
        public string NombreEjecutivo { get; set; }
    }
}
