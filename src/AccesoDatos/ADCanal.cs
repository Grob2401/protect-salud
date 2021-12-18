﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADCanal
    {

        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;

        public int Cantidad(string sociedad)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "usp_GenCanales_count");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode ", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                int cantidadCanales = -1;
                if (oDataReader.Read() && !int.TryParse(oDataReader["Canales"].ToString(), out cantidadCanales)) cantidadCanales = -1;
                return cantidadCanales;
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

        public List<ENCanales> ObtenerTodos(string sociedad)
        {
            DbCommand oCommand = null;
            List<ENCanales> oListaCanales = new List<ENCanales>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad ", sociedad == null ? "" : sociedad, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCanales oEnListaCanales = new ENCanales();
                    oEnListaCanales.IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oEnListaCanales.DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oEnListaCanales.Comision_Tipo_Descripcion = oDataReader["Comision_Tipo"].ToString(); 
                    oEnListaCanales.Comision_Cantidad = Convert.ToInt32(oDataReader["Comision_Cantidad"]);
                    oListaCanales.Add(oEnListaCanales);

    }
                return oListaCanales;
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

        public List<ENCanales> ObtenerTodos(int page, int rows, string type, string Keywords, string sociedad)
        {
            DbCommand oCommand = null;
            List<ENCanales> oListaCanales = new List<ENCanales>();
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_SEL_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@page", page, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@rowsPerPage", rows, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@type", type, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@keywords", Keywords, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@IdSociedad", sociedad == null ? "" : sociedad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argErrorCode", 1, TipoParametro.INT, Direccion.OUTPUT);
                DbDataReader oDataReader = GenericDataAccess.ExecuteReader(oCommand);
                while (oDataReader.Read())
                {
                    ENCanales oEnListaCanales = new ENCanales();
                    oEnListaCanales.IDCanal = Convert.ToInt32(oDataReader["IDCanal"]);
                    oEnListaCanales.DescripcionCanal = oDataReader["DescripcionCanal"].ToString();
                    oEnListaCanales.Comision_Tipo_Descripcion = oDataReader["Comision_Tipo"].ToString();
                    oEnListaCanales.Comision_Cantidad = Convert.ToInt32(oDataReader["Comision_Cantidad"]);
                    oListaCanales.Add(oEnListaCanales);

                }
                return oListaCanales;
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

        public bool Insertar(ENCanales oENCanal)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_INS_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCanal", oENCanal.DescripcionCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDSociedad", oENCanal.IdSociedad, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        
        public bool Actualizar(ENCanales oENCanal)
        {

            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_UPD_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@argIDCanal", oENCanal.IDCanal, TipoParametro.INT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argDescripcionCanal", oENCanal.DescripcionCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIDSociedad", oENCanal.IdSociedad, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        
        public bool Eliminar(int IdCanal)
        {
            DbCommand oCommand = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_DEL_MANTENIMIENTO_CANALES");
                GenericDataAccess.AgregarParametro(oCommand, "@argIdCanal", IdCanal, TipoParametro.INT, Direccion.INPUT);
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
                GenericDataAccess.CerrarConexion(oCommand, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }

        public bool InsertarComision(ENCanales oENCanalComision)
        {
            DbCommand oCommand = null;
            try
            {
                oCommand = GenericDataAccess.CreateCommand(dataProviderName, connectionString, "VENTAS.USP_INS_MANTENIMIENTO_CANAL_COMISION");
                GenericDataAccess.AgregarParametro(oCommand, "@argValorComision", oENCanalComision.Comision_Cantidad, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaInicio", oENCanalComision.Comision_fechaInicio, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argFechaFin", oENCanalComision.Comision_FechaFin, TipoParametro.DT, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argCodigoCanal", oENCanalComision.Comision_IDCanal, TipoParametro.STR, Direccion.INPUT);
                GenericDataAccess.AgregarParametro(oCommand, "@argIdTipoComision", oENCanalComision.Comision_Idtipo, TipoParametro.STR, Direccion.INPUT);
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
