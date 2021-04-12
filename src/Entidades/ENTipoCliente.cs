using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENTipoCliente
{
public string CampoClave { get; set; }
public string CodigoTipoCliente { get; set; }
public string DescripcionTipoCliente { get; set; }
public string MostrarLogin { get; set; }
public string NombreTabla { get; set; }
 }
}
