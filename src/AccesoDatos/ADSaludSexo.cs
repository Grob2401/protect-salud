using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADSaludSexo
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENSaludSexo> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENSaludSexo> oListaSaludSexo= new List<ENSaludSexo>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenSaludSexo_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENSaludSexo oEnListaSaludSexo = new ENSaludSexo();
          oEnListaSaludSexo.CodigoSexo=oDataReader["CodigoSexo"].ToString();
oEnListaSaludSexo.DescripcionSexo=oDataReader["DescripcionSexo"].ToString();

          oListaSaludSexo.Add(oEnListaSaludSexo);
     }
     return oListaSaludSexo;
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
public ENSaludSexo  ObtenerUno(string CodigoSexo)
{
DbCommand oCommand = null;
ENSaludSexo oENSaludSexo= new ENSaludSexo();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenSaludSexo_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoSexo",oENSaludSexo.CodigoSexo,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENSaludSexo.CodigoSexo=oDataReader["CodigoSexo"].ToString();
oENSaludSexo.DescripcionSexo=oDataReader["DescripcionSexo"].ToString();

     }
     return oENSaludSexo;
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
 
public bool Insertar(ENSaludSexo oENSaludSexo)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenSaludSexo_ins");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoSexo",oENSaludSexo.CodigoSexo,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionSexo",oENSaludSexo.DescripcionSexo,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENSaludSexo oENSaludSexo)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenSaludSexo_upd");
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoSexo",oENSaludSexo.CodigoSexo,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDescripcionSexo",oENSaludSexo.DescripcionSexo,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoSexo)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenSaludSexo_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoSexo",CodigoSexo,TipoParametro.STR,Direccion.INPUT);

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
