using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{

    public class ADSaludAsegurados
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludAsegurados> ObtenerTodos(int page, int rowsPerPage, string keywords)
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_sel");
                if (page > 0) GenericDataAccess.AgregarParametro(oCommand, "@page", page, TipoParametro.INT, Direccion.INPUT);
                if (rowsPerPage > 0) GenericDataAccess.AgregarParametro(oCommand, "@rowsPerPage", rowsPerPage, TipoParametro.INT, Direccion.INPUT);
                if (keywords != null) GenericDataAccess.AgregarParametro(oCommand, "@keywords", keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAsegurados oEnListaSaludAsegurados = new ENSaludAsegurados();
                    oEnListaSaludAsegurados.ApellidoMaterno = oDataReader["ApellidoMaterno"].ToString();
                    oEnListaSaludAsegurados.ApellidoPaterno = oDataReader["ApellidoPaterno"].ToString();
                    oEnListaSaludAsegurados.ApellidosNombres = oDataReader["ApellidosNombres"].ToString();
                    oEnListaSaludAsegurados.CantidadCarnet = Convert.ToInt32(oDataReader["CantidadCarnet"]);
                    oEnListaSaludAsegurados.Categoria = oDataReader["Categoria"].ToString();
                    oEnListaSaludAsegurados.Celular = oDataReader["Celular"].ToString();
                    oEnListaSaludAsegurados.CodigoCentroCosto = oDataReader["CodigoCentroCosto"].ToString();
                    oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludAsegurados.CodigoCotizacion = oDataReader["CodigoCotizacion"].ToString();
                    oEnListaSaludAsegurados.CodigoDocumentoIdentidad = oDataReader["CodigoDocumentoIdentidad"].ToString();
                    oEnListaSaludAsegurados.CodigoParentesco = oDataReader["CodigoParentesco"].ToString();
                    oEnListaSaludAsegurados.CodigoSexo = oDataReader["CodigoSexo"].ToString();
                    oEnListaSaludAsegurados.CodigoTipoTrabajador = oDataReader["CodigoTipoTrabajador"].ToString();
                    oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                    oEnListaSaludAsegurados.CodigoTrabajador = oDataReader["CodigoTrabajador"].ToString();
                    oEnListaSaludAsegurados.CodigoUbigeo = oDataReader["CodigoUbigeo"].ToString();
                    oEnListaSaludAsegurados.Direccion = oDataReader["Direccion"].ToString();
                    oEnListaSaludAsegurados.Email = oDataReader["Email"].ToString();
                    oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();
                    //oEnListaSaludAsegurados.FechaAlta = DateTime.Parse(oDataReader["FechaAlta"].ToString());

                    oEnListaSaludAsegurados.FechaAlta = oDataReader["FechaAlta"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaAlta"]);

                    //oEnListaSaludAsegurados.FechaBaja = DateTime.Parse(oDataReader["FechaBaja"].ToString());

                    oEnListaSaludAsegurados.FechaBaja = oDataReader["FechaBaja"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaBaja"]);

                    //oEnListaSaludAsegurados.FechaEmisionCarnet = DateTime.Parse(oDataReader["FechaEmisionCarnet"].ToString());

                    oEnListaSaludAsegurados.FechaEmisionCarnet = oDataReader["FechaEmisionCarnet"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaEmisionCarnet"]);

                    //oEnListaSaludAsegurados.FechaFinLatencia = DateTime.Parse(oDataReader["FechaFinLatencia"].ToString());

                    oEnListaSaludAsegurados.FechaFinLatencia = oDataReader["FechaFinLatencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaFinLatencia"]);



                    //oEnListaSaludAsegurados.FechaInicioLatencia = DateTime.Parse(oDataReader["FechaInicioLatencia"].ToString());


                    oEnListaSaludAsegurados.FechaInicioLatencia = oDataReader["FechaInicioLatencia"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaInicioLatencia"]);



                    //oEnListaSaludAsegurados.FechaNacimiento = DateTime.Parse(oDataReader["FechaNacimiento"].ToString());

                    oEnListaSaludAsegurados.FechaNacimiento = oDataReader["FechaNacimiento"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaNacimiento"]);



                    //oEnListaSaludAsegurados.FechaReemisionCarnet = DateTime.Parse(oDataReader["FechaReemisionCarnet"].ToString());

                    oEnListaSaludAsegurados.FechaReemisionCarnet = oDataReader["FechaReemisionCarnet"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaReemisionCarnet"]);




                    oEnListaSaludAsegurados.Nombres = oDataReader["Nombres"].ToString();

                    //oEnListaSaludAsegurados.NumeroDocumentoIdentidad = oDataReader["NumeroDocumentoIdentidad"].ToString();

                    oEnListaSaludAsegurados.NumeroDocumentoIdentidad = oDataReader["NumeroDocumentoIdentidad"] == DBNull.Value
                    ? ""
                    : oDataReader["NumeroDocumentoIdentidad"].ToString();

                    oEnListaSaludAsegurados.Peso = oDataReader["Peso"].ToString();

                    oEnListaSaludAsegurados.RegAddDate = DateTime.Parse(oDataReader["RegAddDate"].ToString());
                    oEnListaSaludAsegurados.RegAddUser = oDataReader["RegAddUser"].ToString();

                    //oEnListaSaludAsegurados.RegEdtDate = DateTime.Parse(oDataReader["RegEdtDate"].ToString());
                    if (!DateTime.TryParse(oDataReader["RegEdtDate"].ToString(), out DateTime regEdtDate)) regEdtDate = DateTime.Now;
                    oEnListaSaludAsegurados.RegEdtDate = regEdtDate;

                    oEnListaSaludAsegurados.RegEdtUser = oDataReader["RegEdtUser"].ToString();

                    //oEnListaSaludAsegurados.SCTREstadoCivil = oDataReader["SCTREstadoCivil"].ToString();
                    //oEnListaSaludAsegurados.SCTRMoneda = oDataReader["SCTRMoneda"].ToString();
                    //oEnListaSaludAsegurados.SCTRPSCertificado = oDataReader["SCTRPSCertificado"].ToString();
                    //oEnListaSaludAsegurados.SCTRSueldo = oDataReader["SCTRSueldo"].ToString();
                    //oEnListaSaludAsegurados.SCTRTipoTrabajador = oDataReader["SCTRTipoTrabajador"].ToString();

                    oEnListaSaludAsegurados.SCTREstadoCivil = oDataReader["SCTREstadoCivil"] == DBNull.Value
                    ? ""
                    : oDataReader["SCTREstadoCivil"].ToString();

                    oEnListaSaludAsegurados.SCTRMoneda = oDataReader["SCTRMoneda"] == DBNull.Value
                    ? ""
                    : oDataReader["SCTRMoneda"].ToString();

                    oEnListaSaludAsegurados.SCTRSueldo = oDataReader["SCTRSueldo"] == DBNull.Value
                    ? ""
                    : oDataReader["SCTRSueldo"].ToString();



                    oEnListaSaludAsegurados.SCTRPSCertificado = oDataReader["SCTRPSCertificado"] == DBNull.Value
                    ? ""
                    : oDataReader["SCTRPSCertificado"].ToString();


                    oEnListaSaludAsegurados.SCTRTipoTrabajador = oDataReader["SCTRTipoTrabajador"] == DBNull.Value
                    ? ""
                    : oDataReader["SCTRTipoTrabajador"].ToString();

                    oEnListaSaludAsegurados.Talla = oDataReader["Talla"].ToString();
                    oEnListaSaludAsegurados.Telefono = oDataReader["Telefono"].ToString();

                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
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

        public int Cantidad()
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_count");
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                int cantidadAsegurados = -1;
                if (oDataReader.Read() && !int.TryParse(oDataReader["SaludAsegurados"].ToString(), out cantidadAsegurados)) cantidadAsegurados = -1;
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
                    oENSaludAsegurados.CodigoTipoEstadoCivil = oDataReader["CodigoTipoEstadoCivil"].ToString();
                    
                    oENSaludAsegurados.SCTRMoneda = oDataReader["SCTRMoneda"].ToString();
                    oENSaludAsegurados.SCTRPSCertificado = oDataReader["SCTRPSCertificado"].ToString();
                    oENSaludAsegurados.SCTRSueldo = oDataReader["SCTRSueldo"].ToString();
                    oENSaludAsegurados.SCTRTipoTrabajador = oDataReader["SCTRTipoTrabajador"].ToString();
                    oENSaludAsegurados.Talla = oDataReader["Talla"].ToString();
                    oENSaludAsegurados.Telefono = oDataReader["Telefono"].ToString();
                    oENSaludAsegurados.Pais = oDataReader["CodigoTipoPais"].ToString();

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

        public string Insertar(ENSaludAsegurados oENSaludAsegurados, string ope)
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

                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosMantenimientoSalud_V3");
                GenericDataAccess.AgregarParametro(oCommand, "@PcsTipo", sTipoOpe == null ? "" : sTipoOpe, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCliente", oENSaludAsegurados.CodigoCliente == null ? "" : oENSaludAsegurados.CodigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTitular", oENSaludAsegurados.CodigoTitular == null ? "" : oENSaludAsegurados.CodigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCategoria", cate == null ? "" : cate, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodContrato", oENSaludAsegurados.CodigoContrato == null ? "" : oENSaludAsegurados.CodigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodPlanSalud", oENSaludAsegurados.CodigoPlan == null ? "" : oENSaludAsegurados.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTra", oENSaludAsegurados.CodigoTrabajador == null ? "" : oENSaludAsegurados.CodigoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoTrabajador", oENSaludAsegurados.CodigoTipoTrabajador == null ? "" : oENSaludAsegurados.CodigoTipoTrabajador, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ApePat", oENSaludAsegurados.ApellidoPaterno == null ? "" : oENSaludAsegurados.ApellidoPaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@ApeMat", oENSaludAsegurados.ApellidoMaterno == null ? "" : oENSaludAsegurados.ApellidoMaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Nombre", oENSaludAsegurados.Nombres == null ? "" : oENSaludAsegurados.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodSexo", oENSaludAsegurados.CodigoSexo == null ? "" : oENSaludAsegurados.CodigoSexo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchNac", oENSaludAsegurados.FechaNacimiento == null ? DateTime.Now : oENSaludAsegurados.FechaNacimiento, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoDocIdent", oENSaludAsegurados.CodigoDocumentoIdentidad == null ? "" : oENSaludAsegurados.CodigoDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@NroDocIdent", oENSaludAsegurados.NumeroDocumentoIdentidad == null ? "" : oENSaludAsegurados.NumeroDocumentoIdentidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchVgnIni", oENSaludAsegurados.InicioVigencia == null ? DateTime.Now : oENSaludAsegurados.InicioVigencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchVgnFin", oENSaludAsegurados.FinVigencia == null ? DateTime.Now : oENSaludAsegurados.FinVigencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CtroCto", oENSaludAsegurados.CodigoCentroCosto == null ? "" : oENSaludAsegurados.CodigoCentroCosto, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodParent", oENSaludAsegurados.CodigoParentesco == null ? "" : oENSaludAsegurados.CodigoParentesco, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTalla", oENSaludAsegurados.Talla == null ? "" : oENSaludAsegurados.Talla, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodPeso", oENSaludAsegurados.Peso == null ? "" : oENSaludAsegurados.Peso, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodProveedor", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodMedico", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaIniAdscrip", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PreExistCodigos", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@PreExistOtros", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@AppUserCodigo", "CROJAS", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pTelfDom", oENSaludAsegurados.Telefono == null ? "" : oENSaludAsegurados.Telefono, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@DirecDom", oENSaludAsegurados.Direccion == null ? "" : oENSaludAsegurados.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@pCel", oENSaludAsegurados.Celular == null ? "" : oENSaludAsegurados.Celular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Correo", oENSaludAsegurados.Email == null ? "" : oENSaludAsegurados.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodUbi", sUbigeo == null ? "" : sUbigeo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoPlanOriginal", oENSaludAsegurados.CodigoPlan == null ? "" : oENSaludAsegurados.CodigoPlan, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchIniLatencia", oENSaludAsegurados.FechaInicioLatencia == null ? DateTime.Now : oENSaludAsegurados.FechaInicioLatencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FchFinLatencia", oENSaludAsegurados.FechaFinLatencia == null ? DateTime.Now : oENSaludAsegurados.FechaFinLatencia, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTipoEstadoCivil", oENSaludAsegurados.CodigoTipoEstadoCivil == null ? "" : oENSaludAsegurados.CodigoTipoEstadoCivil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoPais", oENSaludAsegurados.Pais == null ? "" : oENSaludAsegurados.Pais, TipoParametro.STR, Direccion.INPUT);
                


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

        public List<ENSaludAsegurados> ObtenerSaludAsegurados(int page, int rows, string Keywords, string tipoConsulta, string tipoCliente, string codCliente, string codTitular, string codDependiente, string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosConsulta");
                GenericDataAccess.AgregarParametro(oCommand, "@page", page, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@rowsPerPage", rows, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@keywords", Keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoConsulta", tipoConsulta == null ? "" : tipoConsulta, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoCliente", tipoCliente == null ? "" : tipoCliente, TipoParametro.STR, Direccion.INPUT);
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

                        case "POTESTATIVOS":
                            oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                            oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                            oEnListaSaludAsegurados.Categoria = oDataReader["Categoria"].ToString();
                            oEnListaSaludAsegurados.ApellidosNombres = oDataReader["Asegurado"].ToString();
                            oEnListaSaludAsegurados.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                            oEnListaSaludAsegurados.FechaNacimiento = oDataReader["FechaNacimiento"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FechaNacimiento"]);
                            oEnListaSaludAsegurados.Edad = oDataReader["Edad"].ToString();
                            oEnListaSaludAsegurados.FechaAlta = oDataReader["FechaAlta"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FechaAlta"]);
                            oEnListaSaludAsegurados.FechaBaja = oDataReader["FechaBaja"] == DBNull.Value
                            ? DateTime.Now
                            : Convert.ToDateTime(oDataReader["FechaBaja"]);
                            oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();

                            oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
                            break;

                        default:
                            oEnListaSaludAsegurados.RowNumber = Convert.ToInt32(oDataReader["RowNumber"]);
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
                            oEnListaSaludAsegurados.CodigoTipoCliente = oDataReader["CodigoTipoCliente"].ToString();
                            oEnListaSaludAsegurados.RazonSocial = oDataReader["RazonSocial"].ToString();
                            oEnListaSaludAsegurados.RucDni = oDataReader["RucDni"].ToString();
                            oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();

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

        // exec sp_Afl_AseguradosIndependientes '0000001249'
        public List<ENSaludAsegurados> ObtenerSaludAseguradosIndependientesPagos(string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosIndependientes");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", codContrato == null ? "" : codContrato, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAsegurados oEnListaSaludAsegurados = new ENSaludAsegurados();

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
                    oEnListaSaludAsegurados.Asegurado = oDataReader["Asegurado"].ToString();
                    oEnListaSaludAsegurados.Edad = oDataReader["Edad"].ToString();
                    oEnListaSaludAsegurados.FechaAlta = oDataReader["FchAlta"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FchAlta"]);
                    oEnListaSaludAsegurados.FechaBaja = oDataReader["FchBaja"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FchBaja"]);
                    oEnListaSaludAsegurados.CodigoUbigeo = oDataReader["CodigoUbigeo"].ToString();

                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);

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


        public List<ENSaludAsegurados> ObtenerSaludAseguradosRegularesPagos(string codCliente,string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_EmpresasObtenerTodasCuotas_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", codCliente == null ? "" : codCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", codContrato == null ? "" : codContrato, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAsegurados oEnListaSaludAsegurados = new ENSaludAsegurados();

                    oEnListaSaludAsegurados.CodigoCliente = oDataReader["IDCuota"].ToString();
                    oEnListaSaludAsegurados.FechaAlta = oDataReader["FechaDesde"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaDesde"]);
                    oEnListaSaludAsegurados.FechaAlta = oDataReader["FechaHasta"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaHasta"]);
                    oEnListaSaludAsegurados.CodigoTrabajador = oDataReader["Año Proceso"].ToString();
                    oEnListaSaludAsegurados.CodigoTipoTrabajador = oDataReader["MesProceso"].ToString();
                    oEnListaSaludAsegurados.CodigoParentesco = oDataReader["NumeroFactura"].ToString();
                    oEnListaSaludAsegurados.DescripcionParentesco = oDataReader["Estado"].ToString();
                    oEnListaSaludAsegurados.ApellidoPaterno = oDataReader["AporteAfiliado"].ToString();
                    oEnListaSaludAsegurados.ApellidoMaterno = oDataReader["AporteEmpresa"].ToString();
                    
                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);


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


        //exec sp_Afl_AseguradosObtenerCuotasNoPagadas '00253579','000494','00','0000001239'
        public List<ENSaludAseguradosContratosPagos> ObtenerSaludAseguradosCuotasNoPagadas(string codCliente, string codTitular, string categoria, string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAseguradosContratosPagos> oListaSaludAsegurados = new List<ENSaludAseguradosContratosPagos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosObtenerCuotasNoPagadas_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTitular", codTitular == null ? "" : codTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", codCliente == null ? "" : codCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Categoria", categoria == null ? "" : categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", codContrato == null ? "" : codContrato, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAseguradosContratosPagos oEnListaSaludAsegurados = new ENSaludAseguradosContratosPagos();

                    oEnListaSaludAsegurados.IdCuota = oDataReader["IdCuota"].ToString();
                    oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                    oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludAsegurados.Categoria = oDataReader["Categoria"].ToString();
                    oEnListaSaludAsegurados.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oEnListaSaludAsegurados.FechaInicioCuota = oDataReader["FechaInicioCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaInicioCuota"]);

                    oEnListaSaludAsegurados.FechaFinCuota = oDataReader["FechaFinCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaFinCuota"]);

                    oEnListaSaludAsegurados.FechaPago = oDataReader["FechaPago"] == DBNull.Value
                    ? DateTime.Now
:                   Convert.ToDateTime(oDataReader["FechaPago"]);

                    oEnListaSaludAsegurados.CodigoTipoDocumentoPago = oDataReader["CodigoTipoDocumentoPago"].ToString();
                    oEnListaSaludAsegurados.NumeroDocumentoPago = oDataReader["NumeroDocumentoPago"].ToString();
                    oEnListaSaludAsegurados.Monto = oDataReader["Monto"].ToString();
                    oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();

                    oEnListaSaludAsegurados.FechaCreacion = oDataReader["FechaCreacion"] == DBNull.Value
                    ? DateTime.Now
:                   Convert.ToDateTime(oDataReader["FechaCreacion"]);

                    oEnListaSaludAsegurados.CreadoPor = oDataReader["CreadoPor"].ToString();
                    oEnListaSaludAsegurados.ModificadoPor = oDataReader["ModificadoPor"].ToString();
                    oEnListaSaludAsegurados.FechaModificacion = oDataReader["FechaModificacion"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaModificacion"]);

                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
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

        public List<ENSaludAseguradosContratosPagos> ObtenerAseguradosTodasCuotas(string codCliente, string codTitular, string categoria, string codContrato)
        {
            DbCommand oCommand = null;
            List<ENSaludAseguradosContratosPagos> oListaSaludAsegurados = new List<ENSaludAseguradosContratosPagos>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosObtenerTodasCuotas_V2");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTitular", codTitular == null ? "" : codTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", codCliente == null ? "" : codCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Categoria", categoria == null ? "" : categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", codContrato == null ? "" : codContrato, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENSaludAseguradosContratosPagos oEnListaSaludAsegurados = new ENSaludAseguradosContratosPagos();

                    oEnListaSaludAsegurados.IdCuota = oDataReader["IdCuota"].ToString();
                    oEnListaSaludAsegurados.CodigoTitular = oDataReader["CodigoTitular"].ToString();
                    oEnListaSaludAsegurados.CodigoCliente = oDataReader["CodigoCliente"].ToString();
                    oEnListaSaludAsegurados.Categoria = oDataReader["Categoria"].ToString();
                    oEnListaSaludAsegurados.CodigoContrato = oDataReader["CodigoContrato"].ToString();
                    oEnListaSaludAsegurados.FechaInicioCuota = oDataReader["FechaInicioCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaInicioCuota"]);

                    oEnListaSaludAsegurados.FechaFinCuota = oDataReader["FechaFinCuota"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaFinCuota"]);

                    oEnListaSaludAsegurados.FechaPago = oDataReader["FechaPago"] == DBNull.Value
                    ? DateTime.Now
: Convert.ToDateTime(oDataReader["FechaPago"]);

                    oEnListaSaludAsegurados.CodigoTipoDocumentoPago = oDataReader["CodigoTipoDocumentoPago"].ToString();
                    oEnListaSaludAsegurados.DescripcionTipoDocumentoPago = oDataReader["DescripcionTipoDocumentoPago"].ToString();
                    oEnListaSaludAsegurados.NumeroDocumentoPago = oDataReader["NumeroDocumentoPago"].ToString();
                    oEnListaSaludAsegurados.Monto = oDataReader["Monto"].ToString();
                    oEnListaSaludAsegurados.Estado = oDataReader["Estado"].ToString();

                    oEnListaSaludAsegurados.FechaCreacion = oDataReader["FechaCreacion"] == DBNull.Value
                    ? DateTime.Now
: Convert.ToDateTime(oDataReader["FechaCreacion"]);

                    oEnListaSaludAsegurados.CreadoPor = oDataReader["CreadoPor"].ToString();
                    oEnListaSaludAsegurados.ModificadoPor = oDataReader["ModificadoPor"].ToString();
                    oEnListaSaludAsegurados.FechaModificacion = oDataReader["FechaModificacion"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(oDataReader["FechaModificacion"]);

                    oListaSaludAsegurados.Add(oEnListaSaludAsegurados);
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

        //sp_Afl_AseguradosVerificarBaja
        public bool validarCuotas(string cliente, string titular, string categoria, string fechaFin)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosVerificarBaja");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTitular", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", titular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Categoria", categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@FechaFin", fechaFin, TipoParametro.DT, Direccion.INPUT);

                int resultado = Convert.ToInt32(GenericDataAccess.ExecuteScalar(oCommand));
                bool resultadoBool = false;

                if (resultado == 1)
                {
                    resultadoBool = true;
                }
                else if (resultado == -1)
                {
                    resultadoBool = false;
                }
                return resultadoBool;
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

        //sp_Afl_Asegurados_VerificarMontoIndependientes

        public bool VerificarMontoIndependientes(string cliente, string titular, string categoria, string codigoContrato, string fechaInicio, double monto)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_Asegurados_VerificarMontoIndependientes");
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoTitular", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoCliente", titular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Categoria", categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoContrato", codigoContrato, TipoParametro.STR, Direccion.INPUT);                
                GenericDataAccess.AgregarParametro(oCommand, "@FechaInicio", fechaInicio, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@Monto", monto, TipoParametro.STR, Direccion.INPUT);

                int resultado = Convert.ToInt32(GenericDataAccess.ExecuteScalar(oCommand));
                bool resultadoBool = false;

                if (resultado == 1)
                {
                    resultadoBool = true;
                }
                else if (resultado == -1)
                {
                    resultadoBool = false;
                }
                return resultadoBool;
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

        public bool WebService_Log(string cliente, string titular, string categoria, string ws_metodo, string ws_request, string ws_response, string response_codigo, string response_descripcion, string usuario)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_LogSaludAsegurados_ins");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodCliente", cliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodTitula", titular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCategoria", categoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argWSMetodo", ws_metodo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argWSRequest", ws_request, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argWSResponse", ws_response, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argResponse_Codigo", response_codigo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argResponse_Descripcion", response_descripcion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argUsuario", usuario, TipoParametro.STR, Direccion.INPUT);
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

        public bool DarBaja(string fechaBaja, string codigoCliente, string codigoTitular, string codigoCategoria, string codigoContrato, string usuario,string motivo, string motivoOtro)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "sp_Afl_AseguradosMantenimientoBaja_V3");
                GenericDataAccess.AgregarParametro(oCommand, "@FchBaja", fechaBaja, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCliente", codigoCliente, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodTitular", codigoTitular, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodCategoria", codigoCategoria, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodContrato", codigoContrato, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodPlanSalud", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@TipoMov", "B", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@xSql", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@sWhere", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@AppUserCodigo", usuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@CodigoMotivoBaja", motivo, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@OtroMotivoBaja", motivoOtro, TipoParametro.STR, Direccion.INPUT);
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
