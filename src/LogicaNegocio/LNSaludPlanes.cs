using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNSaludPlanes
{
 public static List<ENSaludPlanes> ObtenerTodos()
       {
           return new ADSaludPlanes().ObtenerTodos(); 
  }

public static bool Insertar (ENSaludPlanes oENSaludPlanes)
{
return (new ADSaludPlanes()).Insertar(oENSaludPlanes);
}

public static bool Actualizar (ENSaludPlanes oENSaludPlanes)
{
return (new ADSaludPlanes()).Actualizar(oENSaludPlanes);
}

public static bool  Eliminar(string CodigoPlan)
{
return (new ADSaludPlanes()).Eliminar(CodigoPlan);
}

public static ENSaludPlanes ObtenerUno(string CodigoPlan)
{
return (new ADSaludPlanes()).ObtenerUno(CodigoPlan);
}
}
}

