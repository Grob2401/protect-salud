using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSCTRCorredor
    {
        public static List<ENSCTRCorredor> ObtenerTodos()
        {
            return new ADSCTRCorredor().ObtenerTodos();
        }

        public static bool Insertar(ENSCTRCorredor oENSCTRCorredor)
        {
            return (new ADSCTRCorredor()).Insertar(oENSCTRCorredor);
        }

        public static bool Actualizar(ENSCTRCorredor oENSCTRCorredor)
        {
            return (new ADSCTRCorredor()).Actualizar(oENSCTRCorredor);
        }

        public static bool Eliminar(string CodigoCorredor)
        {
            return (new ADSCTRCorredor()).Eliminar(CodigoCorredor);
        }

        public static ENSCTRCorredor ObtenerUno(string CodigoCorredor)
        {
            return (new ADSCTRCorredor()).ObtenerUno(CodigoCorredor);
        }
    }
}

