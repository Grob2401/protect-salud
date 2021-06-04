using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENDatosPreFacBusqueda
    {
        public string anio { get; set; }
        public string mes { get; set; }
        public string txtdesde { get; set; }
        public string txthasta { get; set; }
        public int option { get; set; }
        //040521
        public int status { get; set; }    
        public int codigoCliente { get; set; }
        public int descripcionTipoAseg { get; set; }
        public string mensajeEPF { get; set; }
        public string PcsStatus { get; set; }
    }
}
