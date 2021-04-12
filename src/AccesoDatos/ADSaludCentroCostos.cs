using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludCentroCostos
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludCentroCostos> ObtenerTodos(string CodigoCliente)
        {
            DbCommand oCommand = null;
            List<ENSaludCentroCostos> oListaSaludCentroCostos = new List<ENSaludCentroCostos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludCentroCostos oEnListaSaludCentroCostos = new ENSaludCentroCostos();
                    oEnListaSaludCentroCostos.CodigoCentroCosto = oDataReader["CodigoCentroCosto"].ToString();
                    oEnListaSaludCentroCostos.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludCentroCostos.DescripcionCentroCosto = oDataReader["DescripcionCentroCosto"].ToString();
                    oEnListaSaludCentroCostos.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oEnListaSaludCentroCostos.RUC = oDataReader["RUC"].ToString();

                    oListaSaludCentroCostos.Add(oEnListaSaludCentroCostos);
                }
                return oListaSaludCentroCostos;
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
        public ENSaludCentroCostos ObtenerUno(string CodigoCliente,string CodigoCentroCosto)
        {
            DbCommand oCommand = null;
            ENSaludCentroCostos oENSaludCentroCostos = new ENSaludCentroCostos();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCentroCosto", CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludCentroCostos.CodigoCentroCosto = oDataReader["CodigoCentroCosto"].ToString();
                    oENSaludCentroCostos.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSaludCentroCostos.DescripcionCentroCosto = oDataReader["DescripcionCentroCosto"].ToString();
                    oENSaludCentroCostos.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENSaludCentroCostos.RUC = oDataReader["RUC"].ToString();

                }
                return oENSaludCentroCostos;
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

        public ENSaludCentroCostos ObtenerUnoCotizacion(string CodigoCliente,string CodigoCotizacion, string CodigoCentroCosto)
        {
            DbCommand oCommand = null;
            ENSaludCentroCostos oENSaludCentroCostos = new ENSaludCentroCostos();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCentroCosto", CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludCentroCostos.CodigoCentroCosto = oDataReader["CodigoCentroCosto"].ToString();
                    oENSaludCentroCostos.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSaludCentroCostos.DescripcionCentroCosto = oDataReader["DescripcionCentroCosto"].ToString();
                    oENSaludCentroCostos.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENSaludCentroCostos.RUC = oDataReader["RUC"].ToString();

                }
                return oENSaludCentroCostos;
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

        public bool Insertar(ENSaludCentroCostos oENSaludCentroCostos)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", oENSaludCentroCostos.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCentroCosto", oENSaludCentroCostos.DescripcionCentroCosto, TipoParametro.STR, Direccion.INPUT);
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

        public bool Actualizar(ENSaludCentroCostos oENSaludCentroCostos)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCentroCosto", oENSaludCentroCostos.CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", oENSaludCentroCostos.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCentroCosto", oENSaludCentroCostos.DescripcionCentroCosto, TipoParametro.STR, Direccion.INPUT);
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

        public bool Eliminar(string CodigoCliente,string CodigoCentroCosto)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludCentroCostos_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCentroCosto", CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
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