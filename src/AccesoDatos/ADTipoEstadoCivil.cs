using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADTipoEstadoCivil
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENTipoEstadoCivil> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENTipoEstadoCivil> oListaTipoEstadoCivil = new List<ENTipoEstadoCivil>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenTipoEstadoCivil_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENTipoEstadoCivil oEnListaTipoEstadoCivil = new ENTipoEstadoCivil();
                    oEnListaTipoEstadoCivil.CodigoTipoEstadoCivil = oDataReader["CodigoTipoEstadoCivil"].ToString();
                    oEnListaTipoEstadoCivil.DescripcionTipoEstadoCivil = oDataReader["DescripcionTipoEstadoCivil"].ToString();

                    oListaTipoEstadoCivil.Add(oEnListaTipoEstadoCivil);
                }
                return oListaTipoEstadoCivil;
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
