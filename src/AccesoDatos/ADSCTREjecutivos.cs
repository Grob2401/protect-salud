using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSCTREjecutivos
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSCTREjecutivos> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSCTREjecutivos> oListaSCTREjecutivos = new List<ENSCTREjecutivos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTREjecutivos_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSCTREjecutivos oEnListaSCTREjecutivos = new ENSCTREjecutivos();
                    oEnListaSCTREjecutivos.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oEnListaSCTREjecutivos.CodigoVendedor = oDataReader["CodigoVendedor"].ToString();
                    oEnListaSCTREjecutivos.Destino = oDataReader["Destino"].ToString();
                    oEnListaSCTREjecutivos.NombreEjecutivo = oDataReader["NombreEjecutivo"].ToString();

                    oListaSCTREjecutivos.Add(oEnListaSCTREjecutivos);
                }
                return oListaSCTREjecutivos;
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
        public ENSCTREjecutivos ObtenerUno(string CodigoEjecutivo)
        {
            DbCommand oCommand = null;
            ENSCTREjecutivos oENSCTREjecutivos = new ENSCTREjecutivos();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTREjecutivos_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", oENSCTREjecutivos.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSCTREjecutivos.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENSCTREjecutivos.CodigoVendedor = oDataReader["CodigoVendedor"].ToString();
                    oENSCTREjecutivos.Destino = oDataReader["Destino"].ToString();
                    oENSCTREjecutivos.NombreEjecutivo = oDataReader["NombreEjecutivo"].ToString();

                }
                return oENSCTREjecutivos;
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

        public bool Insertar(ENSCTREjecutivos oENSCTREjecutivos)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTREjecutivos_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", oENSCTREjecutivos.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENSCTREjecutivos.CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDestino", oENSCTREjecutivos.Destino, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombreEjecutivo", oENSCTREjecutivos.NombreEjecutivo, TipoParametro.STR, Direccion.INPUT);

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

        public bool Actualizar(ENSCTREjecutivos oENSCTREjecutivos)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTREjecutivos_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", oENSCTREjecutivos.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENSCTREjecutivos.CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDestino", oENSCTREjecutivos.Destino, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombreEjecutivo", oENSCTREjecutivos.NombreEjecutivo, TipoParametro.STR, Direccion.INPUT);

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

        public bool Eliminar(string CodigoEjecutivo)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTREjecutivos_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoEjecutivo", CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);

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
