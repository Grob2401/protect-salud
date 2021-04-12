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

namespace AccesoDatos
{
    public class ADComun
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        private List<ENDatosError> ENDatosErrores;

        public DataSet SCTREmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            SqlConnection CnDatos= new SqlConnection(connectionString);
            DataSet DSTmp;
            CnDatos.Open();
            try
            {
 
                if (CnDatos.State == ConnectionState.Open)
                {
                    SqlDataAdapter DATmp = new SqlDataAdapter("ws_Ctz_PerCotizacionEmitirIndividual",CnDatos);
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


        public DataTable GetDataTable(string cnString, string sql)
        {

            using (SqlConnection cn = new SqlConnection(connectionString))

            {
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {

                    da.SelectCommand.CommandTimeout = 120;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }

            }
        }

        public DataSet GetDataSet(string cnString, string sql)
        {

            using (SqlConnection cn = new SqlConnection(connectionString))

            {
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {

                    da.SelectCommand.CommandTimeout = 120;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }

            }
        }


        public List<ENDatosError> YSCTREmisionIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            List<ENDatosError> oListaError = new List<ENDatosError>();
            return oListaError;
        }


        public List<ENDatosError> XSCTREmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            //Employees = new List<Employee>();
            //Employees.Add(new Employee() { Name = "Nombre 1", Designation = "Des1", Location = "Aqp", ImportePrima = "150" });
            //Employees.Add(new Employee() { Name = "Nombre 2", Designation = "Des2", Location = "Lim", ImportePrima = "250" });

            ENDatosErrores =new List<ENDatosError>();
            ENDatosErrores.Add(new ENDatosError() {CodigoError=1,DescripcionError="Descripcion 1" });
            ENDatosErrores.Add(new ENDatosError() { CodigoError = 2, DescripcionError = "Descripcion 2" });
            ENDatosErrores.Add(new ENDatosError() { CodigoError = 3, DescripcionError = "Descripcion 3" });

            SqlConnection CnDatos = new SqlConnection(connectionString);
            DataSet DSTmp;
            CnDatos.Open();

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
                    //return listDSTmp;
                    return ENDatosErrores;
                }
                else
                {
                    DSTmp = null/* TODO Change to default(_) if this is not a reference type */;
                    CnDatos.Close();
                    CnDatos = null/* TODO Change to default(_) if this is not a reference type */;
                    //return DSTmp;
                    return ENDatosErrores;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                DSTmp = null;
                //return DSTmp;
                return ENDatosErrores;
            }
            finally
            {
                CnDatos.Close();
            }
        }





    }
}
