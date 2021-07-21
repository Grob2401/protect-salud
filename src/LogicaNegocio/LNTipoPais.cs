using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNTipoPais
    {
    public static List<ENTipoPais> ObtenerTodos()
    {
        return new ADPais().ObtenerTodos(); 
    }

    }
}

