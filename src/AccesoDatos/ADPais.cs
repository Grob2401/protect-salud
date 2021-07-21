using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{

    public class ADPais
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENTipoPais> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENTipoPais> oListaSaludAsegurados = new List<ENTipoPais>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_Paises_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENTipoPais oEnListaSaludAsegurados = new ENTipoPais();
                    oEnListaSaludAsegurados.CodigoTipoPais = oDataReader["CodigoTipoPais"].ToString();
                    oEnListaSaludAsegurados.DescripcionTipoPais = oDataReader["DescripcionTipoPais"].ToString();

                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
                }
                return oListaSaludAsegurados;
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
