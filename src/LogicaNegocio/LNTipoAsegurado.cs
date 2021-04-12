using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNTipoAsegurado
{
 public static List<ENTipoAsegurado> ObtenerTodos()
       {
           return new ADTipoAsegurado().ObtenerTodos(); 
  }

public static bool Insertar (ENTipoAsegurado oENTipoAsegurado)
{
return (new ADTipoAsegurado()).Insertar(oENTipoAsegurado);
}

public static bool Actualizar (ENTipoAsegurado oENTipoAsegurado)
{
return (new ADTipoAsegurado()).Actualizar(oENTipoAsegurado);
}

public static bool  Eliminar(string CodigoTipoAsegurado)
{
return (new ADTipoAsegurado()).Eliminar(CodigoTipoAsegurado);
}

public static ENTipoAsegurado ObtenerUno(string CodigoTipoAsegurado)
{
return (new ADTipoAsegurado()).ObtenerUno(CodigoTipoAsegurado);
}
}
}

