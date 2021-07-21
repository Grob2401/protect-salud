using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{

    public class ADSaludAseguradosContratos
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public int Cantidad(string keywords)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_count");
                if (keywords != null) GenericDataAccess.AgregarParametro(oCommand, "@keywords", keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                int cantidadAsegurados = -1;
                if (oDataReader.Read() && !int.TryParse(oDataReader["Cantidad"].ToString(), out cantidadAsegurados)) cantidadAsegurados = -1;
                return cantidadAsegurados;
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

        public ENSaludAsegurados ObtenerUno(string CodigoCliente, string CodigoTitular, string Categoria)
        {
            DbCommand oCommand = null;
            ENSaludAsegurados oENSaludAsegurados = new ENSaludAsegurados();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_sel_uno");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTitular", CodigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCategoria", Categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENSaludAsegurados.ApellidoMaterno = oDataReader["ApellidoMaterno"].ToString();
                    oENSaludAsegurados.ApellidoPaterno = oDataReader["ApellidoPaterno"].ToString();
                    oENSaludAsegurados.ApellidosNombres = oDataReader["ApellidosNombres"].ToString();
                    oENSaludAsegurados.CantidadCarnet = Convert.ToInt32(oDataReader["CantidadCarnet"]);
                    oENSaludAsegurados.Categoria = oDataReader["Categoria"].ToString();
                    oENSaludAsegurados.Celular = oDataReader["Celular"].ToString();
                    oENSaludAsegurados.CodigoCentroCosto = oDataReader["CodigoCentroCosto"].ToString();
                    oENSaludAsegurados.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oENSaludAsegurados.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oENSaludAsegurados.CodigoDocumentoIdentidad = oDataReader["CodigoDocumentoIdentidad"].ToString();
                    oENSaludAsegurados.CodigoParentesco = oDataReader["CodigoParentesco"].ToString();
                    oENSaludAsegurados.CodigoSexo = oDataReader["CodigoSexo"].ToString();
                    oENSaludAsegurados.CodigoTipoTrabajador = oDataReader["CodigoTipoTrabajador"].ToString();
                    oENSaludAsegurados.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                    oENSaludAsegurados.CodigoTrabajador = oDataReader["CodigoTrabajador"].ToString();
                    oENSaludAsegurados.CodigoUbigeo = oDataReader["CodigoUbigeo"].ToString();
                    if (oENSaludAsegurados.CodigoUbigeo.Length == 0)
                    {
                        oENSaludAsegurados.CodigoUbigeo = "150101";
                    }

                    oENSaludAsegurados.CodigoDpto = oENSaludAsegurados.CodigoUbigeo.Substring(0, 2);
                    oENSaludAsegurados.CodigoProv = oENSaludAsegurados.CodigoUbigeo.Substring(2, 2);
                    oENSaludAsegurados.CodigoDist = oENSaludAsegurados.CodigoUbigeo.Substring(4, 2);

                    oENSaludAsegurados.Direccion = oDataReader["Direccion"].ToString();
                    oENSaludAsegurados.Email = oDataReader["Email"].ToString();
                    oENSaludAsegurados.Estado = oDataReader["Estado"].ToString();

                    oENSaludAsegurados.FechaAlta = oDataReader["FechaAlta"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaAlta"]);

                    //oEnListaSaludAsegurados.FechaBaja = DateTime.Parse(oDataReader["FechaBaja"].ToString());

                    oENSaludAsegurados.FechaBaja = oDataReader["FechaBaja"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaBaja"]);

                    //oEnListaSaludAsegurados.FechaEmisionCarnet = DateTime.Parse(oDataReader["FechaEmisionCarnet"].ToString());

                    oENSaludAsegurados.FechaEmisionCarnet = oDataReader["FechaEmisionCarnet"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaEmisionCarnet"]);

                    //oEnListaSaludAsegurados.FechaFinLatencia = DateTime.Parse(oDataReader["FechaFinLatencia"].ToString());

                    oENSaludAsegurados.FechaFinLatencia = oDataReader["FechaFinLatencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaFinLatencia"]);



                    //oEnListaSaludAsegurados.FechaInicioLatencia = DateTime.Parse(oDataReader["FechaInicioLatencia"].ToString());


                    oENSaludAsegurados.FechaInicioLatencia = oDataReader["FechaInicioLatencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaInicioLatencia"]);



                    //oEnListaSaludAsegurados.FechaNacimiento = DateTime.Parse(oDataReader["FechaNacimiento"].ToString());

                    oENSaludAsegurados.FechaNacimiento = oDataReader["FechaNacimiento"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaNacimiento"]);



                    //oEnListaSaludAsegurados.FechaReemisionCarnet = DateTime.Parse(oDataReader["FechaReemisionCarnet"].ToString());

                    oENSaludAsegurados.FechaReemisionCarnet = oDataReader["FechaReemisionCarnet"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaReemisionCarnet"]);



                    //oENSaludAsegurados.FechaAlta = DateTime.Parse(oDataReader["FechaAlta"].ToString());
                    //oENSaludAsegurados.FechaBaja = DateTime.Parse(oDataReader["FechaBaja"].ToString());
                    //oENSaludAsegurados.FechaEmisionCarnet = DateTime.Parse(oDataReader["FechaEmisionCarnet"].ToString());
                    //oENSaludAsegurados.FechaFinLatencia = DateTime.Parse(oDataReader["FechaFinLatencia"].ToString());
                    //oENSaludAsegurados.FechaInicioLatencia = DateTime.Parse(oDataReader["FechaInicioLatencia"].ToString());
                    //oENSaludAsegurados.FechaNacimiento = DateTime.Parse(oDataReader["FechaNacimiento"].ToString());
                    //oENSaludAsegurados.FechaReemisionCarnet = DateTime.Parse(oDataReader["FechaReemisionCarnet"].ToString());
                    oENSaludAsegurados.Nombres = oDataReader["Nombres"].ToString();
                    oENSaludAsegurados.NumeroDocumentoIdentidad = oDataReader["NumeroDocumentoIdentidad"].ToString();
                    oENSaludAsegurados.Peso = oDataReader["Peso"].ToString();
                    oENSaludAsegurados.RegAddDate = DateTime.Parse(oDataReader["RegAddDate"].ToString());
                    oENSaludAsegurados.RegAddUser = oDataReader["RegAddUser"].ToString();
                    //oENSaludAsegurados.RegEdtDate = DateTime.Parse(oDataReader["RegEdtDate"].ToString());

                    oENSaludAsegurados.RegEdtDate = oDataReader["RegEdtDate"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["RegEdtDate"]);


                    oENSaludAsegurados.RegEdtUser = oDataReader["RegEdtUser"].ToString();
                    oENSaludAsegurados.SCTREstadoCivil = oDataReader["SCTREstadoCivil"].ToString();
                    oENSaludAsegurados.SCTRMoneda = oDataReader["SCTRMoneda"].ToString();
                    oENSaludAsegurados.SCTRPSCertificado = oDataReader["SCTRPSCertificado"].ToString();
                    oENSaludAsegurados.SCTRSueldo = oDataReader["SCTRSueldo"].ToString();
                    oENSaludAsegurados.SCTRTipoTrabajador = oDataReader["SCTRTipoTrabajador"].ToString();
                    oENSaludAsegurados.Talla = oDataReader["Talla"].ToString();
                    oENSaludAsegurados.Telefono = oDataReader["Telefono"].ToString();

                }
                return oENSaludAsegurados;
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

        public string Insertar(ENSaludAsegurados oENSaludAsegurados , string ope)
        {

            DbCommand oCommand = null;
            string sUbigeo = "";
            string sTipoOpe = "";
            string cate = "";
            try
            {

                if (ope == "editar")
                {
                    sTipoOpe = "EDT";
                    cate = oENSaludAsegurados.Categoria;
                }
                else if (ope == "insertar")
                {
                    if (oENSaludAsegurados.CodigoTitular == "" || oENSaludAsegurados.CodigoTitular == null)
                    {
                        oENSaludAsegurados.CodigoTitular = "";
                    }

                    if (oENSaludAsegurados.CodigoParentesco == "T" && oENSaludAsegurados.Categoria == null)
                    {
                        sTipoOpe = "NEW";
                        cate = "";
                    }
                    else
                    {
                        sTipoOpe = "ADD";
                        cate = "";
                    }
                }

                if (oENSaludAsegurados.CodigoUbigeo is null)
                {
                    sUbigeo = oENSaludAsegurados.CodigoDpto + oENSaludAsegurados.CodigoProv + oENSaludAsegurados.CodigoDist;
                }
                else
                {
                    sUbigeo = oENSaludAsegurados.CodigoUbigeo;
                }

                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosMantenimientoSalud_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@PcsTipo", sTipoOpe, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCliente", oENSaludAsegurados.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTitular", oENSaludAsegurados.CodigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCategoria", cate, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodContrato", oENSaludAsegurados.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodPlanSalud", oENSaludAsegurados.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTra", oENSaludAsegurados.CodigoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoTrabajador", oENSaludAsegurados.CodigoTipoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ApePat", oENSaludAsegurados.ApellidoPaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ApeMat", oENSaludAsegurados.ApellidoMaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Nombre", oENSaludAsegurados.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodSexo", oENSaludAsegurados.CodigoSexo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchNac", oENSaludAsegurados.FechaNacimiento, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoDocIdent", oENSaludAsegurados.CodigoDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NroDocIdent", oENSaludAsegurados.NumeroDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchVgnIni", oENSaludAsegurados.InicioVigencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchVgnFin", oENSaludAsegurados.FinVigencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CtroCto", oENSaludAsegurados.CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodParent", oENSaludAsegurados.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTalla", oENSaludAsegurados.Talla, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodPeso", oENSaludAsegurados.Peso, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodProveedor", oENSaludAsegurados.CodigoProv, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodMedico", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaIniAdscrip", oENSaludAsegurados.FechaIniAdscrip, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PreExistCodigos", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PreExistOtros", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@AppUserCodigo", "CROJAS", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pTelfDom", oENSaludAsegurados.Telefono, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DirecDom", oENSaludAsegurados.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pCel", oENSaludAsegurados.Celular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Correo", oENSaludAsegurados.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodUbi", sUbigeo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoPlanOriginal", oENSaludAsegurados.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchIniLatencia", oENSaludAsegurados.FechaInicioLatencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchFinLatencia", oENSaludAsegurados.FechaFinLatencia, TipoParametro.STR, Direccion.INPUT);


                var query = oCommand.CommandText;
                foreach (DbParameter parameter in oCommand.Parameters)
                {
                    query += " " + '"' + parameter.Value.ToString() + '"' + ",";
                }

                var sqlstr = query;

                DataSet ds = new DataSet();
                //var contador = GenericDataAccess.ExecuteNonQuery(oCommand);
                SqlDataAdapter sda = new SqlDataAdapter((SqlCommand)oCommand);
                sda.Fill(ds);

                //-----------------------------------------------------------
                string datos = "";
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                var contador = ds.Tables.Count;
                var ultimaTabla = ds.Tables.Count - 1;

                if (contador > 0)
                {
                    if (oENSaludAsegurados.CodigoParentesco == "T" && ope == "insertar")
                    {
                        datos = ds.Tables[ultimaTabla].Rows[0][0].ToString() + "-" + ds.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        datos = ds.Tables[ultimaTabla].Rows[0][0].ToString() + "-" + oENSaludAsegurados.CodigoTitular;
                    }
                   
                }
               
                //-----------------------------------------------------------
                if (ds.Tables.Count > 0)
                    return datos;
                else
                    return datos;
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

        public bool Actualizar(ENSaludAsegurados oENSaludAsegurados)
        {

            DbCommand oCommand = null;
            string sUbigeo = "";
            try
            {

                if (oENSaludAsegurados.CodigoUbigeo is null)
                {
                    sUbigeo = oENSaludAsegurados.CodigoDpto + oENSaludAsegurados.CodigoProv + oENSaludAsegurados.CodigoDist;
                }
                else
                {
                    sUbigeo = oENSaludAsegurados.CodigoUbigeo;
                }
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoMaterno", oENSaludAsegurados.ApellidoMaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoPaterno", oENSaludAsegurados.ApellidoPaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidosNombres", oENSaludAsegurados.ApellidosNombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCantidadCarnet", oENSaludAsegurados.CantidadCarnet, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCategoria", oENSaludAsegurados.Categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCelular", oENSaludAsegurados.Celular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCentroCosto", oENSaludAsegurados.CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", oENSaludAsegurados.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCotizacion", oENSaludAsegurados.CodigoCotizacion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoDocumentoIdentidad", oENSaludAsegurados.CodigoDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoParentesco", oENSaludAsegurados.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoSexo", oENSaludAsegurados.CodigoSexo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTipoTrabajador", oENSaludAsegurados.CodigoTipoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTitular", oENSaludAsegurados.CodigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTrabajador", oENSaludAsegurados.CodigoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoUbigeo", sUbigeo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDireccion", oENSaludAsegurados.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEmail", oENSaludAsegurados.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEstado", oENSaludAsegurados.Estado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaAlta", oENSaludAsegurados.FechaAlta, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaBaja", oENSaludAsegurados.FechaBaja, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaEmisionCarnet", oENSaludAsegurados.FechaEmisionCarnet, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFinLatencia", oENSaludAsegurados.FechaFinLatencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicioLatencia", oENSaludAsegurados.FechaInicioLatencia, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaNacimiento", oENSaludAsegurados.FechaNacimiento, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaReemisionCarnet", oENSaludAsegurados.FechaReemisionCarnet, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombres", oENSaludAsegurados.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNumeroDocumentoIdentidad", oENSaludAsegurados.NumeroDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argPeso", oENSaludAsegurados.Peso, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRegAddDate", oENSaludAsegurados.RegAddDate, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRegAddUser", oENSaludAsegurados.RegAddUser, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRegEdtDate", oENSaludAsegurados.RegEdtDate, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argRegEdtUser", oENSaludAsegurados.RegEdtUser, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argSCTREstadoCivil", oENSaludAsegurados.SCTREstadoCivil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argSCTRMoneda", oENSaludAsegurados.SCTRMoneda, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argSCTRPSCertificado", oENSaludAsegurados.SCTRPSCertificado, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argSCTRSueldo", oENSaludAsegurados.SCTRSueldo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argSCTRTipoTrabajador", oENSaludAsegurados.SCTRTipoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTalla", oENSaludAsegurados.Talla, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono", oENSaludAsegurados.Telefono, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argUbicubi", oENSaludAsegurados.CodigoUbigeo, TipoParametro.STR, Direccion.INPUT);

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

        public bool Eliminar(string CodigoCliente, string CodigoTitular, string Categoria)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_del");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCliente", CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoTitular", CodigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCategoria", Categoria, TipoParametro.STR, Direccion.INPUT);

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

        public List<ENSaludAsegurados> ObtenerSaludAsegurados(string tipoConsulta,string codCliente,string codTitular,string codDependiente, string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosConsulta");
                GenericDataAccess.AgregarParametro(oCommand, "@TipoConsulta", tipoConsulta == null ? "" : tipoConsulta, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCliente", codCliente == null ? "" : codCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTitular", codTitular == null ? "" : codTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodDependiente", codDependiente == null ? "" : codDependiente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodContrato", codContrato == null ? "" : codContrato, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAsegurados oEnListaSaludAsegurados = new ENSaludAsegurados();
                    switch (tipoConsulta)
                    {
                        case "GRUPOFAMILIAR":
                            oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodCliente"].ToString();
                            oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodTitular"].ToString();
                            oEnListaSaludAsegurados.Categoria = oDataReader["CodCategoria"].ToString();
                            oEnListaSaludAsegurados.CodigoTrabajador = oDataReader["CodTrabajador"].ToString();
                            oEnListaSaludAsegurados.CodigoTipoTrabajador = oDataReader["CodigoTipoTrabajador"].ToString();
                            oEnListaSaludAsegurados.CodigoParentesco = oDataReader["CodParent"].ToString();
                            oEnListaSaludAsegurados.DescripcionParentesco = oDataReader["Parent"].ToString();
                            oEnListaSaludAsegurados.ApellidoPaterno = oDataReader["ApePat"].ToString();
                            oEnListaSaludAsegurados.ApellidoMaterno = oDataReader["ApeMat"].ToString();
                            oEnListaSaludAsegurados.Nombres = oDataReader["Nombre"].ToString();
                            oEnListaSaludAsegurados.ApellidosNombres = oDataReader["ApeNom"].ToString();
                            oEnListaSaludAsegurados.Edad = oDataReader["Edad"].ToString();
                            oEnListaSaludAsegurados.FechaAlta = oDataReader["FchAlta"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FchAlta"]);
                            oEnListaSaludAsegurados.FechaBaja = oDataReader["FchBaja"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FchBaja"]);
                            oEnListaSaludAsegurados.CodigoUbigeo = oDataReader["CodigoUbigeo"].ToString();                           
                            oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();
                            oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
                            break;
                        default:
                            oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodCliente"].ToString();
                            oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodTitular"].ToString();
                            oEnListaSaludAsegurados.Categoria = oDataReader["CodCategoria"].ToString();
                            oEnListaSaludAsegurados.CodigoContrato = oDataReader["CodContrato"].ToString();
                            oEnListaSaludAsegurados.CodigoTrabajador = oDataReader["CodTrabajador"].ToString();
                            oEnListaSaludAsegurados.CodigoTipoTrabajador = oDataReader["CodigoTipoTrabajador"].ToString();
                            oEnListaSaludAsegurados.CodigoParentesco = oDataReader["CodParent"].ToString();
                            oEnListaSaludAsegurados.ApellidoPaterno = oDataReader["ApePat"].ToString();
                            oEnListaSaludAsegurados.ApellidoMaterno = oDataReader["ApeMat"].ToString();
                            oEnListaSaludAsegurados.Nombres = oDataReader["Nombre"].ToString();
                            oEnListaSaludAsegurados.ApellidosNombres = oDataReader["ApeNom"].ToString();
                            oEnListaSaludAsegurados.CodigoSexo = oDataReader["CodigoSexo"].ToString();
                            oEnListaSaludAsegurados.FechaNacimiento = oDataReader["FchNac"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FchNac"]);
                            oEnListaSaludAsegurados.Edad = oDataReader["Edad"].ToString();
                            oEnListaSaludAsegurados.CodigoDocumentoIdentidad = oDataReader["DocTipoCod"].ToString();
                            oEnListaSaludAsegurados.DescripcionDocumentoIdentidad = oDataReader["DocTipoDes"].ToString();
                            oEnListaSaludAsegurados.NumeroDocumentoIdentidad = oDataReader["DocNumero"].ToString();
                            oEnListaSaludAsegurados.CodFechaAlta = oDataReader["CodFchAlta"].ToString();
                            oEnListaSaludAsegurados.FechaAlta = oDataReader["FchAlta"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FchAlta"]);
                            oEnListaSaludAsegurados.CodFechaBaja = oDataReader["CodFchBaja"].ToString();
                            oEnListaSaludAsegurados.FechaBaja = oDataReader["FchBaja"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FchBaja"]);
                            oEnListaSaludAsegurados.CodigoCentroCosto = oDataReader["CentroCtoCod"].ToString();
                            oEnListaSaludAsegurados.DescripcionCentroCosto = oDataReader["CentroCtoDes"].ToString();
                            oEnListaSaludAsegurados.Talla = oDataReader["Talla"].ToString();
                            oEnListaSaludAsegurados.Peso = oDataReader["Peso"].ToString();

                            oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
                            break;
                    }

                   
                }
                return oListaSaludAsegurados;
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
