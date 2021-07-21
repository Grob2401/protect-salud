using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSaludContratoAsegurado
    {
        public string CodContrato { get; set; }
        public string CodCliente { get; set; }
        public string CodTitular { get; set; }
        public string CodCategoria { get; set; }
        public string CodTrabajador { get; set; }
        public string CodigoTipoTrabajador { get; set; }
        public string CodParent { get; set; }
        public string Parent { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public string Nombre { get; set; }
        public string ApeNom { get; set; }
        public string Asegurado { get; set; }
        public string Edad { get; set; }
        public string FchAlta { get; set; }
        public string FchBaja { get; set; }
        public string CodigoUbigeo { get; set; }
    }
}
