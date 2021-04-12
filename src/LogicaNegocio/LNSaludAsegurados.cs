using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludAsegurados
    {
        public static List<ENSaludAsegurados> ObtenerTodos()
        {
            return new ADSaludAsegurados().ObtenerTodos();
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

