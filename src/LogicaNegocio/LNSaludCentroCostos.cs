using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludCentroCostos
    {
        public static List<ENSaludCentroCostos> ObtenerTodos(string CodigoCliente)
        {
            return new ADSaludCentroCostos().ObtenerTodos(CodigoCliente);
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


