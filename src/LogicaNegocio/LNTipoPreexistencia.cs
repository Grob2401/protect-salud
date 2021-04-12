using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNTipoPreexistencia
{
 public static List<ENTipoPreexistencia> ObtenerTodos()
       {
           return new ADTipoPreexistencia().ObtenerTodos(); 
  }

public static bool Insertar (ENTipoPreexistencia oENTipoPreexistencia)
{
return (new ADTipoPreexistencia()).Insertar(oENTipoPreexistencia);
}

public static bool Actualizar (ENTipoPreexistencia oENTipoPreexistencia)
{
return (new ADTipoPreexistencia()).Actualizar(oENTipoPreexistencia);
}

public static bool  Eliminar(string CodigoPreexistencia)
{
return (new ADTipoPreexistencia()).Eliminar(CodigoPreexistencia);
}

public static ENTipoPreexistencia ObtenerUno(string CodigoPreexistencia)
{
return (new ADTipoPreexistencia()).ObtenerUno(CodigoPreexistencia);
}
}
}

