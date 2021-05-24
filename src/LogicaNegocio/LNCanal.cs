using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNCanal
    {
        public static List<ENCanales> ObtenerTodos(string sociedad)
        {
            return new ADCanal().ObtenerTodos(sociedad);
        }

        public static bool Insertar(ENCanales oENCanales)
        {
            return (new ADCanal()).Insertar(oENCanales);
        }

        public static bool Actualizar(ENCanales oENCanales)
        {
            return (new ADCanal()).Actualizar(oENCanales);
        }
        public static bool Eliminar(int IdCanal)
        {
            return (new ADCanal()).Eliminar(IdCanal);
        }

        public static bool InsertarComision(ENCanales oENCanalComision)
        { 
            return (new ADCanal()).InsertarComision(oENCanalComision);
        }

    }
}
