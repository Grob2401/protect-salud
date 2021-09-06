using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNMarcaTarjeta
    {
        public static List<ENMarcaTarjeta> ObtenerTodos()
        {
            return new ADMarcaTarjeta().ObtenerTodos();
        }
    }
}
