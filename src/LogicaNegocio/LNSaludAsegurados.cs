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

        public static List<ENSaludAsegurados> ObtenerSaludAsegurados(int page, int rows, string Keywords, string tipoConsulta,string tipoCliente, string codCliente, string codTitular, string codDependiente, string codContrato)
        {
            return (new ADSaludAsegurados()).ObtenerSaludAsegurados(page, rows, Keywords, tipoConsulta,tipoCliente, codCliente,codTitular,codDependiente,codContrato);
        }

        public static List<ENSaludAsegurados> ObtenerSaludAseguradosIndependientesPagos(string codContrato)
        {
            return (new ADSaludAsegurados()).ObtenerSaludAseguradosIndependientesPagos(codContrato);
        }

        public static List<ENSaludAseguradosContratosPagos> ObtenerSaludAseguradosCuotasNoPagadas(string codCliente, string codTitular, string categoria, string codContrato)
        {
            return (new ADSaludAsegurados()).ObtenerSaludAseguradosCuotasNoPagadas(codCliente,codTitular,categoria,codContrato);
        }

        public static List<ENSaludAseguradosContratosPagos> ObtenerAseguradosTodasCuotas(string codCliente, string codTitular, string categoria, string codContrato)
        {
            return (new ADSaludAsegurados()).ObtenerAseguradosTodasCuotas(codCliente, codTitular, categoria, codContrato);
        }

        public static bool validarCuotas(string cliente, string titular, string categoria, string fechaFin)
        {
            return (new ADSaludAsegurados()).validarCuotas(cliente, titular, categoria, fechaFin);
        }

        public static bool VerificarMontoIndependientes(string cliente, string titular, string categoria, string codigoContrato, string fechaInicio, double monto)
        {
            return (new ADSaludAsegurados()).VerificarMontoIndependientes(cliente, titular, categoria, codigoContrato,fechaInicio,monto);
        }

        public static bool WebService_Log(string cliente, string titular, string categoria, string ws_metodo, string ws_request, string ws_response, string response_codigo, string response_descripcion, string usuario)
        {
            return (new ADSaludAsegurados()).WebService_Log(cliente, titular, categoria, ws_metodo, ws_request, ws_response, response_codigo, response_descripcion, usuario);
        }
    }
}

