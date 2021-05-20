using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNVendedor
    {
        public static List<ENVendedores> ObtenerTodos(string sociedad)
        {
            return new ADVendedor().ObtenerTodos(sociedad);
        }

        public static bool Insertar(ENVendedores oENVendedores)
        {
            return (new ADVendedor()).Insertar(oENVendedores);
        }

        public static bool Actualizar(ENVendedores oENVendedores)
        {
            return (new ADVendedor()).Actualizar(oENVendedores);
        }

        public static bool Eliminar(string CodigoVendedor)
        {
            return (new ADVendedor()).Eliminar(CodigoVendedor);
        }
        public static bool Asignar(ENCanalesVendedores oENCV)
        {
            return (new ADVendedor()).Asignar(oENCV);
        }

        public static List<ENCanalesVendedores> ObtenerAsignados(string sociedad)
        {
            return new ADVendedor().ObtenerAsignados(sociedad);
        } 

    }
}
