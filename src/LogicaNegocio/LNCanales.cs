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
    public class LNCanales
    {
        public static bool Insertar(ENCanales oENCanales)
        {
            return (new ADCanales()).Insertar(oENCanales);
        }
        public static List<ENCanales> ObtenerTodos()
        {
            return new ADCanales().ObtenerTodos();
        }

        public static ENCanales ObtenerUno(int IdCanal)
        {
            return new ADCanales().ObtenerUno(IdCanal);
        }



        public static bool Eliminar(int IdCanal)
        {
            return (new ADCanales()).Eliminar(IdCanal);
        }
        public static bool Actualizar(ENCanales oENCanales)
        {
            return (new ADCanales()).Actualizar(oENCanales);
        }
    }
}




