using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludAsegurados
    {
        public static List<ENSaludAsegurados> ObtenerTodos(int page = 1, string keywords = "")
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["RowsPerPage"], out int rowsPerPage)) rowsPerPage = 0;
            return new ADSaludAsegurados().ObtenerTodos(page, rowsPerPage, keywords);
        }

        public static int Cantidad()
        {
            return (new ADSaludAsegurados()).Cantidad();
        }

        public static bool Insertar(ENSaludAsegurados oENSaludAsegurados)
        {
            return (new ADSaludAsegurados()).Insertar(oENSaludAsegurados);
        }

        public static bool Actualizar(ENSaludAsegurados oENSaludAsegurados)
        {
            return (new ADSaludAsegurados()).Actualizar(oENSaludAsegurados);
        }

        public static bool Eliminar(string CodigoCliente,string CodigoTitular,string Categoria)
        {
            return (new ADSaludAsegurados()).Eliminar(CodigoCliente,CodigoTitular,Categoria);
        }

        public static ENSaludAsegurados ObtenerUno(string CodigoCliente, string CodigoTitular, string Categoria)
        {
            return (new ADSaludAsegurados()).ObtenerUno(CodigoCliente, CodigoTitular, Categoria);
        }
    }
}

