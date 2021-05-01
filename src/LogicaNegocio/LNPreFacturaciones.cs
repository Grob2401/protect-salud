using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNPreFacturaciones
    {
        public static List<ENPreFacturacion> ObtenerTodos(string anio, string mes, string desde, string hasta, string option)
        {
            return new ADPrefacturaciones().ObtenerTodos(anio,mes,desde,hasta,option);
        }

        public static List<ENPrefacturacionDetalleContratos> Contratos(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).Contratos( anio,  mes,  psespecial,  status,  cliente,  tipoAseg);
        }

    }
}
