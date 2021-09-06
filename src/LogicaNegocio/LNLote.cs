using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNLote
    {

        public static List<ENLote> ObtenerTodos()
        {
            return new ADLote().ObtenerTodos();
        }

        public static List<ENLote> generarTexto(string banco, string lote)
        {
            return new ADLote().generarTexto(banco,lote);
        }

        public static List<ENRuta> TraeValores(string banco)
        {
            return new ADLote().TraeValores(banco);
        }

        






    }
}

