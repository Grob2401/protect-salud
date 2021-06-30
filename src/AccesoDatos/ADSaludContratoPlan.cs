using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludContratoPlan
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludContratoPlan> ObtenerTodos(string CodigoCliente, string CodigoContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludContratoPlan> oListaSaludContratoPlan = new List<ENSaludContratoPlan>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratoPlan_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente ", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoContrato", CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludContratoPlan oEnListaSaludContratoPlan = new ENSaludContratoPlan();
                    oEnListaSaludContratoPlan.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oEnListaSaludContratoPlan.CodigoPlanSC = oDataReader["CodigoPlan"].ToString();
                    oEnListaSaludContratoPlan.FechaFinContratoPlan = DateTime.Parse(oDataReader["FechaFinContratoPlan"].ToString());
                    oEnListaSaludContratoPlan.FechaInicioContratoPlan = DateTime.Parse(oDataReader["FechaInicioContratoPlan"].ToString());
                    oEnListaSaludContratoPlan.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludContratoPlan.DescripcionPlanSC = oDataReader["DescripcionPlan"].ToString();

                    oListaSaludContratoPlan.Add(oEnListaSaludContratoPlan);
                }
                return oListaSaludContratoPlan;
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
        public ENSaludContratoPlan ObtenerUno(DateTime FechaInicioContratoPlan)
        {
            DbCommand oCommand = null;
            ENSaludContratoPlan oENSaludContratoPlan = new ENSaludContratoPlan();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratoPlan_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicioContratoPlan", oENSaludContratoPlan.FechaInicioContratoPlan, TipoParametro.DT, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludContratoPlan.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oENSaludContratoPlan.CodigoPlanSC = oDataReader["CodigoPlan"].ToString();
                    oENSaludContratoPlan.FechaFinContratoPlan = DateTime.Parse(oDataReader["FechaFinContratoPlan"].ToString());
                    oENSaludContratoPlan.FechaInicioContratoPlan = DateTime.Parse(oDataReader["FechaInicioContratoPlan"].ToString());

                }
                return oENSaludContratoPlan;
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

        public bool Insertar(ENSaludContratoPlan oENSaludContratoPlan)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratoPlan_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoContrato", oENSaludContratoPlan.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", oENSaludContratoPlan.CodigoPlanSC, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFinContratoPlan", oENSaludContratoPlan.FechaFinContratoPlan, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicioContratoPlan", oENSaludContratoPlan.FechaInicioContratoPlan, TipoParametro.DT, Direccion.INPUT);

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

        public bool Actualizar(ENSaludContratoPlan oENSaludContratoPlan)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratoPlan_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoContrato", oENSaludContratoPlan.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", oENSaludContratoPlan.CodigoPlanSC, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFinContratoPlan", oENSaludContratoPlan.FechaFinContratoPlan, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicioContratoPlan", oENSaludContratoPlan.FechaInicioContratoPlan, TipoParametro.DT, Direccion.INPUT);

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

        public bool Eliminar(string contrato)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludContratoPlan_del");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", contrato, TipoParametro.STR, Direccion.INPUT);

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
