using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entidades
 {
 
public class ENSaludParentesco
{
public string CodigoCategoria { get; set; }
public string CodigoParentesco { get; set; }
public string DescripcionParentesco { get; set; }
public int OrderParentesco { get; set; }
 }
}
