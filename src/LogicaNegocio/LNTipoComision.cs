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

    public class LNTipoComision
    {
        public static List<ENTipoComision> ObtenerTodos()
        {
            return new ADTipoComision().ObtenerTodos();
        }     
    }
}

