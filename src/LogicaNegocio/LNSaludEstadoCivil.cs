using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludEstadoCivil
    {
        public static List<ENTipoEstadoCivil> ObtenerTodos()
        {
            return new ADTipoEstadoCivil().ObtenerTodos();
        }
    }
}

