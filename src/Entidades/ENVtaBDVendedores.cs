using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENVtaBDVendedores
{
public string ApellidoMaterno { get; set; }
public string ApellidoPaterno { get; set; }
public string CodigoPerfil { get; set; }
public string CodigoUsuario { get; set; }
public string CodigoVendedor { get; set; }
public string Direccion { get; set; }
public string Email { get; set; }
public string EstadoRegistro { get; set; }
public string FechaBaja { get; set; }
public DateTime Fechaing { get; set; }
public DateTime flag { get; set; }
public string ID_perfil { get; set; }
public int IdPersona { get; set; }
public int IdSociedad { get; set; }
public string Nombres { get; set; }
public string Perfil { get; set; }
public string Telefono { get; set; }
 }
}
