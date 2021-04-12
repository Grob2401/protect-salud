using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNSaludParentesco
{
 public static List<ENSaludParentesco> ObtenerTodos()
       {
           return new ADSaludParentesco().ObtenerTodos(); 
  }

public static bool Insertar (ENSaludParentesco oENSaludParentesco)
{
return (new ADSaludParentesco()).Insertar(oENSaludParentesco);
}

public static bool Actualizar (ENSaludParentesco oENSaludParentesco)
{
return (new ADSaludParentesco()).Actualizar(oENSaludParentesco);
}

public static bool  Eliminar(string CodigoParentesco)
{
return (new ADSaludParentesco()).Eliminar(CodigoParentesco);
}

public static ENSaludParentesco ObtenerUno(string CodigoParentesco)
{
return (new ADSaludParentesco()).ObtenerUno(CodigoParentesco);
}
}
}

