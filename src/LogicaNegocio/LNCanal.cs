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
        public static List<ENCanales> ObtenerTodos()
        {
            return new ADCanal().ObtenerTodos();
        }
    }
}
