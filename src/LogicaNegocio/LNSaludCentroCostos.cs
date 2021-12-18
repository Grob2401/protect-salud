using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludCentroCostos
    {
        public static List<ENSaludCentroCostos> ObtenerTodos1(string CodigoCliente)
        {
            return new ADSaludCentroCostos().ObtenerTodos1(CodigoCliente);
        }

        public static int Cantidad(string CodigoCliente)
        {
            return new ADSaludCentroCostos().Cantidad(CodigoCliente);
        }

        public static List<ENSaludCentroCostos> ObtenerTodos(int page, int rows, string type, string Keywords, string CodigoCliente)
        {
            return new ADSaludCentroCostos().ObtenerTodos( page, rows, type,  Keywords, CodigoCliente);
        }

        public static bool Insertar(ENSaludCentroCostos oENSaludCentroCostos)
        {
            return (new ADSaludCentroCostos()).Insertar(oENSaludCentroCostos);
        }

        public static bool Actualizar(ENSaludCentroCostos oENSaludCentroCostos)
        {
            return (new ADSaludCentroCostos()).Actualizar(oENSaludCentroCostos);
        }

        public static bool Eliminar(string CodigoCliente,string CodigoCentroCosto)
        {
            return (new ADSaludCentroCostos()).Eliminar(CodigoCliente, CodigoCentroCosto);
        }

        public static ENSaludCentroCostos ObtenerUno(string CodigoCliente, string CodigoCentroCosto)
        {
            return (new ADSaludCentroCostos()).ObtenerUno(CodigoCliente, CodigoCentroCosto);
        }

        public static ENSaludCentroCostos ObtenerUnoCotizacion(string CodigoCliente, string CodigoCentroCosto,string CodigoCotizacion)
        {
            return (new ADSaludCentroCostos()).ObtenerUnoCotizacion(CodigoCliente, CodigoCentroCosto, CodigoCotizacion);
        }
    }
}


