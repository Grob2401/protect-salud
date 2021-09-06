using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADMarcaTarjeta
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENMarcaTarjeta> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENMarcaTarjeta> oListaMarcaTarjetas = new List<ENMarcaTarjeta>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_MarcaTarjetas_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENMarcaTarjeta oEnListaMarcaTarjeta = new ENMarcaTarjeta();
                    oEnListaMarcaTarjeta.CodigoMarcaTarjeta = oDataReader["CodigoMarcaTarjeta"].ToString();
                    oEnListaMarcaTarjeta.DescripcionMarcaTarjeta = oDataReader["DescripcionMarcaTarjeta"].ToString();
                    oListaMarcaTarjetas.Add(oEnListaMarcaTarjeta);
                }
                return oListaMarcaTarjetas;
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
