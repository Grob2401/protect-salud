using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

public class LNTipoDocumentoIdentidad 
{
 public static List<ENTipoDocumentoIdentidad > ObtenerTodos()
       {
           return new ADTipoDocumentoIdentidad ().ObtenerTodos(); 
  }

public static bool Insertar (ENTipoDocumentoIdentidad  oENTipoDocumentoIdentidad )
{
return (new ADTipoDocumentoIdentidad ()).Insertar(oENTipoDocumentoIdentidad );
}

public static bool Actualizar (ENTipoDocumentoIdentidad  oENTipoDocumentoIdentidad )
{
return (new ADTipoDocumentoIdentidad ()).Actualizar(oENTipoDocumentoIdentidad );
}

public static bool  Eliminar(string CodigoDocumentoIdentidad)
{
return (new ADTipoDocumentoIdentidad ()).Eliminar(CodigoDocumentoIdentidad);
}

public static ENTipoDocumentoIdentidad  ObtenerUno(string CodigoDocumentoIdentidad)
{
return (new ADTipoDocumentoIdentidad ()).ObtenerUno(CodigoDocumentoIdentidad);
}
}
}

