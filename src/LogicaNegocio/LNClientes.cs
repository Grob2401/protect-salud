using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNClientes
    {
        public static List<ENClientes> ObtenerTodos()
        {
            return new ADClientes().ObtenerTodos();
        }

        public static bool Insertar(ENClientes oENClientes)
        {
            return (new ADClientes()).Insertar(oENClientes);
        }

        public static bool Actualizar(ENClientes oENClientes)
        {
            return (new ADClientes()).Actualizar(oENClientes);
        }

        public static bool Eliminar(string CodigoCliente)
        {
            return (new ADClientes()).Eliminar(CodigoCliente);
        }

        public static ENClientes ObtenerUno(string CodigoCliente)
        {
            return (new ADClientes()).ObtenerUno(CodigoCliente);
        }

        public static ENClientes ObtenerUnoporRUC(string EmpresaRUC)
        {
            return (new ADClientes()).ObtenerUnoporRUC(EmpresaRUC);
        }
    }
}

