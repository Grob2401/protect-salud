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

        public List<ENVendedores> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENVendedores> oListaVendedores = new List<ENVendedores>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_SEL_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@Busqueda", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", "", TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENVendedores oEnListaVendedores = new ENVendedores();
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.ApellidoPaterno = oDataReader["ApellidoPaterno"].ToString();
                    oEnListaVendedores.ApellidoMaterno = oDataReader["ApellidoMaterno"].ToString();
                    oEnListaVendedores.Nombres = oDataReader["Nombres"].ToString();
                    oEnListaVendedores.Direccion = oDataReader["Direccion"].ToString();
                    oEnListaVendedores.Telefono = oDataReader["Telefono"].ToString();
                    oEnListaVendedores.Email = oDataReader["Email"].ToString();
                    oEnListaVendedores.CodigoUsuario = oDataReader["CodigoUsuario"].ToString();
                    oEnListaVendedores.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oEnListaVendedores.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaVendedores.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
                    oEnListaVendedores.RazonSocial = oDataReader["RazonSocial"].ToString();
                    oEnListaVendedores.IdPersonaSociedad = Convert.ToInt32(oDataReader["IdPersonaSociedad"]);
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

        public List<ENVendedores> ObtenerTodos(string sociedad)
        {
            DbCommand oCommand = null;
            List<ENVendedores> oListaVendedores = new List<ENVendedores>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_SEL_MANTENIMIENTO_VENDEDORES");
                GenericDataAccess.AgregarParametro(oCommand, "@Busqueda", "", TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENVendedores oEnListaVendedores = new ENVendedores();
                    oEnListaVendedores.CodigoVendedor = oDataReader["CodigoVendedor"].ToString();
                    oEnListaVendedores.ApellidoPaterno = oDataReader["ApellidoPaterno"].ToString();
                    oEnListaVendedores.ApellidoMaterno = oDataReader["ApellidoMaterno"].ToString();
                    oEnListaVendedores.Nombres = oDataReader["Nombres"].ToString();
                    oEnListaVendedores.Direccion = oDataReader["Direccion"].ToString();
                    oEnListaVendedores.Telefono = oDataReader["Telefono"].ToString();
                    oEnListaVendedores.Email = oDataReader["Email"].ToString();
                    oEnListaVendedores.CodigoUsuario = oDataReader["CodigoUsuario"].ToString();
                    oEnListaVendedores.CodigoPerfil = oDataReader["CodigoPerfil"].ToString();
                    oEnListaVendedores.IdPersona = Convert.ToInt32(oDataReader["IdPersona"]);
                    oEnListaVendedores.IdSociedad = Convert.ToInt32(oDataReader["IdSociedad"]);
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
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_INS_MANTENIMIENTO_VENDEDORES");
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
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenVendedores_upd");
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoVendedor", oENVendedores.CodigoVendedor, TipoParametro.STR, Direccion.INPUT);
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

        public bool Eliminar(string CodigoVendedor)
        {

            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenVendedores_del");
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

    }
}
