using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADBanco
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;


        public List<ENBanco> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENBanco> oListaBancos = new List<ENBanco>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Bancos_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENBanco oEnListaBancos = new ENBanco();
                    oEnListaBancos.IDBanco = oDataReader["IDBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IDBanco"]);
                    oEnListaBancos.NombreBanco = oDataReader["NombreBanco"] == DBNull.Value ? "" : oDataReader["NombreBanco"].ToString();

                    oListaBancos.Add(oEnListaBancos);
                }
                return oListaBancos;
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

        public List<ENBanco> GenerarTexto(string banco, string lote)
        {
            DbCommand oCommand = null;
            List<ENBanco> oListaBancos = new List<ENBanco>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Cobranzas_Envio_Generacion_Textos");
                GenericDataAccess.AgregarParametro(oCommand, "@pcsIdBanco", banco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdLote", lote, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENBanco oEnListaBancos = new ENBanco();
                    oEnListaBancos.IDBanco = oDataReader["IDBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IDBanco"]);
                    oEnListaBancos.NombreBanco = oDataReader["NombreBanco"] == DBNull.Value ? "" : oDataReader["NombreBanco"].ToString();

                    oListaBancos.Add(oEnListaBancos);
                }
                return oListaBancos;
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

