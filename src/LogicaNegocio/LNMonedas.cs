using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
   public class LNMonedas
    {
        public static List<ENMonedas> ObtenerTodos()
        {
            return new ADMonedas().ObtenerTodos();
         }
        public static bool Insertar(ENMonedas oENMonedas)
        {
            return (new ADMonedas()).Insertar(oENMonedas);
        }

        public static bool Actualizar(ENMonedas oENMonedas)
        {
            return (new ADMonedas()).Actualizar(oENMonedas);
        }

        public static bool Eliminar(string CodigoMoneda)
        {
            return (new ADMonedas()).Eliminar(CodigoMoneda);
        }

        public static ENMonedas ObtenerUno(string CodigoMoneda)
        {
            return (new ADMonedas()).ObtenerUno(CodigoMoneda);
        }
    }
}

