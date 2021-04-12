using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENSaludContratoPlan
{
public string CodigoContrato { get; set; }
public string CodigoPlanSC { get; set; }
public DateTime FechaFinContratoPlan { get; set; }
public DateTime FechaInicioContratoPlan { get; set; }
public string CodigoCliente { get; set; }
public string DescripcionPlanSC{ get; set; }

    }
}
