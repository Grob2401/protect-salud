using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNVtaBDVendedores
{
 public static List<ENVtaBDVendedores> ObtenerTodos()
       {
           return new ADVtaBDVendedores().ObtenerTodos(); 
  }

public static bool Insertar (ENVtaBDVendedores oENVtaBDVendedores)
{
return (new ADVtaBDVendedores()).Insertar(oENVtaBDVendedores);
}

public static bool Actualizar (ENVtaBDVendedores oENVtaBDVendedores)
{
return (new ADVtaBDVendedores()).Actualizar(oENVtaBDVendedores);
}

public static bool  Eliminar(string CodigoVendedor)
{
return (new ADVtaBDVendedores()).Eliminar(CodigoVendedor);
}

public static ENVtaBDVendedores ObtenerUno(string CodigoVendedor)
{
return (new ADVtaBDVendedores()).ObtenerUno(CodigoVendedor);
}
}
}

