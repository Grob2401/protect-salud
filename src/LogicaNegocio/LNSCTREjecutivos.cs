using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSCTREjecutivos
    {
        public static List<ENSCTREjecutivos> ObtenerTodos()
        {
            return new ADSCTREjecutivos().ObtenerTodos();
        }

        public static bool Insertar(ENSCTREjecutivos oENSCTREjecutivos)
        {
            return (new ADSCTREjecutivos()).Insertar(oENSCTREjecutivos);
        }

        public static bool Actualizar(ENSCTREjecutivos oENSCTREjecutivos)
        {
            return (new ADSCTREjecutivos()).Actualizar(oENSCTREjecutivos);
        }

        public static bool Eliminar(string CodigoEjecutivo)
        {
            return (new ADSCTREjecutivos()).Eliminar(CodigoEjecutivo);
        }

        public static ENSCTREjecutivos ObtenerUno(string CodigoEjecutivo)
        {
            return (new ADSCTREjecutivos()).ObtenerUno(CodigoEjecutivo);
        }
    }
}

