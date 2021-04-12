using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENSaludPlanes
{
public string Capa { get; set; }
public string Clase { get; set; }
public string CodigoPlan { get; set; }
public string CreadoPor { get; set; }
public string DescripcionPlan { get; set; }
public DateTime FechaCreacion { get; set; }
public DateTime FechaModificacion { get; set; }
public DateTime FinVigencia { get; set; }
public DateTime InicioVigencia { get; set; }
public string ModificadoPor { get; set; }
public string Mostrar { get; set; }
public string Observaciones { get; set; }
public string Oncologico { get; set; }
public string TipoPlan { get; set; }
 }
}
