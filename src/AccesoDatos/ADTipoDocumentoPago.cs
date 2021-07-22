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
    public class ADTipoDocumentoPago
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENTipoDocumentoPago> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENTipoDocumentoPago> oListaDocumentosPago = new List<ENTipoDocumentoPago>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_TipoDocumentoPago_ObtenerTodos");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENTipoDocumentoPago oEnListaTipoDocumentoPago = new ENTipoDocumentoPago();
                    oEnListaTipoDocumentoPago.CodigoTipoDocumentoPago = oDataReader["CodigoTipoDocumentoPago"].ToString();
                    oEnListaTipoDocumentoPago.DescripcionTipoDocumentoPago = oDataReader["DescripcionTipoDocumentoPago"].ToString();
                    oListaDocumentosPago.Add(oEnListaTipoDocumentoPago);
                }
                return oListaDocumentosPago;
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
