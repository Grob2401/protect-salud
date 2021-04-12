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
    public class ENSociedades
    {
        public string CodigoIAFAS { get; set; }
        public int IdSociedad { get; set; }

        [Display(Name = "RazonSocial")]
        public int IdPersona { get; set; }

        [NotMapped]
        [Display(Name = "RazonSocial")]
        public String RazonSocial { get; set; }

    }
}
