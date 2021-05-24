using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ENCanalesVendedores
    {
        public int CV_IDCanal { get; set; }
        public int CV_IdSociedad { get; set; }
        public string CV_CodigoVendedor { get; set; }
        public string CV_DescripcionCanal { get; set; }
        public DateTime CV_FechaInicioCanalVendedor { get; set; }
        public DateTime CV_FechaFinCanalVendedor { get; set; }
        public string CV_Vendedor { get; set; }
        public string CV_PaternoVendedor { get; set; }
        public string CV_MaternoVendedor { get; set; }
        public string CV_NombresVendedor { get; set; }
        public string CV_Telefono { get; set; }
        public string CV_Email { get; set; }
        public string Vendedor_TipoComi { get; set; }
        public string Vendedor_CantComi { get; set; }
        public string Canal_TipoComi { get; set; }
        public string Canal_CantComi { get; set; }

        
            
            
            

    }
}
