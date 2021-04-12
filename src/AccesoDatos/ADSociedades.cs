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
    public class ADSociedades
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENSociedades> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSociedades> oListaSociedades = new List<ENSociedades>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSociedades_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSociedades oEnListaSociedades = new ENSociedades();
                    oEnListaSociedades.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
                    oEnListaSociedades.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaSociedades.CodigoIAFAS = oDataReader["CodigoIAFAS"].ToString();
                    oEnListaSociedades.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oListaSociedades.Add(oEnListaSociedades);
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


        public ENSociedades ObtenerUno(int id)
        {
            DbCommand oCommand = null;
            //List<ENCanales> oListaCanales = new List<ENCanales>();
            ENSociedades oENSociedades = new ENSociedades();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSociedades_Sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argIDSociedad", id, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                //while (oDataReader.Read())
                if (oDataReader.Read())
                {
                    //ENCanales oEnListaCanales = new ENCanales();

                    oENSociedades.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
                    oENSociedades.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oENSociedades.CodigoIAFAS = oDataReader["CodigoIAFAS"].ToString();
                    oENSociedades.RazonSocial = oDataReader["RazonSocial"].ToString();
                    //oListaCanales.Add(oEnListaCanales);
                }
                //return oListaCanales;
                return oENSociedades;
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




        public bool Insertar(ENSociedades oENSociedad)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSociedades_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@IDPersona", oENSociedad.IdPersona, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoIAFAS", oENSociedad.CodigoIAFAS, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        public bool Actualizar(ENSociedades oENSociedad)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSociedades_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@IDSociedad", oENSociedad.IdSociedad, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoIAFAS", oENSociedad.CodigoIAFAS, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        public bool Eliminar(int IdSociedad)
        {
            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSociedades_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", IdSociedad, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }


    }
}
