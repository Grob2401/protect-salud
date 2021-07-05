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
        public static List<ENSaludAsegurados> ObtenerTodos(int page = 1, int rowsPerPage = 100, string keywords = "")
        {
            return (new ADSaludAsegurados()).ObtenerTodos(page, rowsPerPage, keywords);
        }

        public static int Cantidad(string keywords)
        {
            return (new ADSaludAsegurados()).Cantidad(keywords ?? string.Empty);
        }

        public static string Insertar(ENSaludAsegurados oENSaludAsegurados,string ope)
        {
            return (new ADSaludAsegurados()).Insertar(oENSaludAsegurados,ope);
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

        public static List<ENSaludAsegurados> ObtenerSaludAsegurados(string tipoConsulta, string codCliente, string codTitular, string codDependiente, string codContrato)
        {
            return (new ADSaludAsegurados()).ObtenerSaludAsegurados(tipoConsulta,codCliente,codTitular,codDependiente,codContrato);
        }
    }
}

