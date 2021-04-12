using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSCTRCorredor
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSCTRCorredor> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSCTRCorredor> oListaSCTRCorredor = new List<ENSCTRCorredor>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCorredor_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSCTRCorredor oEnListaSCTRCorredor = new ENSCTRCorredor();
                    oEnListaSCTRCorredor.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oEnListaSCTRCorredor.DescripcionCorredor = oDataReader["DescripcionCorredor"].ToString();

                    oListaSCTRCorredor.Add(oEnListaSCTRCorredor);
                }
                return oListaSCTRCorredor;
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
        public ENSCTRCorredor ObtenerUno(string CodigoCorredor)
        {
            DbCommand oCommand = null;
            ENSCTRCorredor oENSCTRCorredor = new ENSCTRCorredor();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCorredor_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", oENSCTRCorredor.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSCTRCorredor.CodigoCorredor = oDataReader["CodigoCorredor"].ToString();
                    oENSCTRCorredor.DescripcionCorredor = oDataReader["DescripcionCorredor"].ToString();

                }
                return oENSCTRCorredor;
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

        public bool Insertar(ENSCTRCorredor oENSCTRCorredor)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCorredor_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", oENSCTRCorredor.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCorredor", oENSCTRCorredor.DescripcionCorredor, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Excepciones.ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }

        public bool Actualizar(ENSCTRCorredor oENSCTRCorredor)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCorredor_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", oENSCTRCorredor.CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCorredor", oENSCTRCorredor.DescripcionCorredor, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Excepciones.ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }

        public bool Eliminar(string CodigoCorredor)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTRCorredor_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCorredor", CodigoCorredor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Excepciones.ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null);
            }
        }
    }
}
