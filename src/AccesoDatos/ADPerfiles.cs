using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using System.Configuration;
using System.Globalization;

namespace AccesoDatos
{
    public class ADPerfiles
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENPerfiles> ObtenerTodos(string busqueda)
        {
            DbCommand oCommand = null;
            List<ENPerfiles> oListaPerfiles = new List<ENPerfiles>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenPerfiles_List");
                GenericDataAccess.AgregarParametro(oCommand, "@busqueda", busqueda, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENPerfiles oEnListaPerfiles = new ENPerfiles();
                    oEnListaPerfiles.CodigoPerfil = oDataReader["CodigoPerfil"] == null ? "" : oDataReader["CodigoPerfil"].ToString();
                    oEnListaPerfiles.DescripcionPerfil = oDataReader["DescripcionPerfil"] == null ? "" : oDataReader["DescripcionPerfil"].ToString();
                    oEnListaPerfiles.FechaInicio = oDataReader["FechaInicio"] == DBNull.Value
                                                    ? DateTime.Now
                                                    : Convert.ToDateTime(oDataReader["FechaInicio"]);
                    oEnListaPerfiles.FechaFin = oDataReader["FechaFin"] == DBNull.Value
                                                    ? DateTime.Now
                                                    : Convert.ToDateTime(oDataReader["FechaFin"]);
                    oEnListaPerfiles.GeneraOrden = oDataReader["GeneraOrden"] == null ? "" : oDataReader["GeneraOrden"].ToString();
                    oEnListaPerfiles.CodigoTipoCliente = oDataReader["CodigoTipoCliente"] == null ? "" : oDataReader["CodigoTipoCliente"].ToString();
                    oEnListaPerfiles.DescripcionCorta = oDataReader["DescripcionCorta"] == null ? "" : oDataReader["DescripcionCorta"].ToString();
                    oEnListaPerfiles.NivelAtencion = oDataReader["NivelAtencion"] == null ? "" : oDataReader["NivelAtencion"].ToString();
                    oListaPerfiles.Add(oEnListaPerfiles);
                }
                return oListaPerfiles;
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

        public ENPerfiles ObtenerUno(string CodigoPerfil)
        {
            DbCommand oCommand = null;
            ENPerfiles oENPerfiles = new ENPerfiles();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenPerfiles_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPerfil", oENPerfiles.CodigoPerfil, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENPerfiles.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oENPerfiles.CodigoTipoCliente = oDataReader["CodigoTipoCliente"].ToString();
                    oENPerfiles.DescripcionCorta = oDataReader["DescripcionCorta"].ToString();
                    oENPerfiles.DescripcionPerfil = oDataReader["DescripcionPerfil"].ToString();
                    oENPerfiles.FechaFin = DateTime.Parse(oDataReader["FechaFin"].ToString());
                    oENPerfiles.FechaInicio = DateTime.Parse(oDataReader["FechaInicio"].ToString());
                    oENPerfiles.GeneraOrden = oDataReader["GeneraOrden"].ToString();

                }
                return oENPerfiles;
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

        public bool Insertar(ENPerfiles oENPerfiles)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenPerfiles_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoCliente", oENPerfiles.CodigoTipoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCorta", oENPerfiles.DescripcionCorta, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionPerfil", oENPerfiles.DescripcionPerfil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFin", oENPerfiles.FechaFin, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicio", oENPerfiles.FechaInicio, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argGeneraOrden", oENPerfiles.GeneraOrden, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNivelAtencion", oENPerfiles.GeneraOrden, TipoParametro.STR, Direccion.INPUT);
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

        public bool Actualizar(ENPerfiles oENPerfiles)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenPerfiles_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPerfil", oENPerfiles.CodigoPerfil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoCliente", oENPerfiles.CodigoTipoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCorta", oENPerfiles.DescripcionCorta, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionPerfil", oENPerfiles.DescripcionPerfil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFin", oENPerfiles.FechaFin, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicio", oENPerfiles.FechaInicio, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argGeneraOrden", oENPerfiles.GeneraOrden, TipoParametro.STR, Direccion.INPUT);
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

        public bool Eliminar(string CodigoPerfil)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenPerfiles_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPerfil", CodigoPerfil, TipoParametro.STR, Direccion.INPUT);
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
