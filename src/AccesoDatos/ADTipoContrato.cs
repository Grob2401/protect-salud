using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADTipoContrato
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENTipoContrato> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENTipoContrato> oListaTipoContrato= new List<ENTipoContrato>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoContrato_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENTipoContrato oEnListaTipoContrato = new ENTipoContrato();
          oEnListaTipoContrato.CodigoTipoContrato=oDataReader["CodigoTipoContrato"].ToString();
oEnListaTipoContrato.DescripcionTipoContrato=oDataReader["DescripcionTipoContrato"].ToString();

          oListaTipoContrato.Add(oEnListaTipoContrato);
     }
     return oListaTipoContrato;
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
public ENTipoContrato  ObtenerUno(string CodigoTipoContrato)
{
DbCommand oCommand = null;
ENTipoContrato oENTipoContrato= new ENTipoContrato();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoContrato_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoContrato",oENTipoContrato.CodigoTipoContrato,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENTipoContrato.CodigoTipoContrato=oDataReader["CodigoTipoContrato"].ToString();
oENTipoContrato.DescripcionTipoContrato=oDataReader["DescripcionTipoContrato"].ToString();

     }
     return oENTipoContrato;
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
 
public bool Insertar(ENTipoContrato oENTipoContrato)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoContrato_ins");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoContrato",oENTipoContrato.CodigoTipoContrato,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoContrato",oENTipoContrato.DescripcionTipoContrato,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENTipoContrato oENTipoContrato)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoContrato_upd");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoContrato",oENTipoContrato.CodigoTipoContrato,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoContrato",oENTipoContrato.DescripcionTipoContrato,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoTipoContrato)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoContrato_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoContrato",CodigoTipoContrato,TipoParametro.STR,Direccion.INPUT);

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
