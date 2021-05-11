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
        public static List<ENVendedores> ObtenerTodos()
        {
            return new ADVendedor().ObtenerTodos();
        }

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
            return (new ADVendedores()).Actualizar(oENVendedores);
        }

        public static bool Eliminar(string CodigoVendedor)
        {
            return (new ADVendedores()).Eliminar(CodigoVendedor);
        }
    }
}
