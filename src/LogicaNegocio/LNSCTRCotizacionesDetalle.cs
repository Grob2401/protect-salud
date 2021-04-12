using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSCTRCotizacionesDetalle
    {
        public static List<ENSCTRCotizacionesDetalle> ObtenerTodos()
        {
            return new ADSCTRCotizacionesDetalle().ObtenerTodos();
        }

        public static bool Insertar(ENSCTRCotizacionesDetalle oENSCTRCotizacionesDetalle)
        {
            return (new ADSCTRCotizacionesDetalle()).Insertar(oENSCTRCotizacionesDetalle);
        }

        public static bool Actualizar(ENSCTRCotizacionesDetalle oENSCTRCotizacionesDetalle)
        {
            return (new ADSCTRCotizacionesDetalle()).Actualizar(oENSCTRCotizacionesDetalle);
        }

        public static bool Eliminar(string Item)
        {
            return (new ADSCTRCotizacionesDetalle()).Eliminar(Item);
        }

        public static List<ENSCTRCotizacionesDetalle> ObtenerUno(string CodigoCotizacion,string Item)
        {
            return new ADSCTRCotizacionesDetalle().ObtenerUno(CodigoCotizacion,Item);
        }

    }
}

