using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSCTRCorredor
    {
        public string CodigoCorredor { get; set; }
        public string DescripcionCorredor { get; set; }
    }
}
