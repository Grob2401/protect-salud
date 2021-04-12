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
    public class ADUbigeoDpto
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENUbigeoDpto> ObtenerDpto()
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENUbigeoDpto> oListaDpto = new List<ENUbigeoDpto>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENUbigeoDpto oENListaDpto = new ENUbigeoDpto();
                    oENListaDpto.CodigoDpto = oDataReader["Coddpto"].ToString();
                    oENListaDpto.DescripcionDpto = oDataReader["Nombre"].ToString();
                    oListaDpto.Add(oENListaDpto);
                }
                return oListaDpto;
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

        public ENUbigeoDpto ObtenerDptoUno(string CodigoDpto)
        {
            DbCommand oCommand = null;
            ENUbigeoDpto oENUbigeoDpto = new ENUbigeoDpto();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", CodigoDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDist", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENUbigeoDpto.CodigoDpto = oDataReader["CodigoDpto"].ToString();
                    oENUbigeoDpto.DescripcionDpto = oDataReader["Nombre"].ToString();
                }
                return oENUbigeoDpto;
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
    public class ADUbigeoProv
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENUbigeoProv> ObtenerProv(string codDpto)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENUbigeoProv> oListaProv = new List<ENUbigeoProv>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", codDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENUbigeoProv oENListaProv = new ENUbigeoProv();
                    oENListaProv.CodigoProv = oDataReader["CodProv"].ToString();
                    oENListaProv.DescripcionProv = oDataReader["Nombre"].ToString();
                    oListaProv.Add(oENListaProv);
                }
                return oListaProv;
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

        public ENUbigeoProv ObtenerProvUno(string CodigoDpto,string CodigoProv)
        {
            DbCommand oCommand = null;
            ENUbigeoProv oENUbigeoProv = new ENUbigeoProv();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", CodigoDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", CodigoProv, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDist", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENUbigeoProv.CodigoProv = oDataReader["CodigoProv"].ToString();
                    oENUbigeoProv.DescripcionProv = oDataReader["Nombre"].ToString();
                }
                return oENUbigeoProv;
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
    public class ADUbigeoDist
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENUbigeoDist> ObtenerDist(string codDpto,string codProv)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENUbigeoDist> oListaDist = new List<ENUbigeoDist>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", codDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", codProv, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENUbigeoDist oENListaDist = new ENUbigeoDist();
                    oENListaDist.CodigoDist = oDataReader["CodDist"].ToString();
                    oENListaDist.DescripcionDist = oDataReader["Nombre"].ToString();
                    oListaDist.Add(oENListaDist);
                }
                return oListaDist;
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

        public ENUbigeoDist ObtenerDistUno(string CodigoDpto, string CodigoProv, string CodigoDist)
        {
            DbCommand oCommand = null;
            ENUbigeoDist oENUbigeoDist = new ENUbigeoDist();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", CodigoDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", CodigoProv, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDist", CodigoDist, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENUbigeoDist.CodigoDist = oDataReader["CodigoDist"].ToString();
                    oENUbigeoDist.DescripcionDist = oDataReader["Nombre"].ToString();
                }
                return oENUbigeoDist;
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

    public class ADUbigeoCompleto
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public ENUbigeoCompleto ObtenerCompletoUno(string CodigoDpto, string CodigoProv, string CodigoDist)
        {
            DbCommand oCommand = null;
            ENUbigeoCompleto oENUbigeoCompleto = new ENUbigeoCompleto();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno_completo");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDpto", CodigoDpto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodProv", CodigoProv, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodDist", CodigoDist, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENUbigeoCompleto.CodigoDpto = oDataReader["CodigoDpto"].ToString();
                    oENUbigeoCompleto.DescripcionProv = oDataReader["Nombre"].ToString();
                    oENUbigeoCompleto.CodigoProv = oDataReader["CodigoProv"].ToString();
                    oENUbigeoCompleto.DescripcionProv = oDataReader["Nombre"].ToString();
                    oENUbigeoCompleto.CodigoDist = oDataReader["CodigoDist"].ToString();
                    oENUbigeoCompleto.DescripcionDist = oDataReader["Nombre"].ToString();
                }
                return oENUbigeoCompleto;
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
