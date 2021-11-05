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
    public class ADMotivoBaja
    {

        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENMotivoBaja> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENMotivoBaja> oListaMotivos = new List<ENMotivoBaja>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_MotivoBaja_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENMotivoBaja oEnListaMotivoBaja = new ENMotivoBaja();
                    oEnListaMotivoBaja.CodigoMotivoBaja = oDataReader["CodigoMotivoBaja"].ToString();
                    oEnListaMotivoBaja.Descripcion = oDataReader["Descripcion"].ToString();
                    oListaMotivos.Add(oEnListaMotivoBaja);

    }
                return oListaMotivos;
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
