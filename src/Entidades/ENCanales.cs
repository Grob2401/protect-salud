using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ENCanales
    {
        public int IDCanal { get; set; }
        public string DescripcionCanal { get; set; }
        [Display(Name = "Sociedad")]
        public int IdSociedad { get; set; }

        [Display(Name = "IdPersonaSociedad")]
        public int IdPersona { get; set; }

        [NotMapped]
        [Display(Name = "RazonSocial")]
        public string RazonSocial { get; set; }

        //CANAL_COMISION
        public DateTime Comision_fechaInicio { get; set; }

        public DateTime Comision_FechaFin { get; set; }

        public int Comision_Cantidad { get; set; }

        public int Comision_Idtipo { get; set; }

        public string Comision_Tipo_Descripcion { get; set; }

        public string Comision_IDCanal { get; set; }

    }
}
