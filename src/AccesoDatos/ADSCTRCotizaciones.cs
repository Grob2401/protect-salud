using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSCTRCotizaciones
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSCTRCotizaciones> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSCTRCotizaciones> oListaSCTRCotizaciones = new List<ENSCTRCotizaciones>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_CotizacionLeerIAFAS");
                GenericDataAccess.AgregarParametro(oCommand,"@NumeroCotizacion"," ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@CodigoCliente", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@CodigoCorredor", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@FechaInicio", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@FechaFin", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@CodigoUsuario", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand,"@Tipo", "C", TipoParametro.STR, Direccion.INPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSCTRCotizaciones oEnListaSCTRCotizaciones = new ENSCTRCotizaciones();
                    oEnListaSCTRCotizaciones.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oEnListaSCTRCotizaciones.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oEnListaSCTRCotizaciones.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSCTRCotizaciones.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oEnListaSCTRCotizaciones.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oEnListaSCTRCotizaciones.FechaInicio = oDataReader["FechaInicio"].ToString();
                    oEnListaSCTRCotizaciones.FechaFin = oDataReader["FechaFin"].ToString();
                    oEnListaSCTRCotizaciones.TiempoCobertura = Convert.ToInt32(oDataReader["TiempoCobertura"]);
                    oEnListaSCTRCotizaciones.CodigoMoneda = oDataReader["CodigoMoneda"].ToString();
                    oEnListaSCTRCotizaciones.FechaCotizacion = DateTime.Parse(oDataReader["FechaCotizacion"].ToString());
                    oEnListaSCTRCotizaciones.CodigoUsuarioRegistro = oDataReader["CodigoUsuarioRegistro"].ToString();
                    oEnListaSCTRCotizaciones.CodigoEstado = oDataReader["CodigoEstado"].ToString();
                    oEnListaSCTRCotizaciones.FechaHoraModificacion = DateTime.Parse(oDataReader["FechaHoraModificacion"].ToString());
                    oEnListaSCTRCotizaciones.IdCotizacion = Convert.ToInt32(oDataReader["IdCotizacion"]);
                    oEnListaSCTRCotizaciones.Origen = oDataReader["Origen"].ToString();
                    oEnListaSCTRCotizaciones.PSPoliza = oDataReader["PSPoliza"].ToString();
                    oEnListaSCTRCotizaciones.UbigeoRiesgo = oDataReader["UbigeoRiesgo"].ToString();
                    oEnListaSCTRCotizaciones.GrupoCIIU = oDataReader["GrupoCIIU"].ToString();
                    oEnListaSCTRCotizaciones.PrimaManual = oDataReader["PrimaManual"].ToString();
                    oEnListaSCTRCotizaciones.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oEnListaSCTRCotizaciones.CodigoBrokerAsociado = oDataReader["CodigoBrokerAsociado"].ToString();
                    oEnListaSCTRCotizaciones.NroFacturacion = oDataReader["NroFacturacion"].ToString();
                    oEnListaSCTRCotizaciones.EstadoFacturacion = oDataReader["EstadoFacturacion"].ToString();
                    oEnListaSCTRCotizaciones.CodigoRenovacion = oDataReader["CodigoRenovacion"].ToString();
                    oEnListaSCTRCotizaciones.EstadoRegistaroTXT = oDataReader["EstadoRegistaroTXT"].ToString();
                    oEnListaSCTRCotizaciones.CodigoSede = oDataReader["CodigoSede"].ToString();
                    oEnListaSCTRCotizaciones.EmpresaRUC = oDataReader["EmpresaRUC"].ToString();
                    oEnListaSCTRCotizaciones.EmpresaNombre = oDataReader["EmpresaNombre"].ToString();
                    oEnListaSCTRCotizaciones.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                    oEnListaSCTRCotizaciones.DescripcionCorredor = oDataReader["DescripcionCorredor"].ToString();
                    oEnListaSCTRCotizaciones.DescripcionEstado = oDataReader["DescripcionEstado"].ToString();
                    oEnListaSCTRCotizaciones.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oEnListaSCTRCotizaciones.ProcesoResultado = oDataReader["ProcesoResultado"].ToString();
                    oEnListaSCTRCotizaciones.ProcesoMensaje = oDataReader["ProcesoMensaje"].ToString();
                    oListaSCTRCotizaciones.Add(oEnListaSCTRCotizaciones);
                }
                return oListaSCTRCotizaciones;
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
        public ENSCTRCotizaciones ObtenerUno(string CodigoCotizacion)
        {
            DbCommand oCommand = null;
            ENSCTRCotizaciones oENSCTRCotizaciones = new ENSCTRCotizaciones();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_CotizacionLeerIAFAS");
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroCotizacion", CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaInicio", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaFin", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoUsuario", " ", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Tipo", "C", TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENSCTRCotizaciones.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oENSCTRCotizaciones.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oENSCTRCotizaciones.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSCTRCotizaciones.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENSCTRCotizaciones.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENSCTRCotizaciones.FechaInicio = oDataReader["FechaInicio"].ToString();
                    oENSCTRCotizaciones.FechaFin = oDataReader["FechaFin"].ToString();
                    oENSCTRCotizaciones.TiempoCobertura = Convert.ToInt32(oDataReader["TiempoCobertura"]);
                    oENSCTRCotizaciones.CodigoMoneda = oDataReader["CodigoMoneda"].ToString();
                    oENSCTRCotizaciones.FechaCotizacion = DateTime.Parse(oDataReader["FechaCotizacion"].ToString());
                    oENSCTRCotizaciones.CodigoUsuarioRegistro = oDataReader["CodigoUsuarioRegistro"].ToString();
                    oENSCTRCotizaciones.CodigoEstado = oDataReader["CodigoEstado"].ToString();
                    oENSCTRCotizaciones.FechaHoraModificacion = DateTime.Parse(oDataReader["FechaHoraModificacion"].ToString());
                    oENSCTRCotizaciones.IdCotizacion = Convert.ToInt32(oDataReader["IdCotizacion"]);
                    oENSCTRCotizaciones.Origen = oDataReader["Origen"].ToString();
                    oENSCTRCotizaciones.PSPoliza = oDataReader["PSPoliza"].ToString();
                    oENSCTRCotizaciones.UbigeoRiesgo = oDataReader["UbigeoRiesgo"].ToString();
                    oENSCTRCotizaciones.GrupoCIIU = oDataReader["GrupoCIIU"].ToString();
                    oENSCTRCotizaciones.PrimaManual = oDataReader["PrimaManual"].ToString();
                    oENSCTRCotizaciones.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENSCTRCotizaciones.CodigoBrokerAsociado = oDataReader["CodigoBrokerAsociado"].ToString();
                    oENSCTRCotizaciones.NroFacturacion = oDataReader["NroFacturacion"].ToString();
                    oENSCTRCotizaciones.EstadoFacturacion = oDataReader["EstadoFacturacion"].ToString();
                    oENSCTRCotizaciones.CodigoRenovacion = oDataReader["CodigoRenovacion"].ToString();
                    oENSCTRCotizaciones.EstadoRegistaroTXT = oDataReader["EstadoRegistaroTXT"].ToString();
                    oENSCTRCotizaciones.CodigoSede = oDataReader["CodigoSede"].ToString();
                    oENSCTRCotizaciones.EmpresaRUC = oDataReader["EmpresaRUC"].ToString();
                    oENSCTRCotizaciones.EmpresaNombre = oDataReader["EmpresaNombre"].ToString();
                    oENSCTRCotizaciones.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                    oENSCTRCotizaciones.DescripcionCorredor = oDataReader["DescripcionCorredor"].ToString();
                    oENSCTRCotizaciones.DescripcionEstado = oDataReader["DescripcionEstado"].ToString();
                    oENSCTRCotizaciones.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oENSCTRCotizaciones.ProcesoResultado = oDataReader["ProcesoResultado"].ToString();
                    oENSCTRCotizaciones.ProcesoMensaje = oDataReader["ProcesoMensaje"].ToString();
                }
                return oENSCTRCotizaciones;
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

        public bool Insertar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {

            DbCommand oCommand = null;
            try
            {
            string sTipoProceso = "G";
            double iPorcentajeTasa = 0;
            double iPorcentajeCorredor = 0;
            string sCodigoUsuario = "grojas";
            string sCodigoCorredor = "J6969";
            string sUbigeoRiesgo = "";
            string sFechaInicio = "";
            string sFechaFin = "";


             sFechaInicio = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaInicio);
             sFechaFin = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaFin);

                //sFechaInicio = String.Format("{0:dd/MM/yyyy}", oENSCTRCotizaciones.dtm_FechaInicio);
                //sFechaFin = String.Format("{0:dd/MM/yyyy}", oENSCTRCotizaciones.dtm_FechaFin);

                if (oENSCTRCotizaciones.UbigeoRiesgo is null)
            {
                sUbigeoRiesgo = oENSCTRCotizaciones.CodigoDptoR + oENSCTRCotizaciones.CodigoProvR + oENSCTRCotizaciones.CodigoDistR;
            }
            else
            {
                sUbigeoRiesgo = oENSCTRCotizaciones.UbigeoRiesgo;
            }
            if (oENSCTRCotizaciones.PorcentajeCorredor != 0)
            { iPorcentajeCorredor = oENSCTRCotizaciones.PorcentajeCorredor; }
            else
            { iPorcentajeCorredor = 100; }

            oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_PerCotizacionConsulta");
            GenericDataAccess.AgregarParametro(oCommand, "@TipoProceso", sTipoProceso, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@EmpresaRUC", oENSCTRCotizaciones.EmpresaRUC, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@EmpresaNombre", oENSCTRCotizaciones.EmpresaNombre, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", sCodigoCorredor, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@CodigoCIIU", oENSCTRCotizaciones.CodigoCIIU, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@MontoOperativos", oENSCTRCotizaciones.DetMontoPlanillaOpe, TipoParametro.DBL, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@NumeroOperativos", oENSCTRCotizaciones.DetNumeroTrabajadoresOpe, TipoParametro.INT, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@MontoAdministrativos", oENSCTRCotizaciones.DetMontoPlanillaAdm, TipoParametro.DBL, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@NumeroAdministrativos", oENSCTRCotizaciones.DetNumeroTrabajadoresAdm, TipoParametro.INT, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@CodigoMoneda", oENSCTRCotizaciones.CodigoMoneda, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@FechaInicio", sFechaInicio, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@FechaFin", sFechaFin, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@TiempoCobertura", oENSCTRCotizaciones.TiempoCobertura, TipoParametro.INT, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeTasa", iPorcentajeTasa, TipoParametro.DBL, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeCorredor", iPorcentajeCorredor, TipoParametro.DBL, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@NumeroCotizacion", "", TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@Usuario", sCodigoUsuario, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@UbigeoRiesgo", sUbigeoRiesgo, TipoParametro.STR, Direccion.INPUT);
            GenericDataAccess.AgregarParametro(oCommand, "@Origen", oENSCTRCotizaciones.Origen, TipoParametro.STR, Direccion.INPUT);

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

        public bool Actualizar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {

            DbCommand oCommand = null;
            try
            {

                string sTipoProceso = "U";
                double iPorcentajeTasa = 0;
                double iPorcentajeCorredor = 0;
                string sCodigoUsuario = "grojas";
                string sCodigoCorredor = "J6969";
                string sUbigeoRiesgo = "";
                string sFechaInicio = "";
                string sFechaFin = "";

                sFechaInicio = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaInicio);
                sFechaFin = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaFin);

                if (oENSCTRCotizaciones.UbigeoRiesgo is null)
                {
                    sUbigeoRiesgo = oENSCTRCotizaciones.CodigoDptoR + oENSCTRCotizaciones.CodigoProvR + oENSCTRCotizaciones.CodigoDistR;
                }
                else
                {
                    sUbigeoRiesgo = oENSCTRCotizaciones.UbigeoRiesgo;
                }
                if (oENSCTRCotizaciones.PorcentajeCorredor != 0)
                { iPorcentajeCorredor = oENSCTRCotizaciones.PorcentajeCorredor; }
                else
                { iPorcentajeCorredor = 100; }
                if (oENSCTRCotizaciones.PorcentajeTasa != 0)
                { iPorcentajeTasa = oENSCTRCotizaciones.PorcentajeTasa; }
                else
                { iPorcentajeTasa = 0; }

                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_PerCotizacionConsulta");
                GenericDataAccess.AgregarParametro(oCommand, "@TipoProceso", sTipoProceso, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@EmpresaRUC", oENSCTRCotizaciones.EmpresaRUC, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@EmpresaNombre", oENSCTRCotizaciones.EmpresaNombre, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", sCodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCIIU", oENSCTRCotizaciones.CodigoCIIU, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@MontoOperativos", oENSCTRCotizaciones.DetMontoPlanillaOpe, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroOperativos", oENSCTRCotizaciones.DetNumeroTrabajadoresOpe, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@MontoAdministrativos", oENSCTRCotizaciones.DetMontoPlanillaAdm, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroAdministrativos", oENSCTRCotizaciones.DetNumeroTrabajadoresAdm, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoMoneda", oENSCTRCotizaciones.CodigoMoneda, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaInicio", sFechaInicio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaFin", sFechaFin, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TiempoCobertura", oENSCTRCotizaciones.TiempoCobertura, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeTasa", iPorcentajeTasa, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeCorredor", iPorcentajeCorredor, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroCotizacion", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Usuario", sCodigoUsuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@UbigeoRiesgo", sUbigeoRiesgo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Origen", oENSCTRCotizaciones.Origen, TipoParametro.STR, Direccion.INPUT);
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
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCotizaciones_del");
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

        public ENSCTRCotizaciones ObtenerUnoConDetalle(string CodigoCotizacion)
        {
            DbCommand oCommand = null;
            ENSCTRCotizaciones oENSCTRCotizaciones = new ENSCTRCotizaciones();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_CotizacionLeerIAFAS_Detalle");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENSCTRCotizaciones.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oENSCTRCotizaciones.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oENSCTRCotizaciones.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSCTRCotizaciones.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENSCTRCotizaciones.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENSCTRCotizaciones.FechaInicio = oDataReader["FechaInicio"].ToString();
                    oENSCTRCotizaciones.FechaFin = oDataReader["FechaFin"].ToString();
                    oENSCTRCotizaciones.TiempoCobertura = Convert.ToInt32(oDataReader["TiempoCobertura"]);
                    oENSCTRCotizaciones.CodigoMoneda = oDataReader["CodigoMoneda"].ToString();
                    oENSCTRCotizaciones.FechaCotizacion = DateTime.Parse(oDataReader["FechaCotizacion"].ToString());
                    oENSCTRCotizaciones.CodigoUsuarioRegistro = oDataReader["CodigoUsuarioRegistro"].ToString();
                    oENSCTRCotizaciones.CodigoEstado = oDataReader["CodigoEstado"].ToString();
                    oENSCTRCotizaciones.FechaHoraModificacion = DateTime.Parse(oDataReader["FechaHoraModificacion"].ToString());
                    oENSCTRCotizaciones.IdCotizacion = Convert.ToInt32(oDataReader["IdCotizacion"]);
                    oENSCTRCotizaciones.Origen = oDataReader["Origen"].ToString();
                    oENSCTRCotizaciones.PSPoliza = oDataReader["PSPoliza"].ToString();
                    oENSCTRCotizaciones.UbigeoRiesgo = oDataReader["UbigeoRiesgo"].ToString();
                    oENSCTRCotizaciones.GrupoCIIU = oDataReader["GrupoCIIU"].ToString();
                    oENSCTRCotizaciones.PrimaManual = oDataReader["PrimaManual"].ToString();
                    oENSCTRCotizaciones.CodigoEjecutivo = oDataReader["CodigoEjecutivo"].ToString();
                    oENSCTRCotizaciones.CodigoBrokerAsociado = oDataReader["CodigoBrokerAsociado"].ToString();
                    oENSCTRCotizaciones.NroFacturacion = oDataReader["NroFacturacion"].ToString();
                    oENSCTRCotizaciones.EstadoFacturacion = oDataReader["EstadoFacturacion"].ToString();
                    oENSCTRCotizaciones.CodigoRenovacion = oDataReader["CodigoRenovacion"].ToString();
                    oENSCTRCotizaciones.EstadoRegistaroTXT = oDataReader["EstadoRegistaroTXT"].ToString();
                    oENSCTRCotizaciones.CodigoSede = oDataReader["CodigoSede"].ToString();
                    oENSCTRCotizaciones.EmpresaRUC = oDataReader["EmpresaRUC"].ToString();
                    oENSCTRCotizaciones.EmpresaNombre = oDataReader["EmpresaNombre"].ToString();
                    oENSCTRCotizaciones.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                    oENSCTRCotizaciones.DescripcionCorredor = oDataReader["DescripcionCorredor"].ToString();
                    oENSCTRCotizaciones.DescripcionEstado = oDataReader["DescripcionEstado"].ToString();
                    oENSCTRCotizaciones.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oENSCTRCotizaciones.ProcesoResultado = oDataReader["ProcesoResultado"].ToString();
                    oENSCTRCotizaciones.ProcesoMensaje = oDataReader["ProcesoMensaje"].ToString();
                    //Detalle Operativos
                    oENSCTRCotizaciones.DetCodigoCotizacionOpe = oDataReader["DetCodigoCotizacionOpe"].ToString();
                    oENSCTRCotizaciones.DetCodigoTipoEmpleadoOpe = oDataReader["DetCodigoTipoEmpleadoOpe"].ToString();
                    oENSCTRCotizaciones.DetImporteDerechoEmisionOpe = oDataReader["DetImporteDerechoEmisionOpe"] == DBNull.Value
                                                    ? 0.00
                                                    : Convert.ToDouble(oDataReader["DetImporteDerechoEmisionOpe"]);
                    //oENSCTRCotizaciones.DetImporteDerechoEmisionPensionOpe = Convert.ToDouble(oDataReader["DetImporteDerechoEmisionPensionOpe"]);

                    oENSCTRCotizaciones.DetImporteDerechoEmisionPensionOpe = oDataReader["DetImporteDerechoEmisionPensionOpe"] == DBNull.Value 
                                                    ? 0.00
                                                    : Convert.ToDouble(oDataReader["DetImporteDerechoEmisionPensionOpe"]);

                    oENSCTRCotizaciones.DetImporteIGVOpe = oDataReader["DetImporteIGVOpe"] == DBNull.Value
                                                    ? 0.00
                                                    : Convert.ToDouble(oDataReader["DetImporteIGVOpe"]);
                    //oENSCTRCotizaciones.DetImporteIGVPensionOpe = Convert.ToDouble(oDataReader["DetImporteIGVPensionOpe"]);


                    oENSCTRCotizaciones.DetImporteIGVPensionOpe = oDataReader["DetImporteIGVPensionOpe"] == DBNull.Value
                                ? 0.00
                                : Convert.ToDouble(oDataReader["DetImporteIGVPensionOpe"]);

                    //oENSCTRCotizaciones.DetImportePrimaNetaOpe = Convert.ToDouble(oDataReader["DetImportePrimaNetaOpe"]);

                    oENSCTRCotizaciones.DetImportePrimaNetaOpe = oDataReader["DetImportePrimaNetaOpe"] == DBNull.Value
                            ? 0.00
                            : Convert.ToDouble(oDataReader["DetImportePrimaNetaOpe"]);

                    //oENSCTRCotizaciones.DetImportePrimaNetaPensionOpe = Convert.ToDouble(oDataReader["DetImportePrimaNetaPensionOpe"]);


                    oENSCTRCotizaciones.DetImportePrimaNetaPensionOpe = oDataReader["DetImportePrimaNetaPensionOpe"] == DBNull.Value
                            ?  0.00
                            :  Convert.ToDouble(oDataReader["DetImportePrimaNetaPensionOpe"]);

                    oENSCTRCotizaciones.DetImportePrimaTotalOpe = oDataReader["DetImportePrimaTotalOpe"] == DBNull.Value
                            ? 0.00
                            : Convert.ToDouble(oDataReader["DetImportePrimaTotalOpe"]);
                    
                    //oENSCTRCotizaciones.DetImportePrimaTotalPensionOpe = Convert.ToDouble(oDataReader["DetImportePrimaTotalPensionOpe"]);
                    
                    
                    oENSCTRCotizaciones.DetItemOpe = oDataReader["DetItemOpe"].ToString();
                    oENSCTRCotizaciones.DetMontoPlanillaOpe = oDataReader["DetMontoPlanillaOpe"] == DBNull.Value
                            ? 0.00
                            : Convert.ToDouble(oDataReader["DetMontoPlanillaOpe"]);
                    
                    oENSCTRCotizaciones.DetNumeroTrabajadoresOpe = oDataReader["DetNumeroTrabajadoresOpe"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["DetNumeroTrabajadoresOpe"]);
                    oENSCTRCotizaciones.DetPorcentajeCorredorOpe = oDataReader["DetPorcentajeCorredorOpe"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeCorredorOpe"]);
                    oENSCTRCotizaciones.DetPorcentajeTasaOpe = oDataReader["DetPorcentajeTasaOpe"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeTasaOpe"]);
                    oENSCTRCotizaciones.DetPorcentajeTasaPensionOpe = oDataReader["DetPorcentajeTasaPensionOpe"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeTasaPensionOpe"]);
                    oENSCTRCotizaciones.DetPorcentajeCorredorPensionOpe = oDataReader["DetPorcentajeCorredorPensionOpe"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeCorredorPensionOpe"]);
                    //Detalle Administrativos

                    oENSCTRCotizaciones.DetCodigoCotizacionAdm = oDataReader["DetCodigoCotizacionAdm"].ToString();
                    oENSCTRCotizaciones.DetCodigoTipoEmpleadoAdm = oDataReader["DetCodigoTipoEmpleadoAdm"].ToString();
                    oENSCTRCotizaciones.DetImporteDerechoEmisionAdm = oDataReader["DetImporteDerechoEmisionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImporteDerechoEmisionAdm"]);
                    oENSCTRCotizaciones.DetImporteDerechoEmisionPensionAdm = oDataReader["DetImporteDerechoEmisionPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImporteDerechoEmisionPensionAdm"]);
                    oENSCTRCotizaciones.DetImporteIGVAdm = oDataReader["DetImporteIGVAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImporteIGVAdm"]);
                    oENSCTRCotizaciones.DetImporteIGVPensionAdm = oDataReader["DetImporteIGVPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImporteIGVPensionAdm"]);
                    oENSCTRCotizaciones.DetImportePrimaNetaAdm = oDataReader["DetImportePrimaNetaAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImportePrimaNetaAdm"]);
                    oENSCTRCotizaciones.DetImportePrimaNetaPensionAdm = oDataReader["DetImportePrimaNetaPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImportePrimaNetaPensionAdm"]);
                    oENSCTRCotizaciones.DetImportePrimaTotalAdm = oDataReader["DetImportePrimaTotalAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImportePrimaTotalAdm"]);
                    oENSCTRCotizaciones.DetImportePrimaTotalPensionAdm = oDataReader["DetImportePrimaTotalPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetImportePrimaTotalPensionAdm"]);
                    oENSCTRCotizaciones.DetItemAdm = oDataReader["DetItemAdm"].ToString();
                    oENSCTRCotizaciones.DetMontoPlanillaAdm = oDataReader["DetMontoPlanillaAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetMontoPlanillaAdm"].ToString());
                    oENSCTRCotizaciones.DetNumeroTrabajadoresAdm = oDataReader["DetNumeroTrabajadoresAdm"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["DetNumeroTrabajadoresAdm"]);
                    oENSCTRCotizaciones.DetPorcentajeCorredorAdm = oDataReader["DetPorcentajeCorredorAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeCorredorAdm"]);
                    oENSCTRCotizaciones.DetPorcentajeTasaAdm = oDataReader["DetPorcentajeTasaAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeTasaAdm"]);
                    oENSCTRCotizaciones.DetPorcentajeTasaPensionAdm = oDataReader["DetPorcentajeTasaPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeTasaPensionAdm"]);
                    oENSCTRCotizaciones.DetPorcentajeCorredorPensionAdm = oDataReader["DetPorcentajeCorredorPensionAdm"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["DetPorcentajeCorredorPensionAdm"]);
                    //Nuevos
                    oENSCTRCotizaciones.Direccion= oDataReader["Direccion"].ToString();
                    oENSCTRCotizaciones.Ubigeo = oDataReader["Ubigeo"].ToString();
                    oENSCTRCotizaciones.UbigeoRiesgo = oDataReader["UbigeoRiesgo"].ToString();
                    oENSCTRCotizaciones.CodigoDpto = oDataReader["CodDpto"].ToString();
                    oENSCTRCotizaciones.CodigoProv = oDataReader["CodProv"].ToString();
                    oENSCTRCotizaciones.CodigoDist = oDataReader["CodDist"].ToString();
                    oENSCTRCotizaciones.CodigoDptoR = oDataReader["CodDptoR"].ToString();
                    oENSCTRCotizaciones.CodigoProvR = oDataReader["CodProvR"].ToString();
                    oENSCTRCotizaciones.CodigoDistR = oDataReader["CodDistR"].ToString();

                    oENSCTRCotizaciones.ImportePrimaNeta = oDataReader["ImportePrimaNeta"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImportePrimaNeta"]);
                    oENSCTRCotizaciones.ImporteIGV = oDataReader["ImporteIGV"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImporteIGV"]);
                    oENSCTRCotizaciones.ImportePrimaTotal = oDataReader["ImportePrimaTotal"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImportePrimaTotal"]);
                    oENSCTRCotizaciones.ImporteDerechoEmision = oDataReader["ImporteDerechoEmision"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImporteDerechoEmision"]);

                    oENSCTRCotizaciones.ImportePrimaNetaPension = oDataReader["ImportePrimaNetaPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImportePrimaNetaPension"]);
                    oENSCTRCotizaciones.ImporteIGVPension = oDataReader["ImporteIGVPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImporteIGVPension"]);
                    oENSCTRCotizaciones.ImportePrimaTotalPension = oDataReader["ImportePrimaTotalPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImportePrimaTotalPension"]);
                    oENSCTRCotizaciones.ImporteDerechoEmisionPension = oDataReader["ImporteDerechoEmisionPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ImporteDerechoEmisionPension"]);

                    oENSCTRCotizaciones.PorcentajeTasaPension = oDataReader["PorcentajeTasaPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["PorcentajeTasaPension"]);
                    oENSCTRCotizaciones.PorcentajeCorredorPension = oDataReader["PorcentajeCorredorPension"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["PorcentajeCorredorPension"]);

                    oENSCTRCotizaciones.PorcentajeTasa = oDataReader["PorcentajeTasa"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["PorcentajeTasa"]);
                    oENSCTRCotizaciones.PorcentajeCorredor = oDataReader["PorcentajeCorredor"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["PorcentajeCorredor"]);

                    oENSCTRCotizaciones.dtm_FechaInicio = DateTime.Parse(oDataReader["FechaInicio"].ToString()); 
                    oENSCTRCotizaciones.dtm_FechaFin = DateTime.Parse(oDataReader["FechaFin"].ToString());

                }
                return oENSCTRCotizaciones;
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

        public ENSCTRCotizaciones Cotizar(ENSCTRCotizaciones oENSCTRCotizaciones)
        {
            DbCommand oCommand = null;
            List<ENSCTRCotizaciones> oListaSCTRCotizaciones = new List<ENSCTRCotizaciones>();
            List<ENSCTRCotizacionesDetalle > oListaSCTRCotizacionesDetalle = new List<ENSCTRCotizacionesDetalle>();
            try
            {
                string sTipoProceso = "C";
                double iPorcentajeTasa = 0;
                double iPorcentajeCorredor = 0;
                double iPorcentajeTasaAdm = 0;
                double iPorcentajeCorredorAdm = 0;
                double iPorcentajeTasaOpe = 0;
                double iPorcentajeCorredorOpe = 0;
                double iImportePrimaNeta = 0;
                double iImporteDerechoEmision = 0;
                double iImporteIGV = 0;
                double iImportePrimaTotal = 0;
                string sCodigoUsuario = "grojas";
                string sCodigoCorredor = "J6969";

                string sUbigeoRiesgo = "";
                string sFechaInicio = "";
                string sFechaFin = "";
                string sFechaCotizacion = "";
                string sCodigoMoneda = "";
                string sProcesoResultado = "";
                string sProcesoMensaje = "";
                string sFlagExcepcion = "";

                sFechaInicio = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaInicio);
                sFechaFin = String.Format("{0:yyyyMMdd}", oENSCTRCotizaciones.dtm_FechaFin);
    
                if (oENSCTRCotizaciones.UbigeoRiesgo  is  null)
                {sUbigeoRiesgo = oENSCTRCotizaciones.CodigoDptoR + oENSCTRCotizaciones.CodigoProvR + oENSCTRCotizaciones.CodigoDistR;
                }
                else
                { sUbigeoRiesgo = oENSCTRCotizaciones.UbigeoRiesgo;
                }
                if (oENSCTRCotizaciones.PorcentajeCorredor != 0)
                { iPorcentajeCorredor = oENSCTRCotizaciones.PorcentajeCorredor;}
                else
                { iPorcentajeCorredor = 100;}
 
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_PerCotizacionConsulta");
                //ENSCTRCotizaciones oEnListaSCTRCotizaciones = new ENSCTRCotizaciones();
                GenericDataAccess.AgregarParametro(oCommand, "@TipoProceso", sTipoProceso, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@EmpresaRUC", oENSCTRCotizaciones.EmpresaRUC, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@EmpresaNombre", oENSCTRCotizaciones.EmpresaNombre, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCorredor", sCodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCIIU", oENSCTRCotizaciones.CodigoCIIU, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@MontoOperativos", oENSCTRCotizaciones.DetMontoPlanillaOpe, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroOperativos", oENSCTRCotizaciones.DetNumeroTrabajadoresOpe, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@MontoAdministrativos", oENSCTRCotizaciones.DetMontoPlanillaAdm, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroAdministrativos", oENSCTRCotizaciones.DetNumeroTrabajadoresAdm, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoMoneda", oENSCTRCotizaciones.CodigoMoneda, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaInicio", sFechaInicio, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaFin", sFechaFin, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TiempoCobertura", oENSCTRCotizaciones.TiempoCobertura, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeTasa", iPorcentajeTasa, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PorcentajeCorredor", iPorcentajeCorredor, TipoParametro.DBL, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NumeroCotizacion", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Usuario", sCodigoUsuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@UbigeoRiesgo", sUbigeoRiesgo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Origen", oENSCTRCotizaciones.Origen, TipoParametro.STR, Direccion.INPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                ENSCTRCotizacionesDetalle oEnListaSCTRCotizaciones1 = new ENSCTRCotizacionesDetalle();

                if (oDataReader.HasRows)
                { 
                    while (oDataReader.Read())
                 {
                        oEnListaSCTRCotizaciones1.CodigoTipoEmpleado = oDataReader["CodigoTipoAsegurado"].ToString();
                        oEnListaSCTRCotizaciones1.ImportePrimaNeta = Convert.ToDouble(oDataReader["ImportePrimaNeta"]);
                        oEnListaSCTRCotizaciones1.ImporteDerechoEmision = Convert.ToDouble(oDataReader["ImporteDerechoEmision"]);
                        oEnListaSCTRCotizaciones1.ImporteIGV = Convert.ToDouble(oDataReader["ImporteIGV"]);
                        oEnListaSCTRCotizaciones1.ImportePrimaTotal = Convert.ToDouble(oDataReader["ImportePrimaTotal"]);
                        oEnListaSCTRCotizaciones1.CodigoCotizacion = oDataReader["CodigoTipoAsegurado"].ToString();
                        sFechaCotizacion = oDataReader["FechaCotizacion"].ToString();
                        sCodigoMoneda = oDataReader["CodigoMoneda"].ToString();
                        oEnListaSCTRCotizaciones1.PorcentajeTasa = Convert.ToDouble(oDataReader["PorcentajeTasa"]);
                        oEnListaSCTRCotizaciones1.PorcentajeCorredor = Convert.ToDouble(oDataReader["PorcentajeCorredor"]);
                        sProcesoResultado = oDataReader["ProcesoResultado"].ToString();
                        sProcesoMensaje = oDataReader["ProcesoMensaje"].ToString();
                        sFlagExcepcion = oDataReader["FlagExcepcion"].ToString();

                        iImportePrimaNeta = iImportePrimaNeta + oEnListaSCTRCotizaciones1.ImportePrimaNeta;
                        iImporteDerechoEmision = iImporteDerechoEmision + oEnListaSCTRCotizaciones1.ImporteDerechoEmision; ;
                        iImporteIGV = iImporteIGV + oEnListaSCTRCotizaciones1.ImporteIGV;
                        iImportePrimaTotal = iImportePrimaTotal + oEnListaSCTRCotizaciones1.ImportePrimaTotal;

                        if (oEnListaSCTRCotizaciones1.CodigoTipoEmpleado != "2")
                        {
                            iPorcentajeTasaAdm = oEnListaSCTRCotizaciones1.PorcentajeTasa;
                            iPorcentajeCorredorAdm = oEnListaSCTRCotizaciones1.PorcentajeCorredor;
                        }
                        else
                        {
                            iPorcentajeTasaOpe = oEnListaSCTRCotizaciones1.PorcentajeTasa;
                            iPorcentajeCorredorOpe = oEnListaSCTRCotizaciones1.PorcentajeCorredor;
                        }
                        oListaSCTRCotizacionesDetalle.Add(oEnListaSCTRCotizaciones1);
                    }
                }
                oENSCTRCotizaciones.ImportePrimaNeta = iImportePrimaNeta;
                oENSCTRCotizaciones.ImporteIGV = iImporteIGV;
                oENSCTRCotizaciones.ImportePrimaTotal = iImportePrimaTotal;
                oENSCTRCotizaciones.ImporteDerechoEmision = iImporteDerechoEmision;
                oENSCTRCotizaciones.PorcentajeCorredor = iPorcentajeCorredorAdm;
                oENSCTRCotizaciones.PorcentajeTasa = iPorcentajeTasaAdm;


                return oENSCTRCotizaciones;
               // return oListaSCTRCotizacionesDetalle;
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
