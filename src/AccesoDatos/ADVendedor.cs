using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADVendedor
    {

        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;


        public int Cantidad(string sociedad)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenVendedores_count");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                int cantidadVendedores = -1;
                if (oDataReader.Read() && !int.TryParse(oDataReader["Vendedores"].ToString(), out cantidadVendedores)) cantidadVendedores = -1;
                return cantidadVendedores;
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

        public List<ENVendedores> ObtenerTodos(string sociedad)
        {
            DbCommand oCommand = null;
            List<ENVendedores> oListaVendedores = new List<ENVendedores>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENVendedores oEnListaVendedores = new ENVendedores();
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"] == DBNull.Value ? "" : oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.DNI = oDataReader["DocumentoVendedor"] == DBNull.Value ? "" : oDataReader["DocumentoVendedor"].ToString();
                    oEnListaVendedores.ApellidoPaterno = oDataReader["ApellidoPaterno"] == DBNull.Value ? "" : oDataReader["ApellidoPaterno"].ToString();
                    oEnListaVendedores.ApellidoMaterno = oDataReader["ApellidoMaterno"] == DBNull.Value ? "" : oDataReader["ApellidoMaterno"].ToString();
                    oEnListaVendedores.Nombres = oDataReader["Nombres"] == DBNull.Value ? "" : oDataReader["Nombres"].ToString();
                    oEnListaVendedores.Direccion = oDataReader["Direccion"] == DBNull.Value ? "" : oDataReader["Direccion"].ToString();
                    oEnListaVendedores.Telefono = oDataReader["Telefono"] == DBNull.Value ? "" : oDataReader["Telefono"].ToString();
                    oEnListaVendedores.Email = oDataReader["Email"] == DBNull.Value ? "" : oDataReader["Email"].ToString();
                    oEnListaVendedores.CodigoUsuario = oDataReader["CodigoUsuario"] == DBNull.Value ? "" : oDataReader["CodigoUsuario"].ToString();
                    oEnListaVendedores.CodigoPerfil = oDataReader["CodigoPerfil"] == DBNull.Value ? "" : oDataReader["CodigoPerfil"].ToString();
                    oEnListaVendedores.IdPersona = oDataReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaVendedores.IdSociedad = oDataReader["IdSociedad"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IdSociedad"]);
                    oEnListaVendedores.RazonSocial = oDataReader["RazonSocial"] == DBNull.Value ? "" : oDataReader["RazonSocial"].ToString();
                    oEnListaVendedores.Comision_Tipo_Descripcion = oDataReader["Comision_Tipo"] == DBNull.Value ? "" : oDataReader["Comision_Tipo"].ToString();
                    oEnListaVendedores.Comision_Cantidad = oDataReader["Comision_Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["Comision_Cantidad"]);
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"] == DBNull.Value ? "" : oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.Vendedor = oDataReader["Vendedor"] == DBNull.Value ? "" : oDataReader["Vendedor"].ToString();
                    oEnListaVendedores.DescripcionVendedor = oEnListaVendedores.ApellidoPaterno + " " + oEnListaVendedores.ApellidoMaterno + " " + oEnListaVendedores.Nombres;

                    oListaVendedores.Add(oEnListaVendedores);
                }
                return oListaVendedores;
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

        public List<ENVendedores> ObtenerTodos(int page, int rows, string type, string Keywords, string sociedad)
        {
            DbCommand oCommand = null;
            List<ENVendedores> oListaVendedores = new List<ENVendedores>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@page", page, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@rowsPerPage", rows, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@type", type, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@keywords", Keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENVendedores oEnListaVendedores = new ENVendedores(); 
                    oEnListaVendedores.RowNumber = oDataReader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["RowNumber"]);
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"] == DBNull.Value ? "" : oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.DNI = oDataReader["DocumentoVendedor"] == DBNull.Value ? "" : oDataReader["DocumentoVendedor"].ToString();
                    oEnListaVendedores.ApellidoPaterno = oDataReader["ApellidoPaterno"] == DBNull.Value ? "" : oDataReader["ApellidoPaterno"].ToString();
                    oEnListaVendedores.ApellidoMaterno = oDataReader["ApellidoMaterno"] == DBNull.Value ? "" : oDataReader["ApellidoMaterno"].ToString();
                    oEnListaVendedores.Nombres = oDataReader["Nombres"] == DBNull.Value ? "" : oDataReader["Nombres"].ToString();
                    oEnListaVendedores.Direccion = oDataReader["Direccion"] == DBNull.Value ? "" : oDataReader["Direccion"].ToString();
                    oEnListaVendedores.Telefono = oDataReader["Telefono"] == DBNull.Value ? "" : oDataReader["Telefono"].ToString();
                    oEnListaVendedores.Email = oDataReader["Email"] == DBNull.Value ? "" : oDataReader["Email"].ToString();
                    oEnListaVendedores.CodigoUsuario = oDataReader["CodigoUsuario"] == DBNull.Value ? "" : oDataReader["CodigoUsuario"].ToString();
                    oEnListaVendedores.CodigoPerfil = oDataReader["CodigoPerfil"] == DBNull.Value ? "" : oDataReader["CodigoPerfil"].ToString();
                    oEnListaVendedores.IdPersona = oDataReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaVendedores.IdSociedad = oDataReader["IdSociedad"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["IdSociedad"]);
                    oEnListaVendedores.RazonSocial = oDataReader["RazonSocial"] == DBNull.Value ? "" : oDataReader["RazonSocial"].ToString();
                    oEnListaVendedores.Comision_Tipo_Descripcion = oDataReader["Comision_Tipo"] == DBNull.Value ? "" : oDataReader["Comision_Tipo"].ToString();
                    oEnListaVendedores.Comision_Cantidad = oDataReader["Comision_Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oDataReader["Comision_Cantidad"]);
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"] == DBNull.Value ? "" : oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.Vendedor = oDataReader["Vendedor"] == DBNull.Value ? "" : oDataReader["Vendedor"].ToString();
                    oEnListaVendedores.DescripcionVendedor = oEnListaVendedores.ApellidoPaterno + " " + oEnListaVendedores.ApellidoMaterno + " " + oEnListaVendedores.Nombres;

                    oListaVendedores.Add(oEnListaVendedores);
                }
                return oListaVendedores;
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

        public bool Insertar(ENVendedores oENVendedores)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_INS_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENVendedores.CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDNI", oENVendedores.DNI, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argNombres", oENVendedores.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoPaterno", oENVendedores.ApellidoPaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDireccion", oENVendedores.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoMaterno", oENVendedores.ApellidoMaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono", oENVendedores.Telefono, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEmail", oENVendedores.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoUsuario", oENVendedores.CodigoUsuario, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoPerfil", oENVendedores.CodigoPerfil, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIdPersona", oENVendedores.IdPersona, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIdSociedad", oENVendedores.IdSociedad, TipoParametro.INT, Direccion.INPUT);
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

        public bool Actualizar(ENVendedores oENVendedores)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_UPD_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENVendedores.CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDNI", oENVendedores.DNI, TipoParametro.STR, Direccion.INPUT);                
                GenericDataAccess.AgregarParametro(oCommand, "@argNombres", oENVendedores.Nombres, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoPaterno", oENVendedores.ApellidoPaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDireccion", oENVendedores.Direccion, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argApellidoMaterno", oENVendedores.ApellidoMaterno, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argTelefono", oENVendedores.Telefono, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argEmail", oENVendedores.Email, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIdSociedad", oENVendedores.IdSociedad, TipoParametro.INT, Direccion.INPUT);

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

        public bool Eliminar(string CodigoVendedor)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_DEL_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", CodigoVendedor, TipoParametro.STR, Direccion.INPUT);

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

        public string Asignar(ENCanalesVendedores oENCV)
        {
            DbCommand oCommand = null;
            try
            {
                string mensaje = "";

                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_INS_ASIGNACION_CANALVENDEDOR");
                GenericDataAccess.AgregarParametro(oCommand, "@argIDCanal", oENCV.CV_IDCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicioCanalVendedor", oENCV.CV_FechaInicioCanalVendedor, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFinCanalVendedor", oENCV.CV_FechaFinCanalVendedor, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENCV.CV_CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);

                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    mensaje = oDataReader["RESULTADO"].ToString();                    
                }
                return mensaje;
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

        public List<ENCanalesVendedores> ObtenerAsignados(string sociedad)
        {
            DbCommand oCommand = null;
            List<ENCanalesVendedores> oListaCanalesVendedores = new List<ENCanalesVendedores>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_ASIGNACION_CANALVENDEDOR");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCanalesVendedores oENListaCanalesVendedores = new ENCanalesVendedores();
                    oENListaCanalesVendedores.CV_IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oENListaCanalesVendedores.CV_IdSociedad = Convert.ToInt32(oDataReader["IDCanal"]);
                    oENListaCanalesVendedores.CV_CodigoVendedor = oDataReader["CodigoVendedor"].ToString();
                    oENListaCanalesVendedores.CV_DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oENListaCanalesVendedores.CV_FechaInicioCanalVendedor = Convert.ToDateTime(oDataReader["FechaInicioCanalVendedor"]);
                    oENListaCanalesVendedores.CV_FechaFinCanalVendedor = Convert.ToDateTime(oDataReader["FechaFinCanalVendedor"]);
                    oENListaCanalesVendedores.CV_Vendedor = oDataReader["Vendedor"].ToString();
                    oENListaCanalesVendedores.CV_Telefono = oDataReader["Telefono"].ToString();
                    oENListaCanalesVendedores.CV_Email = oDataReader["Email"].ToString();
                    oENListaCanalesVendedores.Vendedor_TipoComi = oDataReader["Vendedor_TipoComi"].ToString();
                    oENListaCanalesVendedores.Vendedor_CantComi = oDataReader["Vendedor_CantComi"].ToString();
                    oENListaCanalesVendedores.Canal_TipoComi = oDataReader["Canal_TipoComi"].ToString();
                    oENListaCanalesVendedores.Canal_CantComi = oDataReader["Canal_CantComi"].ToString();
                                                                                            
                    oListaCanalesVendedores.Add(oENListaCanalesVendedores);
                }
                return oListaCanalesVendedores;
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

        public bool InsertarComision(ENVendedores oENVendedorComision)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_INS_MANTENIMIENTO_VENDEDOR_COMISION");
                GenericDataAccess.AgregarParametro(oCommand, "@argValorComision", oENVendedorComision.Comision_Cantidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicio", oENVendedorComision.Comision_fechaInicio, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFin", oENVendedorComision.Comision_FechaFin, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENVendedorComision.Comision_CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIdTipoComision", oENVendedorComision.Comision_Idtipo, TipoParametro.STR, Direccion.INPUT);
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
