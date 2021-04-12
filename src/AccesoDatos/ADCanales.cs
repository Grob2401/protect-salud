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
    public class ADCanales
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        
        public List<ENCanales> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENCanales> oListaCanales = new List<ENCanales>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCanales oEnListaCanales = new ENCanales();
                    oEnListaCanales.DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oEnListaCanales.IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oEnListaCanales.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
                    oEnListaCanales.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaCanales.RazonSocial = oDataReader["RazonSocial"].ToString();

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

        public ENCanales ObtenerUno(int id)
        {
            DbCommand oCommand = null;
            ENCanales oENCanales = new ENCanales();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_Sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argIDCanal", id, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    //ENCanales oEnListaCanales = new ENCanales();
                    oENCanales.DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oENCanales.IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oENCanales.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
                    oENCanales.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oENCanales.RazonSocial = oDataReader["RazonSocial"].ToString();
                }
                return oENCanales;
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



        public bool Insertar(ENCanales oENCanal)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCanal", oENCanal.DescripcionCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDSociedad", oENCanal.IdSociedad, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }


        public bool Actualizar(ENCanales oENCanal)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argIDCanal", oENCanal.IDCanal, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCanal", oENCanal.DescripcionCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDSociedad", oENCanal.IdSociedad, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }


 
        public bool Eliminar(int IdCanal)
        {
            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argIdCanal", IdCanal, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }

    }

}
