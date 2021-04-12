using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADTipoDocumentoIdentidad 
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENTipoDocumentoIdentidad > ObtenerTodos()
{
DbCommand oCommand = null;
List<ENTipoDocumentoIdentidad > oListaTipoDocumentoIdentidad = new List<ENTipoDocumentoIdentidad >();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoDocumentoIdentidad _sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENTipoDocumentoIdentidad  oEnListaTipoDocumentoIdentidad  = new ENTipoDocumentoIdentidad ();
          oEnListaTipoDocumentoIdentidad .CodigoDocumentoIdentidad=oDataReader["CodigoDocumentoIdentidad"].ToString();
oEnListaTipoDocumentoIdentidad .DescripcionDocumentoIdentidad=oDataReader["DescripcionDocumentoIdentidad"].ToString();

          oListaTipoDocumentoIdentidad .Add(oEnListaTipoDocumentoIdentidad );
     }
     return oListaTipoDocumentoIdentidad ;
      }
      catch (Exception ex)
      {
  throw  new Exception();
  }
   finally
  {
   GenericDataAccess.CerrarConexion(oCommand, null);
  }
  }
public ENTipoDocumentoIdentidad   ObtenerUno(string CodigoDocumentoIdentidad)
{
DbCommand oCommand = null;
ENTipoDocumentoIdentidad  oENTipoDocumentoIdentidad = new ENTipoDocumentoIdentidad ();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoDocumentoIdentidad _sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoDocumentoIdentidad",oENTipoDocumentoIdentidad .CodigoDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENTipoDocumentoIdentidad .CodigoDocumentoIdentidad=oDataReader["CodigoDocumentoIdentidad"].ToString();
oENTipoDocumentoIdentidad .DescripcionDocumentoIdentidad=oDataReader["DescripcionDocumentoIdentidad"].ToString();

     }
     return oENTipoDocumentoIdentidad ;
      }
      catch (Exception ex)
      {
  throw  new Exception();
  }
   finally
  {
   GenericDataAccess.CerrarConexion(oCommand, null);
  }
  }
 
public bool Insertar(ENTipoDocumentoIdentidad  oENTipoDocumentoIdentidad )
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoDocumentoIdentidad _ins");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoDocumentoIdentidad",oENTipoDocumentoIdentidad .CodigoDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionDocumentoIdentidad",oENTipoDocumentoIdentidad .DescripcionDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);

          GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
          if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0) 
          return true;
          else
          return false;
          }
          catch (Exception ex)
          {
          throw new Excepciones.ManejoExcepciones(ex);
          }
           finally
          {
           GenericDataAccess.CerrarConexion(oCommand, null);
          }
     }
 
public bool Actualizar(ENTipoDocumentoIdentidad  oENTipoDocumentoIdentidad )
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoDocumentoIdentidad _upd");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoDocumentoIdentidad",oENTipoDocumentoIdentidad .CodigoDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionDocumentoIdentidad",oENTipoDocumentoIdentidad .DescripcionDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);

          GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
          if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0) 
          return true;
          else
          return false;
          }
          catch (Exception ex)
          {
          throw new Excepciones.ManejoExcepciones(ex);
          }
           finally
          {
           GenericDataAccess.CerrarConexion(oCommand, null);
          }
     }
 
public bool  Eliminar(string CodigoDocumentoIdentidad)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoDocumentoIdentidad _del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoDocumentoIdentidad",CodigoDocumentoIdentidad,TipoParametro.STR,Direccion.INPUT);

          GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
          if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0) 
          return true;
          else
          return false;
          }
          catch (Exception ex)
          {
          throw new Excepciones.ManejoExcepciones(ex);
          }
           finally
          {
           GenericDataAccess.CerrarConexion(oCommand, null);
          }
     }
 }
}
