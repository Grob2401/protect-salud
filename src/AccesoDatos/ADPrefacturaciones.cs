using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{
    public class ADPrefacturaciones
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENPreFacturacion> ObtenerTodos(ENDatosPreFacBusqueda enpf)
        {
            DbCommand oCommand = null;
            List<ENPreFacturacion> oListaPreFacturaciones = new List<ENPreFacturacion>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_Calcula");
                //'2010', '06','20100601', '20100630','0'
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", enpf.anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", enpf.mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@fchDesde", enpf.txtdesde, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@fchHasta", enpf.txthasta, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", enpf.option, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PcsStatus", enpf.PcsStatus, TipoParametro.STR, Direccion.INPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENPreFacturacion oENPreFacturacion = new ENPreFacturacion();
                    oENPreFacturacion.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENPreFacturacion.RucDni = oDataReader["RucDni"].ToString();
                    oENPreFacturacion.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oENPreFacturacion.DescripcionTipoAsegurado = oDataReader["DescripcionTipoAsegurado"].ToString();                    
                    oENPreFacturacion.RegCounts = oDataReader["RegCounts"].ToString();
                    oENPreFacturacion.AporteAfiliados = Convert.ToDouble(oDataReader["AporteAfiliados"]);
                    oENPreFacturacion.AporteEmpresas = Convert.ToDouble(oDataReader["AporteEmpresas"]);
                    oListaPreFacturaciones.Add(oENPreFacturacion);
                }
                return oListaPreFacturaciones;
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

        public List<ENPrefacturacionDetalleContratos> Contratos(string anio, string mes, string psespecial, string status, string cliente,string tipoAseg)
        {
            DbCommand oCommand = null;
            List<ENPrefacturacionDetalleContratos> oENPreFacturacionDetalleContratos = new List<ENPrefacturacionDetalleContratos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_PreFacturacion_Detalle_Contratos");
                //'2010', '06','20100601', '20100630','0'
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", psespecial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsStatus", status, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DescripcionTipoAsegurado", tipoAseg, TipoParametro.STR, Direccion.INPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENPrefacturacionDetalleContratos oENPreFacturacionDetalleContrato = new ENPrefacturacionDetalleContratos();
                    oENPreFacturacionDetalleContrato.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENPreFacturacionDetalleContrato.CodigoPlan = oDataReader["CodigoPlan"].ToString();
                    oENPreFacturacionDetalleContrato.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                    oENPreFacturacionDetalleContrato.Categoria = oDataReader["Categoria"].ToString();
                    oENPreFacturacionDetalleContrato.CodigoTipoTrabajador = oDataReader["CodigoTipoTrabajador"].ToString();
                    oENPreFacturacionDetalleContrato.FchIniAsgContrato = Convert.ToDateTime(oDataReader["FchIniAsgContrato"]);
                    oENPreFacturacionDetalleContrato.FchNacimiento = Convert.ToDateTime(oDataReader["FchNacimiento"]);
                    oENPreFacturacionDetalleContrato.Titular = oDataReader["Titular"].ToString();
                    oENPreFacturacionDetalleContrato.Asegurado = oDataReader["Asegurado"].ToString();
                    oENPreFacturacionDetalleContrato.DescripcionTipoAsegurado = oDataReader["DescripcionTipoAsegurado"].ToString();
                    oENPreFacturacionDetalleContrato.CodigoPrima = oDataReader["CodigoPrima"].ToString();
                    oENPreFacturacionDetalleContrato.DescripcionPrima = oDataReader["DescripcionPrima"].ToString();
                    oENPreFacturacionDetalleContrato.AporteAfiliado = Convert.ToDouble(oDataReader["AporteAfiliado"]);
                    oENPreFacturacionDetalleContratos.Add(oENPreFacturacionDetalleContrato);
                }
                return oENPreFacturacionDetalleContratos;
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

        public bool Generar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_PreFacturacion_Generar");
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", psespecial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsStatus", status, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DescripcionTipoAsegurado", tipoAseg, TipoParametro.STR, Direccion.INPUT);

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

        public bool Aprobar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_PreFacturacion_Aprobar");
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", psespecial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsStatus", status, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DescripcionTipoAsegurado", tipoAseg, TipoParametro.STR, Direccion.INPUT);

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

        public bool ctaCorriente(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_PreFacturacion_GenerarConCtaCorriente");
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", psespecial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsStatus", status, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DescripcionTipoAsegurado", tipoAseg, TipoParametro.STR, Direccion.INPUT);

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

        public bool Facturar(string anio, string mes, string psespecial, string status, string cliente, string tipoAseg)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Facturacion_PreFacturacion_Facturar");
                GenericDataAccess.AgregarParametro(oCommand, "@anoProceso", anio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@mesProceso", mes, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsEspecial", psespecial, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pcsStatus", status, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DescripcionTipoAsegurado", tipoAseg, TipoParametro.STR, Direccion.INPUT);

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
