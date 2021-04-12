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
using Utilitarios;


namespace AccesoDatos
{

    public class ADSCTR_EmisionTemporal
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSCTR_EmisionTemporal> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSCTR_EmisionTemporal> oListaSCTR_EmisionTemporal = new List<ENSCTR_EmisionTemporal>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTR_EmisionTemporal_sel");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSCTR_EmisionTemporal oEnListaSCTR_EmisionTemporal = new ENSCTR_EmisionTemporal();
                    oEnListaSCTR_EmisionTemporal.C01 = oDataReader["C01"].ToString();
                    oEnListaSCTR_EmisionTemporal.C02 = oDataReader["C02"].ToString();
                    oEnListaSCTR_EmisionTemporal.C03 = oDataReader["C03"].ToString();
                    oEnListaSCTR_EmisionTemporal.C04 = oDataReader["C04"].ToString();
                    oEnListaSCTR_EmisionTemporal.C05 = oDataReader["C05"].ToString();
                    oEnListaSCTR_EmisionTemporal.C06 = oDataReader["C06"].ToString();
                    oEnListaSCTR_EmisionTemporal.C07 = oDataReader["C07"].ToString();
                    oEnListaSCTR_EmisionTemporal.C08 = oDataReader["C08"].ToString();
                    oEnListaSCTR_EmisionTemporal.C09 = oDataReader["C09"].ToString();
                    oEnListaSCTR_EmisionTemporal.C10 = oDataReader["C10"].ToString();
                    oEnListaSCTR_EmisionTemporal.C11 = oDataReader["C11"].ToString();
                    oEnListaSCTR_EmisionTemporal.C12 = oDataReader["C12"].ToString();
                    oEnListaSCTR_EmisionTemporal.C13 = oDataReader["C13"].ToString();
                    oEnListaSCTR_EmisionTemporal.C14 = oDataReader["C14"].ToString();
                    oEnListaSCTR_EmisionTemporal.C15 = oDataReader["C15"].ToString();
                    oEnListaSCTR_EmisionTemporal.C16 = oDataReader["C16"].ToString();
                    oEnListaSCTR_EmisionTemporal.ID = Convert.ToInt32(oDataReader["ID"]);
                    oEnListaSCTR_EmisionTemporal.IDGrupo = oDataReader["IDGrupo"].ToString();
                    oEnListaSCTR_EmisionTemporal.NumeroCotizacion = oDataReader["NumeroCotizacion"].ToString();
                    oListaSCTR_EmisionTemporal.Add(oEnListaSCTR_EmisionTemporal);
                }
                return oListaSCTR_EmisionTemporal;
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


        public bool Insertar(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {

            DbCommand oCommand = null;
            List<ENDatosError> oListaError = new List<ENDatosError>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTR_EmisionTemporal_ins");
                 GenericDataAccess.AgregarParametro(oCommand, "@argC02", oENSCTR_EmisionTemporal.C02, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC03", oENSCTR_EmisionTemporal.C03, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC04", oENSCTR_EmisionTemporal.C04, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC05", oENSCTR_EmisionTemporal.C05, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC06", oENSCTR_EmisionTemporal.C06, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC07", oENSCTR_EmisionTemporal.C07, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC08", oENSCTR_EmisionTemporal.C08, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC09", oENSCTR_EmisionTemporal.C09, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC10", oENSCTR_EmisionTemporal.C10, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC11", oENSCTR_EmisionTemporal.C11, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC12", oENSCTR_EmisionTemporal.C12, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC13", oENSCTR_EmisionTemporal.C13, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC14", oENSCTR_EmisionTemporal.C14, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC15", oENSCTR_EmisionTemporal.C15, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC16", oENSCTR_EmisionTemporal.C16, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argID", oENSCTR_EmisionTemporal.ID, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDGrupo", oENSCTR_EmisionTemporal.IDGrupo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNumeroCotizacion", oENSCTR_EmisionTemporal.NumeroCotizacion, TipoParametro.STR, Direccion.INPUT);
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

        //public List<ENDatosError> SCTREmisionIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        //{
        //    DbCommand oCommand = null;
        //    List<ENDatosError> oListaError = new List<ENDatosError>();
        //    try
        //    {
        //        oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "ws_Ctz_PerCotizacionEmitirIndividual");
        //        GenericDataAccess.AgregarParametro(oCommand, "@NumeroCotizacion", oENSCTR_EmisionTemporal.NumeroCotizacion, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C01", oENSCTR_EmisionTemporal.C01, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C02", oENSCTR_EmisionTemporal.C02, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C03", oENSCTR_EmisionTemporal.C03, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C04", oENSCTR_EmisionTemporal.C04, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C05", oENSCTR_EmisionTemporal.C05, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C06", oENSCTR_EmisionTemporal.C06, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C07", oENSCTR_EmisionTemporal.C07, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C08", oENSCTR_EmisionTemporal.C08, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C09", oENSCTR_EmisionTemporal.C09, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C10", oENSCTR_EmisionTemporal.C10, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C11", oENSCTR_EmisionTemporal.C11, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C12", oENSCTR_EmisionTemporal.C12, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C13", oENSCTR_EmisionTemporal.C13, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C14", oENSCTR_EmisionTemporal.C14, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C15", oENSCTR_EmisionTemporal.C15, TipoParametro.STR, Direccion.INPUT);
        //        //GenericDataAccess.AgregarParametro(oCommand, "@C16", oENSCTR_EmisionTemporal.C16, TipoParametro.STR, Direccion.INPUT);

        //        DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
        //        //DataTable schemaTable = oDataReader.GetSchemaTable();
        //        //foreach (DataRow row in schemaTable.Rows)
        //        //{
        //        //    foreach (DataColumn column in schemaTable.Columns)
        //        //    {
        //        //        Console.WriteLine(String.Format("{0} = {1}",
        //        //           column.ColumnName, row[column]));
        //        //    }
        //        //}

        //        //ENDatosError oEnListaDatosError = new ENDatosError();
        //        //while (oDataReader.Read())
        //        //{

        //        //    int v_Resultado = 0;
        //        //    v_Resultado = Convert.ToInt32(oDataReader["Resultado"]);
        //        //    //oEnListaDatosError.CodigoError = Convert.ToInt32(oDataReader["ProcesoResultado"]);
        //        //    //oEnListaDatosError.DescripcionError = oDataReader["ProcesoMensaje"].ToString();
        //        //    //oListaError.Add(oEnListaDatosError);

        //        //    if (oDataReader.NextResult())
        //        //    {
        //        //        while (oDataReader.Read())
        //        //        {

        //        //            //v2 = oDataReader["ProcesoMensaje"];

        //        //            oEnListaDatosError.CodigoError = Convert.ToInt32(oDataReader["ProcesoResultado"]);
        //        //            oEnListaDatosError.DescripcionError = oDataReader["ProcesoMensaje"].ToString();
        //        //            oListaError.Add(oEnListaDatosError);
        //        //        }
        //        //    }
        //        //}
        //        return oListaError;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new MyExcepcion(ex.Message);
        //    }
        //    //finally
        //    //{
        //    //    GenericDataAccess.CerrarConexion(oCommand, null);
        //    //}
        //}


        public bool Actualizar(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSCTR_EmisionTemporal_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argC01", oENSCTR_EmisionTemporal.C01, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC02", oENSCTR_EmisionTemporal.C02, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC03", oENSCTR_EmisionTemporal.C03, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC04", oENSCTR_EmisionTemporal.C04, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC05", oENSCTR_EmisionTemporal.C05, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC06", oENSCTR_EmisionTemporal.C06, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC07", oENSCTR_EmisionTemporal.C07, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC08", oENSCTR_EmisionTemporal.C08, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC09", oENSCTR_EmisionTemporal.C09, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC10", oENSCTR_EmisionTemporal.C10, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC11", oENSCTR_EmisionTemporal.C11, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC12", oENSCTR_EmisionTemporal.C12, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC13", oENSCTR_EmisionTemporal.C13, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC14", oENSCTR_EmisionTemporal.C14, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC15", oENSCTR_EmisionTemporal.C15, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argC16", oENSCTR_EmisionTemporal.C16, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argID", oENSCTR_EmisionTemporal.ID, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDGrupo", oENSCTR_EmisionTemporal.IDGrupo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNumeroCotizacion", oENSCTR_EmisionTemporal.NumeroCotizacion, TipoParametro.STR, Direccion.INPUT);

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


