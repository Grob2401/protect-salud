using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNTipoCliente
{
 public static List<ENTipoCliente> ObtenerTodos()
       {
           return new ADTipoCliente().ObtenerTodos(); 
  }

public static bool Insertar (ENTipoCliente oENTipoCliente)
{
return (new ADTipoCliente()).Insertar(oENTipoCliente);
}

public static bool Actualizar (ENTipoCliente oENTipoCliente)
{
return (new ADTipoCliente()).Actualizar(oENTipoCliente);
}

public static bool  Eliminar(string CodigoTipoCliente)
{
return (new ADTipoCliente()).Eliminar(CodigoTipoCliente);
}

public static ENTipoCliente ObtenerUno(string CodigoTipoCliente)
{
return (new ADTipoCliente()).ObtenerUno(CodigoTipoCliente);
}
}
}

