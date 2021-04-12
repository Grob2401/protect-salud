using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADTipoAsegurado
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENTipoAsegurado> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENTipoAsegurado> oListaTipoAsegurado= new List<ENTipoAsegurado>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoAsegurado_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENTipoAsegurado oEnListaTipoAsegurado = new ENTipoAsegurado();
          oEnListaTipoAsegurado.CodigoTipoAsegurado=oDataReader["CodigoTipoAsegurado"].ToString();
oEnListaTipoAsegurado.DescripcionTipoAsegurado=oDataReader["DescripcionTipoAsegurado"].ToString();

          oListaTipoAsegurado.Add(oEnListaTipoAsegurado);
     }
     return oListaTipoAsegurado;
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
public ENTipoAsegurado  ObtenerUno(string CodigoTipoAsegurado)
{
DbCommand oCommand = null;
ENTipoAsegurado oENTipoAsegurado= new ENTipoAsegurado();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoAsegurado_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoAsegurado",oENTipoAsegurado.CodigoTipoAsegurado,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENTipoAsegurado.CodigoTipoAsegurado=oDataReader["CodigoTipoAsegurado"].ToString();
oENTipoAsegurado.DescripcionTipoAsegurado=oDataReader["DescripcionTipoAsegurado"].ToString();

     }
     return oENTipoAsegurado;
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
 
public bool Insertar(ENTipoAsegurado oENTipoAsegurado)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoAsegurado_ins");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoAsegurado",oENTipoAsegurado.CodigoTipoAsegurado,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoAsegurado",oENTipoAsegurado.DescripcionTipoAsegurado,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENTipoAsegurado oENTipoAsegurado)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoAsegurado_upd");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoAsegurado",oENTipoAsegurado.CodigoTipoAsegurado,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoAsegurado",oENTipoAsegurado.DescripcionTipoAsegurado,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoTipoAsegurado)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoAsegurado_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoAsegurado",CodigoTipoAsegurado,TipoParametro.STR,Direccion.INPUT);

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
