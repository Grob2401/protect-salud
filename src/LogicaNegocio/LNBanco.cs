using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNBanco
    {

        public static List<ENBanco> ObtenerTodos()
        {
            return new ADBanco().ObtenerTodos();
        }

      
    }
}

