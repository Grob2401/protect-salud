using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADClientes
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;


        public List<ENClientes> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENClientes> oListaClientes = new List<ENClientes>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENClientes oEnListaClientes = new ENClientes();
                    oEnListaClientes.CodigoCliente = oDataReader["CodigoCliente"] == DBNull.Value ? "" : oDataReader["CodigoCliente"].ToString();
                    oEnListaClientes.CodigoCorredor = oDataReader["CodigoCorredor"] == DBNull.Value ? "" : oDataReader["CodigoCorredor"].ToString();
                    oEnListaClientes.CodigoEjecutivo = oDataReader["CodigoEjecutivo"] == DBNull.Value ? "" : oDataReader["CodigoEjecutivo"].ToString();
                    oEnListaClientes.CodigoTipoCliente = oDataReader["CodigoTipoCliente"] == DBNull.Value ? "" : oDataReader["CodigoTipoCliente"].ToString();
                    oEnListaClientes.CodigoUsuario = oDataReader["CodigoUsuario"] == DBNull.Value ? "" : oDataReader["CodigoUsuario"].ToString();
                    oEnListaClientes.CorredorAgenciado = oDataReader["CorredorAgenciado"] == DBNull.Value ? "" : oDataReader["CorredorAgenciado"].ToString();
                    oEnListaClientes.Direccion = oDataReader["Direccion"] == DBNull.Value ? "" : oDataReader["Direccion"].ToString();
                    oEnListaClientes.Email = oDataReader["Email"] == DBNull.Value ? "" : oDataReader["Email"].ToString();

                    oEnListaClientes.FechaMovimiento = oDataReader["FechaMovimiento"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaMovimiento"]);

                    oEnListaClientes.Materno = oDataReader["Materno"] == DBNull.Value ? "" : oDataReader["Materno"].ToString();
                    oEnListaClientes.NombreCorto = oDataReader["NombreCorto"] == DBNull.Value ? "" : oDataReader["NombreCorto"].ToString();
                    oEnListaClientes.Nombres = oDataReader["Nombres"] == DBNull.Value ? "" : oDataReader["Nombres"].ToString();
                    oEnListaClientes.PaginaWeb = oDataReader["PaginaWeb"] == DBNull.Value ? "" : oDataReader["PaginaWeb"].ToString();
                    oEnListaClientes.Paterno = oDataReader["Paterno"] == DBNull.Value ? "" : oDataReader["Paterno"].ToString();
                    oEnListaClientes.PersonaContacto = oDataReader["PersonaContacto"] == DBNull.Value ? "" : oDataReader["PersonaContacto"].ToString();
                    oEnListaClientes.PersonaContactoCobranza = oDataReader["PersonaContactoCobranza"] == DBNull.Value ? "" : oDataReader["PersonaContactoCobranza"].ToString();
                    oEnListaClientes.RazonSocial = oDataReader["RazonSocial"] == DBNull.Value ? "" : oDataReader["RazonSocial"].ToString();
                    oEnListaClientes.RucDni = oDataReader["RucDni"] == DBNull.Value ? "" : oDataReader["RucDni"].ToString();
                    oEnListaClientes.Telefono1 = oDataReader["Telefono1"] == DBNull.Value ? "" : oDataReader["Telefono1"].ToString();
                    oEnListaClientes.Telefono2 = oDataReader["Telefono2"] == DBNull.Value ? "" : oDataReader["Telefono2"].ToString();
                    oEnListaClientes.Ubicubi = oDataReader["Ubicubi"] == DBNull.Value ? "" : oDataReader["Ubicubi"].ToString();

                    oListaClientes.Add(oEnListaClientes);
                }
                return oListaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }

        public List<ENClientes> ObtenerTodos(int page, int rows, string type, string Keywords)
        {
            DbCommand oCommand = null;
            List<ENClientes> oListaClientes = new List<ENClientes>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_sel_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@page", page, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@rowsPerPage", rows, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@type", type, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@keywords", Keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENClientes oEnListaClientes = new ENClientes();
                    oEnListaClientes.CodigoCliente = oDataReader["CodigoCliente"] == DBNull.Value ? "" : oDataReader["CodigoCliente"].ToString();
                    oEnListaClientes.CodigoCorredor = oDataReader["CodigoCorredor"] == DBNull.Value ? "" : oDataReader["CodigoCorredor"].ToString();
                    oEnListaClientes.CodigoEjecutivo = oDataReader["CodigoEjecutivo"] == DBNull.Value ? "" : oDataReader["CodigoEjecutivo"].ToString();
                    oEnListaClientes.CodigoTipoCliente = oDataReader["CodigoTipoCliente"] == DBNull.Value ? "" : oDataReader["CodigoTipoCliente"].ToString();
                    oEnListaClientes.CodigoUsuario = oDataReader["CodigoUsuario"] == DBNull.Value ? "" : oDataReader["CodigoUsuario"].ToString();
                    oEnListaClientes.CorredorAgenciado = oDataReader["CorredorAgenciado"] == DBNull.Value ? "" : oDataReader["CorredorAgenciado"].ToString();
                    oEnListaClientes.Direccion = oDataReader["Direccion"] == DBNull.Value ? "" : oDataReader["Direccion"].ToString();
                    oEnListaClientes.Email = oDataReader["Email"] == DBNull.Value ? "" : oDataReader["Email"].ToString();

                    oEnListaClientes.FechaMovimiento = oDataReader["FechaMovimiento"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaMovimiento"]);

                    oEnListaClientes.Materno = oDataReader["Materno"] == DBNull.Value ? "" : oDataReader["Materno"].ToString();
                    oEnListaClientes.NombreCorto = oDataReader["NombreCorto"] == DBNull.Value ? "" : oDataReader["NombreCorto"].ToString();
                    oEnListaClientes.Nombres = oDataReader["Nombres"] == DBNull.Value ? "" : oDataReader["Nombres"].ToString();
                    oEnListaClientes.PaginaWeb = oDataReader["PaginaWeb"] == DBNull.Value ? "" : oDataReader["PaginaWeb"].ToString();
                    oEnListaClientes.Paterno = oDataReader["Paterno"] == DBNull.Value ? "" : oDataReader["Paterno"].ToString();
                    oEnListaClientes.PersonaContacto = oDataReader["PersonaContacto"] == DBNull.Value ? "" : oDataReader["PersonaContacto"].ToString();
                    oEnListaClientes.PersonaContactoCobranza = oDataReader["PersonaContactoCobranza"] == DBNull.Value ? "" : oDataReader["PersonaContactoCobranza"].ToString();
                    oEnListaClientes.RazonSocial = oDataReader["RazonSocial"] == DBNull.Value ? "" : oDataReader["RazonSocial"].ToString();
                    oEnListaClientes.RucDni = oDataReader["RucDni"] == DBNull.Value ? "" : oDataReader["RucDni"].ToString();
                    oEnListaClientes.Telefono1 = oDataReader["Telefono1"] == DBNull.Value ? "" : oDataReader["Telefono1"].ToString();
                    oEnListaClientes.Telefono2 = oDataReader["Telefono2"] == DBNull.Value ? "" : oDataReader["Telefono2"].ToString();
                    oEnListaClientes.Ubicubi = oDataReader["Ubicubi"] == DBNull.Value ? "" : oDataReader["Ubicubi"].ToString();

                    oListaClientes.Add(oEnListaClientes);
                }
                return oListaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }
        public ENClientes ObtenerUno(string CodigoCliente)
        {
            DbCommand oCommand = null;
            ENClientes oENClientes = new ENClientes();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENClientes.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENClientes.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENClientes.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENClientes.CodigoTipoCliente = oDataReader["CodigoTipoCliente"].ToString();
                    oENClientes.CodigoUsuario = oDataReader["CodigoUsuario"].ToString();
                    oENClientes.CorredorAgenciado = oDataReader["CorredorAgenciado"].ToString();
                    oENClientes.Direccion = oDataReader["Direccion"].ToString();
                    oENClientes.Email = oDataReader["Email"].ToString();
                    //oENClientes.FechaMovimiento = DateTime.Parse(oDataReader["FechaMovimiento"].ToString());
                    oENClientes.FechaMovimiento = oDataReader["FechaMovimiento"] == DBNull.Value
             ? DateTime.Now
             : Convert.ToDateTime(oDataReader["FechaMovimiento"]);


                    oENClientes.Materno = oDataReader["Materno"].ToString();
                    oENClientes.NombreCorto = oDataReader["NombreCorto"].ToString();
                    oENClientes.Nombres = oDataReader["Nombres"].ToString();
                    oENClientes.PaginaWeb = oDataReader["PaginaWeb"].ToString();
                    oENClientes.Paterno = oDataReader["Paterno"].ToString();
                    oENClientes.PersonaContacto = oDataReader["PersonaContacto"].ToString();
                    oENClientes.PersonaContactoCobranza = oDataReader["PersonaContactoCobranza"].ToString();
                    oENClientes.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENClientes.RucDni = oDataReader["RucDni"].ToString();
                    oENClientes.Telefono1 = oDataReader["Telefono1"].ToString();
                    oENClientes.Telefono2 = oDataReader["Telefono2"].ToString();
                    oENClientes.Ubicubi = oDataReader["Ubicubi"].ToString();
                    if (oENClientes.Ubicubi.Length == 0)
                    {
                        oENClientes.Ubicubi = "150101";
                    }
         
                        oENClientes.CodigoDpto = oENClientes.Ubicubi.Substring(0, 2);
                        oENClientes.CodigoProv = oENClientes.Ubicubi.Substring(2, 2);
                        oENClientes.CodigoDist = oENClientes.Ubicubi.Substring(4, 2);
               


                }
                return oENClientes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }

        public ENClientes ObtenerUnoporRUC(string EmpresaRUC)
        {
            DbCommand oCommand = null;
            ENClientes oENClientes = new ENClientes();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_sel_uno_ruc");
                GenericDataAccess.AgregarParametro(oCommand, "@argEmpresaRUC", EmpresaRUC, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENClientes.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENClientes.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENClientes.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENClientes.CodigoTipoCliente = oDataReader["CodigoTipoCliente"].ToString();
                    oENClientes.CodigoUsuario = oDataReader["CodigoUsuario"].ToString();
                    oENClientes.CorredorAgenciado = oDataReader["CorredorAgenciado"].ToString();
                    oENClientes.Direccion = oDataReader["Direccion"].ToString();
                    oENClientes.Email = oDataReader["Email"].ToString();
                    //oENClientes.FechaMovimiento = DateTime.Parse(oDataReader["FechaMovimiento"].ToString());
                    oENClientes.Materno = oDataReader["Materno"].ToString();
                    oENClientes.NombreCorto = oDataReader["NombreCorto"].ToString();
                    oENClientes.Nombres = oDataReader["Nombres"].ToString();
                    oENClientes.PaginaWeb = oDataReader["PaginaWeb"].ToString();
                    oENClientes.Paterno = oDataReader["Paterno"].ToString();
                    oENClientes.PersonaContacto = oDataReader["PersonaContacto"].ToString();
                    oENClientes.PersonaContactoCobranza = oDataReader["PersonaContactoCobranza"].ToString();
                    oENClientes.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENClientes.RucDni = oDataReader["RucDni"].ToString();
                    oENClientes.Telefono1 = oDataReader["Telefono1"].ToString();
                    oENClientes.Telefono2 = oDataReader["Telefono2"].ToString();
                    oENClientes.Ubicubi = oDataReader["Ubicubi"].ToString();
                    oENClientes.CodigoDpto = oDataReader["CodDpto"].ToString();
                    oENClientes.CodigoProv = oDataReader["CodProv"].ToString();
                    oENClientes.CodigoDist = oDataReader["CodDist"].ToString();
                    oENClientes.DescripcionDpto = oDataReader["DescripcionDpto"].ToString();
                    oENClientes.DescripcionProv = oDataReader["DescripcionProv"].ToString();
                    oENClientes.DescripcionDist = oDataReader["DescripcionDist"].ToString();
                }
                return oENClientes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }


        public bool Insertar(ENClientes oENClientes)
        {

            DbCommand oCommand = null;
            string sUbicubi = "";
            string sCodigoUsuario = "grojas";
            //oENClientes.Materno = "";
            try
            {
                if (oENClientes.Ubicubi is null)
                {
                    sUbicubi = oENClientes.CodigoDpto + oENClientes.CodigoProv + oENClientes.CodigoDist;
                }
                else
                {
                    sUbicubi = oENClientes.Ubicubi;
                }



                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", oENClientes.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", oENClientes.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoCliente", oENClientes.CodigoTipoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoUsuario", sCodigoUsuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCorredorAgenciado", oENClientes.CorredorAgenciado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDireccion", oENClientes.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEmail", oENClientes.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argMaterno", oENClientes.Materno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombreCorto", oENClientes.NombreCorto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombres", oENClientes.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPaginaWeb", oENClientes.PaginaWeb, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPaterno", oENClientes.Paterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPersonaContacto", oENClientes.PersonaContacto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPersonaContactoCobranza", oENClientes.PersonaContactoCobranza, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRazonSocial", oENClientes.RazonSocial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRucDni", oENClientes.RucDni, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono1", oENClientes.Telefono1, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono2", oENClientes.Telefono2, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argUbicubi", sUbicubi, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTipoDocumento", oENClientes.CodigoDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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

        public bool Actualizar(ENClientes oENClientes)
        {

            DbCommand oCommand = null;
            string sUbicubi = "";
            string sCodigoUsuario = "grojas";
            try
            {
                if (oENClientes.Ubicubi is null)
                {
                    sUbicubi = oENClientes.CodigoDpto + oENClientes.CodigoProv + oENClientes.CodigoDist;
                }
                else
                {
                    sUbicubi = oENClientes.Ubicubi;
                }
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", oENClientes.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", oENClientes.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", oENClientes.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoCliente", oENClientes.CodigoTipoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoUsuario", sCodigoUsuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCorredorAgenciado", oENClientes.CorredorAgenciado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDireccion", oENClientes.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEmail", oENClientes.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argMaterno", oENClientes.Materno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombreCorto", oENClientes.NombreCorto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombres", oENClientes.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPaginaWeb", oENClientes.PaginaWeb, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPaterno", oENClientes.Paterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPersonaContacto", oENClientes.PersonaContacto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPersonaContactoCobranza", oENClientes.PersonaContactoCobranza, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRazonSocial", oENClientes.RazonSocial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRucDni", oENClientes.RucDni, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono1", oENClientes.Telefono1, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono2", oENClientes.Telefono2, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argUbicubi", sUbicubi, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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

        public bool Eliminar(string CodigoCliente)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenClientes_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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

