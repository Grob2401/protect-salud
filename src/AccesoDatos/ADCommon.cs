using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Entidades;
using Excepciones;
using System.Configuration;
using System.Globalization;
using Utilitarios;
using System.Dynamic;

namespace AccesoDatos
{
    public class ADCommon
    {

        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;


        public DataSet SCTREmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            SqlConnection CnDatos = new SqlConnection(connectionString);
            DataSet DSTmp;
            CnDatos.Open();
            List<ENDatosError> oListaError = new List<ENDatosError>();
           
            try
            {

                if (CnDatos.State == ConnectionState.Open)
                {
                    SqlDataAdapter DATmp = new SqlDataAdapter("ws_Ctz_PerCotizacionEmitirIndividual", CnDatos);
                    DATmp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@NumeroCotizacion", SqlDbType.VarChar, 50, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.NumeroCotizacion));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C01", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C01));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C02", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C02));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C03", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C03));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C04", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C04));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C05", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C05));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C06", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C06));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C07", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C07));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C08", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C08));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C09", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C09));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C10", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C10));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C11", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C11));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C12", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C12));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C13", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C13));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C14", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C14));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C15", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C15));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C16", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C16));
                    DSTmp = new DataSet();
                    DATmp.Fill(DSTmp);
                    CnDatos.Close();
                    DATmp = null;
                    CnDatos = null;
                    return DSTmp;
                }
                else
                {
                    DSTmp = null/* TODO Change to default(_) if this is not a reference type */;
                    CnDatos.Close();
                    CnDatos = null/* TODO Change to default(_) if this is not a reference type */;
                    return DSTmp;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                DSTmp = null;
                return DSTmp;
            }
            finally
            {
                CnDatos.Close();
            }

        }


        public List<ENDatosError> ListaSCTREmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            SqlConnection CnDatos = new SqlConnection(connectionString);
            DataSet DSTmp;
            CnDatos.Open();
            List<ENDatosError> oListaError = new List<ENDatosError>();
            DataTable dtResultado0 = new DataTable();
            DataTable dtResultado1 = new DataTable();
            DataTable dtResultado2 = new DataTable();
            string sProcesoResultado = "";
            string sProcesoMensaje = "";
            try
            {
                if (CnDatos.State == ConnectionState.Open)
                {
                    SqlDataAdapter DATmp = new SqlDataAdapter("ws_Ctz_PerCotizacionEmitirIndividual", CnDatos);
                    DATmp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@NumeroCotizacion", SqlDbType.VarChar, 50, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.NumeroCotizacion));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C01", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C01));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C02", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C02));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C03", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C03));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C04", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C04));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C05", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C05));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C06", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C06));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C07", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C07));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C08", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C08));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C09", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C09));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C10", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C10));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C11", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C11));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C12", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C12));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C13", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C13));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C14", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C14));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C15", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C15));
                    DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C16", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C16));
                    DSTmp = new DataSet();
                    DATmp.Fill(DSTmp);
                    dtResultado0 = DSTmp.Tables[0];
                    dtResultado1 = DSTmp.Tables[1];
                    dtResultado2 = DSTmp.Tables[2];
                    // El store de Emisión Invoca otra store de Afiliación que puede producir errores
                    if (dtResultado0.Rows.Count!=0)
                    {
                        if (dtResultado0.Rows[0][0].ToString() == "-1" ) // Error en store de Afiliación , se toma los valores de error de ese store
                        {
                            sProcesoResultado = dtResultado1.Rows[0][0].ToString(); 
                            sProcesoMensaje = dtResultado1.Rows[0][1].ToString();
                        }
                        else // Sino se valida el segundo datatable 
                        {
                            if (dtResultado1.Rows[0][0].ToString() == "1") // Si no hay error , se toma los códigos de Error de Emisión (dtResultado2)
                            {
                                sProcesoResultado = dtResultado2.Rows[0][0].ToString();
                                sProcesoMensaje = dtResultado2.Rows[0][1].ToString();
                            }
                            else // error de store de Afiliación
                            {
                                sProcesoResultado = dtResultado1.Rows[0][0].ToString();
                                sProcesoMensaje = dtResultado1.Rows[0][1].ToString();
                            }
                        }
                    }
                    ENDatosError oEnListaDatosError = new ENDatosError();
                    oEnListaDatosError.CodigoError= Convert.ToInt32(sProcesoResultado);
                    oEnListaDatosError.DescripcionError = sProcesoMensaje;
                    oListaError.Add(oEnListaDatosError);
                    CnDatos.Close();
                    DATmp = null;
                    CnDatos = null;
                    return oListaError;
                }
                else
                {
                    DSTmp = null/* TODO Change to default(_) if this is not a reference type */;
                    CnDatos.Close();
                    CnDatos = null/* TODO Change to default(_) if this is not a reference type */;
                    return oListaError;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                DSTmp = null;
                CnDatos.Close();
                return oListaError;
            }
        }




        public DataSet ObtieneDataSet(String pStore,Array[] StrParam)
        {
            SqlConnection CnDatos = new SqlConnection(connectionString);
            DataSet DSTmp;
            CnDatos.Open();
            try
            {

                if (CnDatos.State == ConnectionState.Open)
                {
                    SqlDataAdapter DATmp = new SqlDataAdapter(pStore, CnDatos);
                    //DATmp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //DATmp.SelectCommand.Parameters.Add(new SqlParameter("@NumeroCotizacion", SqlDbType.VarChar, 50, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.NumeroCotizacion));
                    //DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C01", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C01));
                    //DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C02", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C02));
                    //DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C03", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C03));
                    //DATmp.SelectCommand.Parameters.Add(new SqlParameter("@C04", SqlDbType.VarChar, 200, ParameterDirection.Input, false, System.Convert.ToByte(0), System.Convert.ToByte(0), "", DataRowVersion.Current, oENSCTR_EmisionTemporal.C04));
                    //DSTmp = new DataSet();
                    //DATmp.Fill(DSTmp);
                    CnDatos.Close();
                    DATmp = null;
                    CnDatos = null;
                    //return DSTmp;
                    return null;
                }
                else
                {
                    DSTmp = null/* TODO Change to default(_) if this is not a reference type */;
                    CnDatos.Close();
                    CnDatos = null/* TODO Change to default(_) if this is not a reference type */;
                    return DSTmp;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                DSTmp = null;
                return DSTmp;
            }
            finally
            {
                CnDatos.Close();
            }

        }



        public static dynamic Prueba(object data)
        {

            dynamic expando = new ExpandoObject();
            var dict = expando as IDictionary<string, object>;
            foreach (var property in data.GetType().GetProperties())
            {
                dict.Add(property.Name, property.GetValue(data, null));
            }
            return expando;

        }
        //static class ExpandoObjectExtensions

        //{ 
        //    public static dynamic CopyFrom(this ExpandoObject source, object data)
        //    {
        //        var dict = source as IDictionary<string, object>;
        //        foreach (var property in data.GetType().GetProperties())
        //        {
        //            dict.Add(property.Name, property.GetValue(data, null));
        //        }

        //        return source;
        //    }

        //    public static IEnumerable<dynamic> Dynamize<T>(this IEnumerable<T> source)
        //    {
        //        foreach (var entry in source)
        //        {
        //            var expando = new ExpandoObject();
        //            yield return expando.CopyFrom(entry);
        //        }
        //    }
        //    }






    }
}
