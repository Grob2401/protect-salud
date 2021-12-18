using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ENVendedores
    {
        public int RowNumber { get; set; }
        public string CodigoVendedor { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Direccion { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CodigoUsuario { get; set; }
        public string CodigoPerfil { get; set; }
        public int IdPersona { get; set; }

        [Display(Name = "Sociedad")]
        public int IdSociedad { get; set; }

        [NotMapped]
        public int IdPersonaSociedad { get; set; }

        [Display(Name = "RazonSocial")]
        public String RazonSocial { get; set; }

        public string DescripcionVendedor { get; set; }

        //VENDEDOR_COMISION

        public DateTime Comision_fechaInicio { get; set; }

        public DateTime Comision_FechaFin { get; set; }

        public int Comision_Cantidad { get; set; }

        public int Comision_Idtipo { get; set; }

        public string Comision_Tipo_Descripcion { get; set; }

        public string Comision_CodigoVendedor { get; set; }
        public string Vendedor { get; set; }



    }
}