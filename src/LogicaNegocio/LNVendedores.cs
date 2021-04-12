using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNVendedores
    {
        public static List<ENVendedores> ObtenerTodos()
        {
            return new ADVendedores().ObtenerTodos();
        }

        public static bool Insertar(ENVendedores oENVendedores)
        {
            return (new ADVendedores()).Insertar(oENVendedores);
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

