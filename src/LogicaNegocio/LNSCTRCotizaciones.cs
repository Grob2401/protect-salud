using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSCTRCotizaciones
    {
        public static List<ENSCTRCotizaciones> ObtenerTodos()
        {
            return new ADSCTRCotizaciones().ObtenerTodos();
        }

        public static bool Insertar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {
            return (new ADSCTRCotizaciones()).Insertar(oENSCTRCotizaciones);
        }

        public static bool Actualizar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {
            return (new ADSCTRCotizaciones()).Actualizar(oENSCTRCotizaciones);
        }

        public static bool Eliminar(string CodigoCotizacion)
        {
            return (new ADSCTRCotizaciones()).Eliminar(CodigoCotizacion);
        }

        public static ENSCTRCotizaciones ObtenerUno(string CodigoCotizacion)
        {
            return (new ADSCTRCotizaciones()).ObtenerUno(CodigoCotizacion);
        }


        public static ENSCTRCotizaciones ObtenerUnoConDetalle(string CodigoCotizacion)
        {
            return (new ADSCTRCotizaciones()).ObtenerUnoConDetalle(CodigoCotizacion);
        }


        public static ENSCTRCotizaciones Cotizar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {
            return (new ADSCTRCotizaciones()).Cotizar(oENSCTRCotizaciones);
        }

    }
}
