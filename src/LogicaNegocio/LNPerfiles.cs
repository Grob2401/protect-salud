using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNPerfiles
    {
        public static List<ENPerfiles> ObtenerTodos(string busqueda)
        {
            return new ADPerfiles().ObtenerTodos(busqueda);
        }

        public static int Cantidad()
        {
            return new ADPerfiles().Cantidad();
        }

        public static bool Insertar(ENPerfiles oENPerfiles)
        {
            return (new ADPerfiles()).Insertar(oENPerfiles);
        }

        public static bool Actualizar(ENPerfiles oENPerfiles)
        {
            return (new ADPerfiles()).Actualizar(oENPerfiles);
        }

        public static bool Eliminar(string CodigoPerfil)
        {
            return (new ADPerfiles()).Eliminar(CodigoPerfil);
        }

        public static ENPerfiles ObtenerUno(string CodigoPerfil)
        {
            return (new ADPerfiles()).ObtenerUno(CodigoPerfil);
        }
    }
}

