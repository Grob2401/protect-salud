using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNTipoDocumentoPago
    {
    public static List<ENTipoDocumentoPago> ObtenerTodos()
    {
        return new ADTipoDocumentoPago().ObtenerTodos(); 
    }

    }
}

