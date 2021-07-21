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
    public class ADTipoPrima
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENTipoPrima> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENTipoPrima> oListaPrimas = new List<ENTipoPrima>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_TipoPrima_ObtenerTodos");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENTipoPrima oEnListaTipoPrima = new ENTipoPrima();
                    oEnListaTipoPrima.CodigoTipoPrima = oDataReader["CodigoTipoPrima"].ToString();
                    oEnListaTipoPrima.DescripcionTipoPrima = oDataReader["DescripcionTipoPrima"].ToString();
                    oListaPrimas.Add(oEnListaTipoPrima);
                }
                return oListaPrimas;
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
