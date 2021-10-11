using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades
{
    public class ENPerfiles
    {
        public string CodigoPerfil { get; set; }
        public string DescripcionPerfil { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string GeneraOrden { get; set; }
        public string CodigoTipoCliente { get; set; }
        public string DescripcionCorta { get; set; }
        public string NivelAtencion { get; set; }

    }
}
