using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADTipoCliente
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENTipoCliente> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENTipoCliente> oListaTipoCliente= new List<ENTipoCliente>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoCliente_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENTipoCliente oEnListaTipoCliente = new ENTipoCliente();
          oEnListaTipoCliente.CampoClave=oDataReader["CampoClave"].ToString();
oEnListaTipoCliente.CodigoTipoCliente=oDataReader["CodigoTipoCliente"].ToString();
oEnListaTipoCliente.DescripcionTipoCliente=oDataReader["DescripcionTipoCliente"].ToString();
oEnListaTipoCliente.MostrarLogin=oDataReader["MostrarLogin"].ToString();
oEnListaTipoCliente.NombreTabla=oDataReader["NombreTabla"].ToString();

          oListaTipoCliente.Add(oEnListaTipoCliente);
     }
     return oListaTipoCliente;
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
public ENTipoCliente  ObtenerUno(string CodigoTipoCliente)
{
DbCommand oCommand = null;
ENTipoCliente oENTipoCliente= new ENTipoCliente();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoCliente_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoCliente",oENTipoCliente.CodigoTipoCliente,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENTipoCliente.CampoClave=oDataReader["CampoClave"].ToString();
oENTipoCliente.CodigoTipoCliente=oDataReader["CodigoTipoCliente"].ToString();
oENTipoCliente.DescripcionTipoCliente=oDataReader["DescripcionTipoCliente"].ToString();
oENTipoCliente.MostrarLogin=oDataReader["MostrarLogin"].ToString();
oENTipoCliente.NombreTabla=oDataReader["NombreTabla"].ToString();

     }
     return oENTipoCliente;
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
 
public bool Insertar(ENTipoCliente oENTipoCliente)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoCliente_ins");
           GenericDataAccess.AgregarParametro(oCommand,"@argCampoClave",oENTipoCliente.CampoClave,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoCliente",oENTipoCliente.CodigoTipoCliente,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoCliente",oENTipoCliente.DescripcionTipoCliente,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argMostrarLogin",oENTipoCliente.MostrarLogin,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argNombreTabla",oENTipoCliente.NombreTabla,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENTipoCliente oENTipoCliente)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoCliente_upd");
           GenericDataAccess.AgregarParametro(oCommand,"@argCampoClave",oENTipoCliente.CampoClave,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoCliente",oENTipoCliente.CodigoTipoCliente,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionTipoCliente",oENTipoCliente.DescripcionTipoCliente,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argMostrarLogin",oENTipoCliente.MostrarLogin,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argNombreTabla",oENTipoCliente.NombreTabla,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoTipoCliente)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenTipoCliente_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoTipoCliente",CodigoTipoCliente,TipoParametro.STR,Direccion.INPUT);

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
