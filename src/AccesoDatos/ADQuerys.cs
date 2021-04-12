using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using System.Configuration;
using System.Globalization;

namespace AccesoDatos
{
    public class ADSaludPlanesConsulta
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENSaludPlanesConsulta> ObtenerTodos()
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENSaludPlanesConsulta> oListaSaludPlanesConsulta = new List<ENSaludPlanesConsulta>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_TipoPlan_ObtenerTodos");
                GenericDataAccess.AgregarParametro(oCommand, "@ErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludPlanesConsulta oEnListaSaludPlanesConsulta = new ENSaludPlanesConsulta();
                    oEnListaSaludPlanesConsulta.CodigoPlan = oDataReader["IdTipoPlan"].ToString();
                    oEnListaSaludPlanesConsulta.DescripcionPlan = oDataReader["DescripcionTipo"].ToString();
                    oEnListaSaludPlanesConsulta.InicioVigencia = DateTime.Parse(oDataReader["InicioVigencia"].ToString());
                    oEnListaSaludPlanesConsulta.FinVigencia = DateTime.Parse(oDataReader["FinVigencia"].ToString());

                    oListaSaludPlanesConsulta.Add(oEnListaSaludPlanesConsulta);
                }
                return oListaSaludPlanesConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
    }
}
