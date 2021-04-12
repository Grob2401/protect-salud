using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNSaludContratos
{
 public static List<ENSaludContratos> ObtenerTodos(string CodigoCliente)
       {
           return new ADSaludContratos().ObtenerTodos(CodigoCliente); 
  }

public static bool Insertar (ENSaludContratos oENSaludContratos)
{
return (new ADSaludContratos()).Insertar(oENSaludContratos);
}

public static bool Actualizar (ENSaludContratos oENSaludContratos)
{
return (new ADSaludContratos()).Actualizar(oENSaludContratos);
}

public static bool  Eliminar(string CodigoCliente, string CodigoContrato)
{
return (new ADSaludContratos()).Eliminar(CodigoCliente,CodigoContrato);

}

public static ENSaludContratos ObtenerUno(string CodigoCliente, string CodigoContrato)
{
return (new ADSaludContratos()).ObtenerUno(CodigoCliente, CodigoContrato);
}
}
}

