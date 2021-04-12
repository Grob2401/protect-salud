using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
 
namespace AccesoDatos 
 {
 
public class ADVtaBDVendedores
{
public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

 public List<ENVtaBDVendedores> ObtenerTodos()
{
DbCommand oCommand = null;
List<ENVtaBDVendedores> oListaVtaBDVendedores= new List<ENVtaBDVendedores>();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenVtaBDVendedores_sel");
  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  while (oDataReader.Read())
      {
          ENVtaBDVendedores oEnListaVtaBDVendedores = new ENVtaBDVendedores();
          oEnListaVtaBDVendedores.ApellidoMaterno=oDataReader["ApellidoMaterno"].ToString();
oEnListaVtaBDVendedores.ApellidoPaterno=oDataReader["ApellidoPaterno"].ToString();
oEnListaVtaBDVendedores.CodigoPerfil=oDataReader["CodigoPerfil"].ToString();
oEnListaVtaBDVendedores.CodigoUsuario=oDataReader["CodigoUsuario"].ToString();
oEnListaVtaBDVendedores.CodigoVendedor=oDataReader["CodigoVendedor"].ToString();
oEnListaVtaBDVendedores.Direccion=oDataReader["Direccion"].ToString();
oEnListaVtaBDVendedores.Email=oDataReader["Email"].ToString();
oEnListaVtaBDVendedores.EstadoRegistro=oDataReader["EstadoRegistro"].ToString();
oEnListaVtaBDVendedores.Fechaing=DateTime.Parse(oDataReader["Fechaing"].ToString());
oEnListaVtaBDVendedores.ID_perfil=oDataReader["ID_perfil"].ToString();
oEnListaVtaBDVendedores.IdPersona=Convert.ToInt32(oDataReader["IdPersona"]);
oEnListaVtaBDVendedores.IdSociedad=Convert.ToInt32(oDataReader["IdSociedad"]);
oEnListaVtaBDVendedores.Nombres=oDataReader["Nombres"].ToString();
oEnListaVtaBDVendedores.Telefono=oDataReader["Telefono"].ToString();

          oListaVtaBDVendedores.Add(oEnListaVtaBDVendedores);
     }
     return oListaVtaBDVendedores;
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
public ENVtaBDVendedores  ObtenerUno(string CodigoVendedor)
{
DbCommand oCommand = null;
ENVtaBDVendedores oENVtaBDVendedores= new ENVtaBDVendedores();
try
{
  oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenVtaBDVendedores_sel");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoVendedor",oENVtaBDVendedores.CodigoVendedor,TipoParametro.STR,Direccion.INPUT);

  GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
  DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
  if (oDataReader.Read())
      {
          oENVtaBDVendedores.ApellidoMaterno=oDataReader["ApellidoMaterno"].ToString();
oENVtaBDVendedores.ApellidoPaterno=oDataReader["ApellidoPaterno"].ToString();
oENVtaBDVendedores.CodigoPerfil=oDataReader["CodigoPerfil"].ToString();
oENVtaBDVendedores.CodigoUsuario=oDataReader["CodigoUsuario"].ToString();
oENVtaBDVendedores.CodigoVendedor=oDataReader["CodigoVendedor"].ToString();
oENVtaBDVendedores.Direccion=oDataReader["Direccion"].ToString();
oENVtaBDVendedores.Email=oDataReader["Email"].ToString();
oENVtaBDVendedores.EstadoRegistro=oDataReader["EstadoRegistro"].ToString();
oENVtaBDVendedores.Fechaing=DateTime.Parse(oDataReader["Fechaing"].ToString());
oENVtaBDVendedores.ID_perfil=oDataReader["ID_perfil"].ToString();
oENVtaBDVendedores.IdPersona=Convert.ToInt32(oDataReader["IdPersona"]);
oENVtaBDVendedores.IdSociedad=Convert.ToInt32(oDataReader["IdSociedad"]);
oENVtaBDVendedores.Nombres=oDataReader["Nombres"].ToString();
oENVtaBDVendedores.Telefono=oDataReader["Telefono"].ToString();

     }
     return oENVtaBDVendedores;
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
 
public bool Insertar(ENVtaBDVendedores oENVtaBDVendedores)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenVtaBDVendedores_ins");
           GenericDataAccess.AgregarParametro(oCommand,"@argApellidoMaterno",oENVtaBDVendedores.ApellidoMaterno,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argApellidoPaterno",oENVtaBDVendedores.ApellidoPaterno,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPerfil",oENVtaBDVendedores.CodigoPerfil,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoUsuario",oENVtaBDVendedores.CodigoUsuario,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoVendedor",oENVtaBDVendedores.CodigoVendedor,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDireccion",oENVtaBDVendedores.Direccion,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argEmail",oENVtaBDVendedores.Email,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argEstadoRegistro",oENVtaBDVendedores.EstadoRegistro,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argFechaing",oENVtaBDVendedores.Fechaing,TipoParametro.DT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argID_perfil",oENVtaBDVendedores.ID_perfil,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argIdPersona",oENVtaBDVendedores.IdPersona,TipoParametro.INT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argIdSociedad",oENVtaBDVendedores.IdSociedad,TipoParametro.INT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argNombres",oENVtaBDVendedores.Nombres,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argTelefono",oENVtaBDVendedores.Telefono,TipoParametro.STR,Direccion.INPUT);

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
 
public bool Actualizar(ENVtaBDVendedores oENVtaBDVendedores)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenVtaBDVendedores_upd");
           GenericDataAccess.AgregarParametro(oCommand,"@argApellidoMaterno",oENVtaBDVendedores.ApellidoMaterno,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argApellidoPaterno",oENVtaBDVendedores.ApellidoPaterno,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoPerfil",oENVtaBDVendedores.CodigoPerfil,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoUsuario",oENVtaBDVendedores.CodigoUsuario,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argCodigoVendedor",oENVtaBDVendedores.CodigoVendedor,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argDireccion",oENVtaBDVendedores.Direccion,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argEmail",oENVtaBDVendedores.Email,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argEstadoRegistro",oENVtaBDVendedores.EstadoRegistro,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argFechaing",oENVtaBDVendedores.Fechaing,TipoParametro.DT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argID_perfil",oENVtaBDVendedores.ID_perfil,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argIdPersona",oENVtaBDVendedores.IdPersona,TipoParametro.INT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argIdSociedad",oENVtaBDVendedores.IdSociedad,TipoParametro.INT,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argNombres",oENVtaBDVendedores.Nombres,TipoParametro.STR,Direccion.INPUT);
 GenericDataAccess.AgregarParametro(oCommand,"@argTelefono",oENVtaBDVendedores.Telefono,TipoParametro.STR,Direccion.INPUT);

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
 
public bool  Eliminar(string CodigoVendedor)
{

  DbCommand oCommand = null ;
  try
  {
           oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString,"usp_GenVtaBDVendedores_del");
           GenericDataAccess.AgregarParametro(oCommand,"@argCodigoVendedor",CodigoVendedor,TipoParametro.STR,Direccion.INPUT);

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
