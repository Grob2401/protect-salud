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

    public class LNSociedades
    {
        public static List<ENSociedades> ObtenerTodos()
        {
            return new ADSociedades().ObtenerTodos();
        }


        public static ENSociedades ObtenerUno(int IdSociedad)
        {
            return new ADSociedades().ObtenerUno(IdSociedad);
        }
        public static bool Insertar(ENSociedades oENSociedades)
        {
            return (new ADSociedades()).Insertar(oENSociedades);
        }

        public static bool Actualizar(ENSociedades oENSociedades)
        {
            return (new ADSociedades()).Actualizar(oENSociedades);
        }

        public static bool Eliminar(int IdSociedad)
        {
            return (new ADSociedades()).Eliminar(IdSociedad);
        }
    }
}

