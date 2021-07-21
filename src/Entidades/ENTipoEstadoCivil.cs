using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENTipoEstadoCivil
    {
        public string CodigoTipoEstadoCivil { get; set; }
        public string DescripcionTipoEstadoCivil { get; set; }
    }
}
