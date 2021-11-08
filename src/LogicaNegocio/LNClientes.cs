using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNClientes
    {
        public static int Cantidad()
        {
            return new ADClientes().Cantidad();
        }

        public static List<ENClientes> ObtenerTodos(int page, int rows, string type, string Keywords)
        {
            return new ADClientes().ObtenerTodos( page,  rows,  type,  Keywords);
        }

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

        public static List<ENTarjeta> ObtenerTarjetas(string id)
        {
            return (new ADClientes()).ObtenerTarjetas(id);
        }

        public static bool InsertarTarjeta(ENTarjeta oENTarjeta)
        {
            return (new ADClientes()).InsertarTarjeta(oENTarjeta);
        }

        public static bool ActualizarTarjeta(ENTarjeta oENTarjeta)
        {
            return (new ADClientes()).ActualizarTarjeta(oENTarjeta);
        }

        public static bool EliminarTarjeta(string id)
        {
            return (new ADClientes()).EliminarTarjeta(id);
        }

        



    }
}

