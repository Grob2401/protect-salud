using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNTipoContrato
{
 public static List<ENTipoContrato> ObtenerTodos()
       {
           return new ADTipoContrato().ObtenerTodos(); 
  }

public static bool Insertar (ENTipoContrato oENTipoContrato)
{
return (new ADTipoContrato()).Insertar(oENTipoContrato);
}

public static bool Actualizar (ENTipoContrato oENTipoContrato)
{
return (new ADTipoContrato()).Actualizar(oENTipoContrato);
}

public static bool  Eliminar(string CodigoTipoContrato)
{
return (new ADTipoContrato()).Eliminar(CodigoTipoContrato);
}

public static ENTipoContrato ObtenerUno(string CodigoTipoContrato)
{
return (new ADTipoContrato()).ObtenerUno(CodigoTipoContrato);
}
}
}

