using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludContratos
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludContratos> ObtenerTodos(string CodigoCliente)
        {
            DbCommand oCommand = null;
            List<ENSaludContratos> oListaSaludContratos = new List<ENSaludContratos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratos_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludContratos oEnListaSaludContratos = new ENSaludContratos();
                    oEnListaSaludContratos.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludContratos.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oEnListaSaludContratos.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oEnListaSaludContratos.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oEnListaSaludContratos.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oEnListaSaludContratos.CodigoTipoContrato = oDataReader["CodigoTipoContrato"].ToString();
                    oEnListaSaludContratos.FinVigencia = DateTime.Parse(oDataReader["FinVigencia"].ToString());
                    oEnListaSaludContratos.FlagTmp = oDataReader["FlagTmp"].ToString();
                    oEnListaSaludContratos.InicioVigencia = DateTime.Parse(oDataReader["InicioVigencia"].ToString());
                    oEnListaSaludContratos.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oEnListaSaludContratos.RUC = oDataReader["RUC"].ToString();

                    oListaSaludContratos.Add(oEnListaSaludContratos);
                }
                return oListaSaludContratos;
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
        public ENSaludContratos ObtenerUno(string CodigoCliente, string CodigoContrato)
        {
            DbCommand oCommand = null;
            ENSaludContratos oENSaludContratos = new ENSaludContratos();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratos_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoContrato", CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludContratos.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSaludContratos.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oENSaludContratos.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENSaludContratos.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oENSaludContratos.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENSaludContratos.CodigoTipoContrato = oDataReader["CodigoTipoContrato"].ToString();
                    oENSaludContratos.FinVigencia = DateTime.Parse(oDataReader["FinVigencia"].ToString());
                    oENSaludContratos.FlagTmp = oDataReader["FlagTmp"].ToString();
                    oENSaludContratos.InicioVigencia = DateTime.Parse(oDataReader["InicioVigencia"].ToString());
                    oENSaludContratos.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENSaludContratos.RUC = oDataReader["RUC"].ToString();

                }
                return oENSaludContratos;
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

        public bool Insertar(ENSaludContratos oENSaludContratos)
        {

            DbCommand oCommand = null;
            oENSaludContratos.CodigoContrato = "";
            string sCodigoContrato = "";
            string sCodigoCotizacion = "";
            //if (oENSaludContratos.CodigoContrato is null)
            //{ sCodigoContrato = ""; }
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Cli_ContratoGrabarContrato");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", oENSaludContratos.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", oENSaludContratos.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCotizacion", oENSaludContratos.CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTipoContrato", oENSaludContratos.CodigoTipoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@InicioVigencia", oENSaludContratos.InicioVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FinalVigencia", oENSaludContratos.FinVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", oENSaludContratos.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoEjecutivo", oENSaludContratos.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
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

        public bool Actualizar(ENSaludContratos oENSaludContratos)
        {

            DbCommand oCommand = null;
            string sCodigoCotizacion = "";
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Cli_ContratoGrabarContrato");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", oENSaludContratos.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", oENSaludContratos.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCotizacion", sCodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTipoContrato", oENSaludContratos.CodigoTipoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@InicioVigencia", oENSaludContratos.InicioVigencia.ToString("dd/MM/yyyy"), TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FinalVigencia", oENSaludContratos.FinVigencia.ToString("dd/MM/yyyy"), TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", oENSaludContratos.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoEjecutivo", oENSaludContratos.CodigoEjecutivo, TipoParametro.STR, Direccion.INPUT);
                //GenericDataAccess.AgregarParametro(oCommand,"@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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

        public bool Eliminar(string CodigoCliente, string CodigoContrato)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratos_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoContrato", CodigoContrato, TipoParametro.STR, Direccion.INPUT);
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
