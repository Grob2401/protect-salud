using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludPlanes
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludPlanes> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSaludPlanes> oListaSaludPlanes = new List<ENSaludPlanes>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludPlanes_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludPlanes oEnListaSaludPlanes = new ENSaludPlanes();
                    oEnListaSaludPlanes.Capa = oDataReader["Capa"].ToString();
                    oEnListaSaludPlanes.Clase = oDataReader["Clase"].ToString();
                    oEnListaSaludPlanes.CodigoPlan = oDataReader["CodigoPlan"].ToString();
                    oEnListaSaludPlanes.CreadoPor = oDataReader["CreadoPor"].ToString();
                    oEnListaSaludPlanes.DescripcionPlan = oDataReader["DescripcionPlan"].ToString();
                    //oEnListaSaludPlanes.FechaCreacion=DateTime.Parse(oDataReader["FechaCreacion"].ToString());
                    oEnListaSaludPlanes.FechaCreacion = oDataReader["FechaCreacion"] == DBNull.Value
                   ? DateTime.Now
                   : Convert.ToDateTime(oDataReader["FechaCreacion"]);
                    oEnListaSaludPlanes.FechaModificacion = oDataReader["FechaModificacion"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaModificacion"]);
                    //oEnListaSaludPlanes.FechaModificacion=DateTime.Parse(oDataReader["FechaModificacion"].ToString());

                    oEnListaSaludPlanes.FinVigencia = DateTime.Parse(oDataReader["FinVigencia"].ToString());
                    oEnListaSaludPlanes.InicioVigencia = DateTime.Parse(oDataReader["InicioVigencia"].ToString());
                    oEnListaSaludPlanes.ModificadoPor = oDataReader["ModificadoPor"].ToString();
                    oEnListaSaludPlanes.Mostrar = oDataReader["Mostrar"].ToString();
                    oEnListaSaludPlanes.Observaciones = oDataReader["Observaciones"].ToString();
                    oEnListaSaludPlanes.Oncologico = oDataReader["Oncologico"].ToString();
                    oEnListaSaludPlanes.TipoPlan = oDataReader["TipoPlan"].ToString();

                    oListaSaludPlanes.Add(oEnListaSaludPlanes);
                }
                return oListaSaludPlanes;
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
        public ENSaludPlanes ObtenerUno(string CodigoPlan)
        {
            DbCommand oCommand = null;
            ENSaludPlanes oENSaludPlanes = new ENSaludPlanes();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludPlanes_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", oENSaludPlanes.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludPlanes.Capa = oDataReader["Capa"].ToString();
                    oENSaludPlanes.Clase = oDataReader["Clase"].ToString();
                    oENSaludPlanes.CodigoPlan = oDataReader["CodigoPlan"].ToString();
                    oENSaludPlanes.CreadoPor = oDataReader["CreadoPor"].ToString();
                    oENSaludPlanes.DescripcionPlan = oDataReader["DescripcionPlan"].ToString();
                    oENSaludPlanes.FechaCreacion = DateTime.Parse(oDataReader["FechaCreacion"].ToString());
                    oENSaludPlanes.FechaModificacion = DateTime.Parse(oDataReader["FechaModificacion"].ToString());
                    oENSaludPlanes.FinVigencia = DateTime.Parse(oDataReader["FinVigencia"].ToString());
                    oENSaludPlanes.InicioVigencia = DateTime.Parse(oDataReader["InicioVigencia"].ToString());
                    oENSaludPlanes.ModificadoPor = oDataReader["ModificadoPor"].ToString();
                    oENSaludPlanes.Mostrar = oDataReader["Mostrar"].ToString();
                    oENSaludPlanes.Observaciones = oDataReader["Observaciones"].ToString();
                    oENSaludPlanes.Oncologico = oDataReader["Oncologico"].ToString();
                    oENSaludPlanes.TipoPlan = oDataReader["TipoPlan"].ToString();

                }
                return oENSaludPlanes;
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

        public bool Insertar(ENSaludPlanes oENSaludPlanes)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludPlanes_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCapa", oENSaludPlanes.Capa, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argClase", oENSaludPlanes.Clase, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", oENSaludPlanes.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCreadoPor", oENSaludPlanes.CreadoPor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionPlan", oENSaludPlanes.DescripcionPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaCreacion", oENSaludPlanes.FechaCreacion, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaModificacion", oENSaludPlanes.FechaModificacion, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFinVigencia", oENSaludPlanes.FinVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argInicioVigencia", oENSaludPlanes.InicioVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argModificadoPor", oENSaludPlanes.ModificadoPor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argMostrar", oENSaludPlanes.Mostrar, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argObservaciones", oENSaludPlanes.Observaciones, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argOncologico", oENSaludPlanes.Oncologico, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTipoPlan", oENSaludPlanes.TipoPlan, TipoParametro.STR, Direccion.INPUT);

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

        public bool Actualizar(ENSaludPlanes oENSaludPlanes)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludPlanes_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCapa", oENSaludPlanes.Capa, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argClase", oENSaludPlanes.Clase, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", oENSaludPlanes.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCreadoPor", oENSaludPlanes.CreadoPor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionPlan", oENSaludPlanes.DescripcionPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaCreacion", oENSaludPlanes.FechaCreacion, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaModificacion", oENSaludPlanes.FechaModificacion, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFinVigencia", oENSaludPlanes.FinVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argInicioVigencia", oENSaludPlanes.InicioVigencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argModificadoPor", oENSaludPlanes.ModificadoPor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argMostrar", oENSaludPlanes.Mostrar, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argObservaciones", oENSaludPlanes.Observaciones, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argOncologico", oENSaludPlanes.Oncologico, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTipoPlan", oENSaludPlanes.TipoPlan, TipoParametro.STR, Direccion.INPUT);

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

        public bool Eliminar(string CodigoPlan)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludPlanes_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPlan", CodigoPlan, TipoParametro.STR, Direccion.INPUT);

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
