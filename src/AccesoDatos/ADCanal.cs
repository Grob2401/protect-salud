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
    public class ADCanal
    {

        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENCanales> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENCanales> oListaCanales = new List<ENCanales>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_SEL_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad ", 1, TipoParametro.INT, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCanales oEnListaCanales = new ENCanales();
                    oEnListaCanales.IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oEnListaCanales.DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oListaCanales.Add(oEnListaCanales);
                }
                return oListaCanales;
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
