using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADTipoPreexistencia
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENTipoPreexistencia> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENTipoPreexistencia> oListaTipoPreexistencia= new List<ENTipoPreexistencia>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoPreexistencia_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENTipoPreexistencia oEnListaTipoPreexistencia = new ENTipoPreexistencia();
          oEnListaTipoPreexistencia.CodigoPreexistencia=oDataReader["CodigoPreexistencia"].ToString();
oEnListaTipoPreexistencia.DescripcionPreexistencia=oDataReader["DescripcionPreexistencia"].ToString();
oEnListaTipoPreexistencia.LetraPreexistencia=oDataReader["LetraPreexistencia"].ToString();

          oListaTipoPreexistencia.Add(oEnListaTipoPreexistencia);
     }
     return oListaTipoPreexistencia;
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
public ENTipoPreexistencia  ObtenerUno(string CodigoPreexistencia)
{
DbCommand oCommand = null;
ENTipoPreexistencia oENTipoPreexistencia= new ENTipoPreexistencia();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoPreexistencia_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPreexistencia",oENTipoPreexistencia.CodigoPreexistencia,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENTipoPreexistencia.CodigoPreexistencia=oDataReader["CodigoPreexistencia"].ToString();
oENTipoPreexistencia.DescripcionPreexistencia=oDataReader["DescripcionPreexistencia"].ToString();
oENTipoPreexistencia.LetraPreexistencia=oDataReader["LetraPreexistencia"].ToString();

     }
     return oENTipoPreexistencia;
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
 
public bool Insertar(ENTipoPreexistencia oENTipoPreexistencia)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoPreexistencia_ins");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPreexistencia",oENTipoPreexistencia.CodigoPreexistencia,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionPreexistencia",oENTipoPreexistencia.DescripcionPreexistencia,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argLetraPreexistencia",oENTipoPreexistencia.LetraPreexistencia,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENTipoPreexistencia oENTipoPreexistencia)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoPreexistencia_upd");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPreexistencia",oENTipoPreexistencia.CodigoPreexistencia,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionPreexistencia",oENTipoPreexistencia.DescripcionPreexistencia,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argLetraPreexistencia",oENTipoPreexistencia.LetraPreexistencia,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoPreexistencia)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoPreexistencia_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPreexistencia",CodigoPreexistencia,TipoParametro.STR,Direccion.INPUT);

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
