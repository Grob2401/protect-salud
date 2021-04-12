using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludParentesco
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludParentesco> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSaludParentesco> oListaSaludParentesco = new List<ENSaludParentesco>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludParentesco_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludParentesco oEnListaSaludParentesco = new ENSaludParentesco();
                    oEnListaSaludParentesco.CodigoCategoria = oDataReader["CodigoCategoria"].ToString();
                    oEnListaSaludParentesco.CodigoParentesco = oDataReader["CodigoParentesco"].ToString();
                    oEnListaSaludParentesco.DescripcionParentesco = oDataReader["DescripcionParentesco"].ToString();

                    oListaSaludParentesco.Add(oEnListaSaludParentesco);
                }
                return oListaSaludParentesco;
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
        public ENSaludParentesco ObtenerUno(string CodigoParentesco)
        {
            DbCommand oCommand = null;
            ENSaludParentesco oENSaludParentesco = new ENSaludParentesco();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludParentesco_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoParentesco", oENSaludParentesco.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);

                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludParentesco.CodigoCategoria = oDataReader["CodigoCategoria"].ToString();
                    oENSaludParentesco.CodigoParentesco = oDataReader["CodigoParentesco"].ToString();
                    oENSaludParentesco.DescripcionParentesco = oDataReader["DescripcionParentesco"].ToString();

                }
                return oENSaludParentesco;
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

        public bool Insertar(ENSaludParentesco oENSaludParentesco)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludParentesco_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCategoria", oENSaludParentesco.CodigoCategoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoParentesco", oENSaludParentesco.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionParentesco", oENSaludParentesco.DescripcionParentesco, TipoParametro.STR, Direccion.INPUT);
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

        public bool Actualizar(ENSaludParentesco oENSaludParentesco)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludParentesco_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCategoria", oENSaludParentesco.CodigoCategoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoParentesco", oENSaludParentesco.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionParentesco", oENSaludParentesco.DescripcionParentesco, TipoParametro.STR, Direccion.INPUT);

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

        public bool Eliminar(string CodigoParentesco)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludParentesco_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoParentesco", CodigoParentesco, TipoParametro.STR, Direccion.INPUT);

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
