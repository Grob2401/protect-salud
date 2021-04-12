using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Entidades;
using Excepciones;

namespace AccesoDatos
{
    public class ADUsuario
    {
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public List<ENUsuario> ObtenerTodos()
        {
            DbCommand oCommand = null;
            List<ENUsuario> oListaUsuario = new List<ENUsuario>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_ObtenerTodos");
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENUsuario oEnListaUsuario = new ENUsuario();
                    oEnListaUsuario.int_IdUsuario = Convert.ToInt32(oDataReader["int_IdUsuario"]);
                    oEnListaUsuario.var_Nombre = oDataReader["var_Nombre"].ToString();
                    oEnListaUsuario.var_Apellidos = oDataReader["var_Apellidos"].ToString();
                    oEnListaUsuario.var_Mail = oDataReader["var_Mail"].ToString();
                    oEnListaUsuario.bit_Sexo = Convert.ToBoolean(oDataReader["bit_Sexo"]);
                    oEnListaUsuario.int_Estado = Convert.ToInt32(oDataReader["int_Estado"]);
                    oEnListaUsuario.var_Password = oDataReader["var_Password"].ToString();
                    oEnListaUsuario.dtm_FechaNacimiento = Convert.ToDateTime(oDataReader["dtm_FechaNacimiento"]);
                    oEnListaUsuario.var_DNI = oDataReader["var_DNI"].ToString();

                    oListaUsuario.Add(oEnListaUsuario);
                }
                return oListaUsuario;
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

        public ENUsuario ObtenerPorCorreoElectronico(string usuario)
        {

            DbCommand oCommand = null;
            ENUsuario oENUsuario = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_ObtenerUnoPorCorreo");
                GenericDataAccess.AgregarParametro(oCommand, "@var_Mail", usuario, TipoParametro.STR, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {
                    oENUsuario = new ENUsuario();
                    oENUsuario.int_IdUsuario = Convert.ToInt32(oDataReader["int_IdUsuario"]);
                    oENUsuario.var_Nombre = oDataReader["var_Nombre"].ToString();
                    oENUsuario.var_Apellidos = oDataReader["var_Apellidos"].ToString();
                    oENUsuario.var_Mail = oDataReader["var_Mail"].ToString();
                    oENUsuario.bit_Sexo = Convert.ToBoolean(oDataReader["bit_Sexo"]);
                    oENUsuario.int_Estado = Convert.ToInt32(oDataReader["int_Estado"]);
                    oENUsuario.var_Password = oDataReader["var_Password"].ToString();
                    oENUsuario.dtm_FechaNacimiento = Convert.ToDateTime(oDataReader["dtm_FechaNacimiento"]);
                    oENUsuario.var_DNI = oDataReader["var_DNI"].ToString();


                }
                return oENUsuario;
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

        public ENUsuario ObtenerUno(int id)
        {
            DbCommand oCommand = null;
            ENUsuario oENUsuario = new ENUsuario();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_ObtenerUnoJP");
                GenericDataAccess.AgregarParametro(oCommand, "@int_IdUsuario", id, TipoParametro.INT, Direccion.INPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                if (oDataReader.Read())
                {

                    oENUsuario.int_IdUsuario = Convert.ToInt32(oDataReader["int_IdUsuario"]);
                    oENUsuario.var_Nombre = oDataReader["var_Nombre"].ToString();
                    oENUsuario.var_Apellidos = oDataReader["var_Apellidos"].ToString();
                    oENUsuario.var_Mail = oDataReader["var_Mail"].ToString();
                    oENUsuario.bit_Sexo = Convert.ToBoolean(oDataReader["bit_Sexo"]);
                    oENUsuario.int_Estado = Convert.ToInt32(oDataReader["int_Estado"]);
                    oENUsuario.var_Password = oDataReader["var_Password"].ToString();
                    oENUsuario.dtm_FechaNacimiento = Convert.ToDateTime(oDataReader["dtm_FechaNacimiento"]);
                    oENUsuario.var_DNI = oDataReader["var_DNI"].ToString();
  
                }
                return oENUsuario;
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

        public bool Insertar(ENUsuario oENSociedad)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_Insertar");
                GenericDataAccess.AgregarParametro(oCommand, "@var_Nombre", oENSociedad.var_Nombre, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Apellidos", oENSociedad.var_Apellidos, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Mail", oENSociedad.var_Mail, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@bit_Sexo", oENSociedad.bit_Sexo, TipoParametro.BIT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@int_Estado", oENSociedad.int_Estado, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Password", oENSociedad.var_Password, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@dtm_FechaNacimiento", oENSociedad.dtm_FechaNacimiento, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_DNI", oENSociedad.var_DNI, TipoParametro.STR, Direccion.INPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        public bool Actualizar(ENUsuario oENSociedad)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_Actualizar");
                GenericDataAccess.AgregarParametro(oCommand, "@int_IdUsuario", oENSociedad.int_IdUsuario, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Nombre", oENSociedad.var_Nombre, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Apellidos", oENSociedad.var_Apellidos, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Mail", oENSociedad.var_Mail, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@bit_Sexo", oENSociedad.bit_Sexo, TipoParametro.BIT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@int_Estado", oENSociedad.int_Estado, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_Password", oENSociedad.var_Password, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@dtm_FechaNacimiento", oENSociedad.dtm_FechaNacimiento, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@var_DNI", oENSociedad.var_DNI, TipoParametro.STR, Direccion.INPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        public bool Eliminar(int Id)
        {
            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "USP_Usuario_Eliminar");
                GenericDataAccess.AgregarParametro(oCommand, "@int_IdUsuario", Id, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@int_Estado", 2, TipoParametro.INT, Direccion.INPUT);
                if (GenericDataAccess.ExecuteNonQuery(oCommand) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new ManejoExcepciones(ex);
            }
            finally
            {
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
    }
}
