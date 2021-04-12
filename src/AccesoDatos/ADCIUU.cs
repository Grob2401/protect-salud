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
    public class ADCIUUPrincipal
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENCIIUPrincipal> ObtenerTodosPrincipal()
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENCIIUPrincipal> oLista = new List<ENCIIUPrincipal>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_CIIU_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argTipo", "1", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodGrupo", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCIIUPrincipal oENLista = new ENCIIUPrincipal();
                    oENLista.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENLista.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                    oLista.Add(oENLista);
                }
                return oLista;
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

        public ENCIIUPrincipal ObtenerPrincipalUno(string CodigoGrupoCIUU)
        {
            DbCommand oCommand = null;
            ENCIIUPrincipal oENCIIUPrincipal = new ENCIIUPrincipal();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argTipo", "1", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodGrupo", CodigoGrupoCIUU, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodCIIU", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENCIIUPrincipal.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENCIIUPrincipal.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                }
                return oENCIIUPrincipal;
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
    public class ADCIUUEspecifica
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENCIIUEspecifica> ObtenerTodosEspecifica(string codGrupo)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            List<ENCIIUEspecifica> oLista = new List<ENCIIUEspecifica>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_CIIU_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argTipo", "2", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodGrupo", codGrupo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCIIUEspecifica oENLista = new ENCIIUEspecifica();
                    oENLista.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENLista.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                    oLista.Add(oENLista);
                }
                return oLista;
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


        public ENCIIUEspecifica ObtenerEspecificaUno(string CodigoGrupoCIUU, string CodigoCIUU)

        {
            DbCommand oCommand = null;
            ENCIIUEspecifica oENCIIUEspecifica = new ENCIIUEspecifica();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_SCTR_Ubigeo_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argTipo", "2", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodGrupo", CodigoGrupoCIUU, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodCIIU", CodigoCIUU, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    oENCIIUEspecifica.CodigoCIIU = oDataReader["CodigoCIIU"].ToString();
                    oENCIIUEspecifica.DescripcionCIIU = oDataReader["DescripcionCIIU"].ToString();
                }
                return oENCIIUEspecifica;
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
