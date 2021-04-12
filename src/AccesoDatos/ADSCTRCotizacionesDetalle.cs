using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSCTRCotizacionesDetalle
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSCTRCotizacionesDetalle> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSCTRCotizacionesDetalle> oListaSCTRCotizacionesDetalle = new List<ENSCTRCotizacionesDetalle>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizacionesDetalle_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSCTRCotizacionesDetalle oEnListaSCTRCotizacionesDetalle = new ENSCTRCotizacionesDetalle();
                    oEnListaSCTRCotizacionesDetalle.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oEnListaSCTRCotizacionesDetalle.CodigoTipoEmpleado = oDataReader["CodigoTipoEmpleado"].ToString();
                    oEnListaSCTRCotizacionesDetalle.ImporteDerechoEmision = Convert.ToDouble(oDataReader["ImporteDerechoEmision"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteDerechoEmisionPension = Convert.ToDouble(oDataReader["ImporteDerechoEmisionPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteIGV = Convert.ToDouble(oDataReader["ImporteIGV"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteIGVPension = Convert.ToDouble(oDataReader["ImporteIGVPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaNeta = Convert.ToDouble(oDataReader["ImportePrimaNeta"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaNetaPension = Convert.ToDouble(oDataReader["ImportePrimaNetaPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaTotal = Convert.ToDouble(oDataReader["ImportePrimaTotal"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaTotalPension = Convert.ToDouble(oDataReader["ImportePrimaTotalPension"]);
                    oEnListaSCTRCotizacionesDetalle.Item = oDataReader["Item"].ToString();
                    oEnListaSCTRCotizacionesDetalle.NumeroTrabajadores = Convert.ToInt32(oDataReader["NumeroTrabajadores"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredor = Convert.ToDouble(oDataReader["PorcentajeCorredor"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredorPension = Convert.ToDouble(oDataReader["PorcentajeCorredorPension"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredorPensionOpe = Convert.ToDouble(oDataReader["PorcentajeCorredorPensionOpe"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasa = Convert.ToDouble(oDataReader["PorcentajeTasa"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasaPension = Convert.ToDouble(oDataReader["PorcentajeTasaPension"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasaPensionOpe = Convert.ToDouble(oDataReader["PorcentajeTasaPensionOpe"]);

                    oListaSCTRCotizacionesDetalle.Add(oEnListaSCTRCotizacionesDetalle);
                }
                return oListaSCTRCotizacionesDetalle;
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
        //CAMBIAR ITEM
        public List<ENSCTRCotizacionesDetalle> ObtenerUno(string CodigoCotizacion,string Item)
        {
            DbCommand oCommand = null;
            List<ENSCTRCotizacionesDetalle> oListaSCTRCotizacionesDetalle = new List<ENSCTRCotizacionesDetalle>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizacionesDetalle_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argItem", Item, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    ENSCTRCotizacionesDetalle oEnListaSCTRCotizacionesDetalle = new ENSCTRCotizacionesDetalle();
                    oEnListaSCTRCotizacionesDetalle.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oEnListaSCTRCotizacionesDetalle.CodigoTipoEmpleado = oDataReader["CodigoTipoEmpleado"].ToString();
                    oEnListaSCTRCotizacionesDetalle.ImporteDerechoEmision = Convert.ToDouble(oDataReader["ImporteDerechoEmision"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteDerechoEmisionPension = Convert.ToDouble(oDataReader["ImporteDerechoEmisionPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteIGV = Convert.ToDouble(oDataReader["ImporteIGV"]);
                    oEnListaSCTRCotizacionesDetalle.ImporteIGVPension = Convert.ToDouble(oDataReader["ImporteIGVPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaNeta = Convert.ToDouble(oDataReader["ImportePrimaNeta"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaNetaPension = Convert.ToDouble(oDataReader["ImportePrimaNetaPension"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaTotal = Convert.ToDouble(oDataReader["ImportePrimaTotal"]);
                    oEnListaSCTRCotizacionesDetalle.ImportePrimaTotalPension = Convert.ToDouble(oDataReader["ImportePrimaTotalPension"]);
                    oEnListaSCTRCotizacionesDetalle.Item = oDataReader["Item"].ToString();
                    oEnListaSCTRCotizacionesDetalle.NumeroTrabajadores = Convert.ToInt32(oDataReader["NumeroTrabajadores"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredor = Convert.ToDouble(oDataReader["PorcentajeCorredor"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredorPension = Convert.ToDouble(oDataReader["PorcentajeCorredorPension"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeCorredorPensionOpe = Convert.ToDouble(oDataReader["PorcentajeCorredorPensionOpe"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasa = Convert.ToDouble(oDataReader["PorcentajeTasa"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasaPension = Convert.ToDouble(oDataReader["PorcentajeTasaPension"]);
                    oEnListaSCTRCotizacionesDetalle.PorcentajeTasaPensionOpe = Convert.ToDouble(oDataReader["PorcentajeTasaPensionOpe"]);
                    oListaSCTRCotizacionesDetalle.Add(oEnListaSCTRCotizacionesDetalle);
                }
                return oListaSCTRCotizacionesDetalle;
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

        public bool Insertar(ENSCTRCotizacionesDetalle oENSCTRCotizacionesDetalle)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizacionesDetalle_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", oENSCTRCotizacionesDetalle.CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoEmpleado", oENSCTRCotizacionesDetalle.CodigoTipoEmpleado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteDerechoEmision", oENSCTRCotizacionesDetalle.ImporteDerechoEmision, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteDerechoEmisionPension", oENSCTRCotizacionesDetalle.ImporteDerechoEmisionPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteIGV", oENSCTRCotizacionesDetalle.ImporteIGV, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteIGVPension", oENSCTRCotizacionesDetalle.ImporteIGVPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaNeta", oENSCTRCotizacionesDetalle.ImportePrimaNeta, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaNetaPension", oENSCTRCotizacionesDetalle.ImportePrimaNetaPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaTotal", oENSCTRCotizacionesDetalle.ImportePrimaTotal, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaTotalPension", oENSCTRCotizacionesDetalle.ImportePrimaTotalPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argItem", oENSCTRCotizacionesDetalle.Item, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNumeroTrabajadores", oENSCTRCotizacionesDetalle.NumeroTrabajadores, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredor", oENSCTRCotizacionesDetalle.PorcentajeCorredor, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredorPension", oENSCTRCotizacionesDetalle.PorcentajeCorredorPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredorPensionOpe", oENSCTRCotizacionesDetalle.PorcentajeCorredorPensionOpe, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasa", oENSCTRCotizacionesDetalle.PorcentajeTasa, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasaPension", oENSCTRCotizacionesDetalle.PorcentajeTasaPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasaPensionOpe", oENSCTRCotizacionesDetalle.PorcentajeTasaPensionOpe, TipoParametro.DBL, Direccion.INPUT);

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

        public bool Actualizar(ENSCTRCotizacionesDetalle oENSCTRCotizacionesDetalle)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizacionesDetalle_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", oENSCTRCotizacionesDetalle.CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoEmpleado", oENSCTRCotizacionesDetalle.CodigoTipoEmpleado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteDerechoEmision", oENSCTRCotizacionesDetalle.ImporteDerechoEmision, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteDerechoEmisionPension", oENSCTRCotizacionesDetalle.ImporteDerechoEmisionPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteIGV", oENSCTRCotizacionesDetalle.ImporteIGV, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImporteIGVPension", oENSCTRCotizacionesDetalle.ImporteIGVPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaNeta", oENSCTRCotizacionesDetalle.ImportePrimaNeta, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaNetaPension", oENSCTRCotizacionesDetalle.ImportePrimaNetaPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaTotal", oENSCTRCotizacionesDetalle.ImportePrimaTotal, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argImportePrimaTotalPension", oENSCTRCotizacionesDetalle.ImportePrimaTotalPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argItem", oENSCTRCotizacionesDetalle.Item, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNumeroTrabajadores", oENSCTRCotizacionesDetalle.NumeroTrabajadores, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredor", oENSCTRCotizacionesDetalle.PorcentajeCorredor, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredorPension", oENSCTRCotizacionesDetalle.PorcentajeCorredorPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeCorredorPensionOpe", oENSCTRCotizacionesDetalle.PorcentajeCorredorPensionOpe, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasa", oENSCTRCotizacionesDetalle.PorcentajeTasa, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasaPension", oENSCTRCotizacionesDetalle.PorcentajeTasaPension, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPorcentajeTasaPensionOpe", oENSCTRCotizacionesDetalle.PorcentajeTasaPensionOpe, TipoParametro.DBL, Direccion.INPUT);

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

        public bool Eliminar(string CodigoCotizacion)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizacionesDetalle_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
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
