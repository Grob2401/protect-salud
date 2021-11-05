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
    public class LNMotivoBaja
    {
        public static List<ENMotivoBaja> ObtenerTodos()
        {
            return (new ADMotivoBaja()).ObtenerTodos();
        }        
    }
}




