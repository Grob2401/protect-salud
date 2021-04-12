using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNSaludSexo
{
 public static List<ENSaludSexo> ObtenerTodos()
       {
           return new ADSaludSexo().ObtenerTodos(); 
  }

public static bool Insertar (ENSaludSexo oENSaludSexo)
{
return (new ADSaludSexo()).Insertar(oENSaludSexo);
}

public static bool Actualizar (ENSaludSexo oENSaludSexo)
{
return (new ADSaludSexo()).Actualizar(oENSaludSexo);
}

public static bool  Eliminar(string CodigoSexo)
{
return (new ADSaludSexo()).Eliminar(CodigoSexo);
}

public static ENSaludSexo ObtenerUno(string CodigoSexo)
{
return (new ADSaludSexo()).ObtenerUno(CodigoSexo);
}
}
}

