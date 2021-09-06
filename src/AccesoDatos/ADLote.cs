using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADLote
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;


        public List<ENLote> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENLote> oListaLotes = new List<ENLote>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Cobranzas_Envio_Generacion_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@TipoEnvio ", "T", TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENLote oEnListaLotes = new ENLote();
                    oEnListaLotes.IdLote = oDataReader["IdLote"] == DBNull.Value ? "" : oDataReader["IdLote"].ToString();
                    oEnListaLotes.CodigoCliente = oDataReader["CodigoCliente"] == DBNull.Value ? "" : oDataReader["CodigoCliente"].ToString();
                    oEnListaLotes.CodigoContrato = oDataReader["CodigoContrato"] == DBNull.Value ? "" : oDataReader["CodigoContrato"].ToString();
                    oEnListaLotes.TitularCodigo = oDataReader["TitularCodigo"] == DBNull.Value ? "" : oDataReader["TitularCodigo"].ToString();
                    oEnListaLotes.TitularTipoDocumento = oDataReader["TitularTipoDocumento"] == DBNull.Value ? "" : oDataReader["TitularTipoDocumento"].ToString();
                    oEnListaLotes.TitularNumeroDocumento = oDataReader["TitularNumeroDocumento"] == DBNull.Value ? "" : oDataReader["TitularNumeroDocumento"].ToString();
                    oEnListaLotes.TitularNombre = oDataReader["TitularNombre"] == DBNull.Value ? "" : oDataReader["TitularNombre"].ToString();
                    oEnListaLotes.ClienteNombre = oDataReader["ClienteNombre"] == DBNull.Value ? "" : oDataReader["ClienteNombre"].ToString();
                    oEnListaLotes.ClienteTipoIdentificacion = oDataReader["ClienteTipoIdentificacion"] == DBNull.Value ? "" : oDataReader["ClienteTipoIdentificacion"].ToString();
                    oEnListaLotes.ClienteNumeroIdentificacion = oDataReader["ClienteNumeroIdentificacion"] == DBNull.Value ? "" : oDataReader["ClienteNumeroIdentificacion"].ToString();

                    oEnListaLotes.InicioVigencia = oDataReader["InicioVigencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["InicioVigencia"]);

                    oEnListaLotes.FinVigencia = oDataReader["FinVigencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FinVigencia"]);

                    oEnListaLotes.FechaCreacion = oDataReader["FechaCreacion"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaCreacion"]);

                    oEnListaLotes.FechaInicioCuota = oDataReader["FechaInicioCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaInicioCuota"]);

                    oEnListaLotes.FechaFinCuota = oDataReader["FechaFinCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaFinCuota"]);

                    oEnListaLotes.ValorPrima = oDataReader["ValorPrima"] == DBNull.Value ? 0 : Convert.ToDouble(oDataReader["ValorPrima"]);
                    oEnListaLotes.IdCuota = oDataReader["IdCuota"] == DBNull.Value ? "" : oDataReader["IdCuota"].ToString();
                    oEnListaLotes.IdCuotaOrden = oDataReader["IdCuotaOrden"] == DBNull.Value ? "" : oDataReader["IdCuotaOrden"].ToString();
                    oEnListaLotes.IdTransaccion = oDataReader["IdTransaccion"] == DBNull.Value ? "" : oDataReader["IdTransaccion"].ToString();
                    oEnListaLotes.LOGCREUSER = oDataReader["LOGCREUSER"] == DBNull.Value ? "" : oDataReader["LOGCREUSER"].ToString();
                    oEnListaLotes.Estado = oDataReader["Estado"] == DBNull.Value ? "" : oDataReader["Estado"].ToString();

                    oEnListaLotes.LOGCREDATE = oDataReader["LOGCREDATE"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["LOGCREDATE"]);

                    oListaLotes.Add(oEnListaLotes);
                }
                return oListaLotes;
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

        public List<ENLote> generarTexto(string banco, string lote)
        {
            DbCommand oCommand = null;
            List<ENLote> oListaLotes = new List<ENLote>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Cobranzas_Envio_Generacion_Textos");
                GenericDataAccess.AgregarParametro(oCommand, "@pcsIdBanco", banco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdLote ", lote, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENLote oEnListaLotes = new ENLote();
                    oEnListaLotes.RegDatos = oDataReader["RegDatos"] == DBNull.Value ? "" : oDataReader["RegDatos"].ToString();
                    oListaLotes.Add(oEnListaLotes);
                }
                return oListaLotes;
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

        public List<ENRuta> TraeValores(string banco)
        {
            DbCommand oCommand = null;
            List<ENRuta> oListaRutas = new List<ENRuta>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_CobranzasRutas");
                GenericDataAccess.AgregarParametro(oCommand, "@idBanco", banco, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENRuta oEnListaRutas = new ENRuta();
                    oEnListaRutas.RutaGeneradas = oDataReader["RutaGeneradas"] == DBNull.Value ? "" : oDataReader["RutaGeneradas"].ToString();
                    oEnListaRutas.RutaProcesadas = oDataReader["RutaProcesadas"] == DBNull.Value ? "" : oDataReader["RutaProcesadas"].ToString();
                    oEnListaRutas.RutaLog = oDataReader["RutaLog"] == DBNull.Value ? "" : oDataReader["RutaLog"].ToString();
                    oEnListaRutas.NombreArchivo = oDataReader["NombreArchivo"] == DBNull.Value ? "" : oDataReader["NombreArchivo"].ToString();
                    oEnListaRutas.StoreRetorno = oDataReader["StoreRetorno"] == DBNull.Value ? "" : oDataReader["StoreRetorno"].ToString();
                    oListaRutas.Add(oEnListaRutas);
                }
                return oListaRutas;
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

    }
}

