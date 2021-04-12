using System;
using System.Collections.Generic;
using System.Data.Common;
using Entidades;
using System.Configuration;

namespace AccesoDatos
{

    public class ADSaludAsegurados
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public List<ENSaludAsegurados> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENSaludAsegurados> oListaSaludAsegurados = new List<ENSaludAsegurados>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_sel");
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
                    oEnListaSaludAsegurados.RegEdtDate = DateTime.Parse(oDataReader["RegEdtDate"].ToString());
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
                    oENSaludAsegurados.RegEdtDate = DateTime.Parse(oDataReader["RegEdtDate"].ToString());
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

        public bool Insertar(ENSaludAsegurados oENSaludAsegurados)
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

                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenSaludAsegurados_ins");
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
    }
}
