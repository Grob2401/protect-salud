using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENClientes
    {
        public int RowNumber { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorredor { get; set; }
        public string DescripcionCorredor { get; set; }
        public string CodigoEjecutivo { get; set; }
        public string DescripcionEjecutivo { get; set; }
        public string CodigoTipoCliente { get; set; }
        public string CodigoUsuario { get; set; }
        public string CorredorAgenciado { get; set; }
        public string Direccion { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Materno { get; set; }
        public string NombreCorto { get; set; }
        public string Nombres { get; set; }
        public string PaginaWeb { get; set; }
        public string Paterno { get; set; }
        public string PersonaContacto { get; set; }
        public string PersonaContactoCobranza { get; set; }
        public string RazonSocial { get; set; }
        public string RucDni { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Ubicubi { get; set; }

        public string CodigoDpto { get; set; }
        public string DescripcionDpto { get; set; }
        public string CodigoProv { get; set; }
        public string DescripcionProv { get; set; }
        public string CodigoDist { get; set; }
        public string DescripcionDist { get; set; }
        public string CodigoDocumentoIdentidad { get; set; }

    }
}

