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
        public static List<ENPreFacturacion> ObtenerTodos(ENDatosPreFacBusqueda enf)
        {
            return new ADPrefacturaciones().ObtenerTodos(enf);
        }

        public static List<ENPrefacturacionDetalleContratos> Contratos(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).Contratos( anio,  mes,  psespecial,  status,  cliente,  tipoAseg);
        }

        public static bool Generar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).Generar(anio, mes, psespecial, status, cliente, tipoAseg);
        }

        public static bool Aprobar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).Aprobar(anio, mes, psespecial, status, cliente, tipoAseg);
        }

        public static bool ctaCorriente(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).ctaCorriente(anio, mes, psespecial, status, cliente, tipoAseg);
        }

        public static bool Facturar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {
            return (new ADPrefacturaciones()).Facturar(anio, mes, psespecial, status, cliente, tipoAseg);
        }

    }
}
