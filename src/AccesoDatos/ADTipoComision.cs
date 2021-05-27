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
    public class ADTipoComision
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENTipoComision> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENTipoComision> oListaSociedades = new List<ENTipoComision>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_MA_TIPOCOMISIONES");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENTipoComision oEnListaTipoComision = new ENTipoComision();
                    oEnListaTipoComision.IdTipoComision = Convert.ToInt32(oDataReader["IdTipoComision"]);
                    oEnListaTipoComision.DescripcionTipoComision = oDataReader["DescripcionTipoComision"].ToString();
                    oListaSociedades.Add(oEnListaTipoComision);
                }
                return oListaSociedades;
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
