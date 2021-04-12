using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Data;

namespace AccesoDatos
{

    public enum TipoParametro
    {
        INT,
        STR,
        DT,
        BIT,
        DBL,
        DCL
    }

    public enum Direccion
    {
        INPUT,
        OUTPUT,
        INPUTOUTPUT,
        VALUE
    }

    public sealed class GenericDataAccess
    {

        public GenericDataAccess()
        {

        }
        public String dataProviderName = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ProviderName;
        public String connectionString = ConfigurationManager.ConnectionStrings["PROVEEDOR_ADONET"].ConnectionString;
        public static DbConnection CreateConnection(string dataProviderName, string connectionString)
        {
            // Obtain the database provider name 
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            // Obtain a database specific connection object 
            DbConnection conn = factory.CreateConnection();
            // Set the connection string 
            conn.ConnectionString = connectionString;
            return conn;
        }
        public static DbCommand CreateCommand(string dataProviderName, string connectionString)
        {
            // Create a new data provider factory 
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            DbCommand comm = null/* TODO Change to default(_) if this is not a reference type */;
            // Obtain a database specific connection object 
            DbConnection conn = factory.CreateConnection();
            // Set the connection string 
            conn.ConnectionString = connectionString;
            // Create a database specific command object 
            comm = conn.CreateCommand();
            // Return the initialized command object 
            return comm;
        }

        public static DbCommand CreateCommand(string dataProviderName, string connectionString, string storedProcedure)
        {

            // Create a new data provider factory 
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            DbCommand comm = null/* TODO Change to default(_) if this is not a reference type */;
            // Obtain a database specific connection object 
            DbConnection conn = factory.CreateConnection();
            // Set the connection string 
            conn.ConnectionString = connectionString;
            // Create a database specific command object 
            comm = conn.CreateCommand();
            // Set the command type to stored procedure 
            comm.CommandType = CommandType.StoredProcedure;
            // Set the name of the stored procedure
            comm.CommandText = storedProcedure;
            // Return the initialized command object 
            return comm;
        }


        // Obtain the database provider name 
        public static void CommitTransaction(DbTransaction transaction)
        {
            if (transaction != null && transaction.Connection != null && transaction.Connection.State.Equals(ConnectionState.Open))    /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
            {
                if (transaction != null && transaction.Connection != null && transaction.Connection.State.Equals(ConnectionState.Open))
                    // Commit. 
                    transaction.Commit();
            }
        }
        public static void RollbackTransaction(DbTransaction transaction)
        {
            if (transaction != null && transaction.Connection != null && transaction.Connection.State.Equals(ConnectionState.Open))
                // Rollback. 
                transaction.Rollback();
        }

        public static void SetStoredProcedure(DbCommand command, string storedProcedure)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedure;
        }
        public static void ClearParameters(DbCommand command)
        {
            command.Parameters.Clear();
        }


        public static void AgregarParametro(DbCommand command, string parameterName, object parameterValue, TipoParametro parameterType, Direccion direction)
        {
            // create a new parameter
            DbParameter param = command.CreateParameter();
            param.ParameterName = parameterName;
            param.Value = parameterValue;
            switch (parameterType.ToString().Trim().ToUpper())
            {
                case "INT":
                    {
                        param.DbType = DbType.Int32;
                        break;
                    }
                case "STR":
                    {
                        param.DbType = DbType.String;
                        break;
                    }
                case "DT":
                    {
                        param.DbType = DbType.DateTime;
                        break;
                    }
                case "BIT":
                    {
                        param.DbType = DbType.Byte;
                        break;
                    }

                case "DBL":
                    {
                        param.DbType = DbType.Double;
                        break;
                    }

                case "DCL":
                    {
                        param.DbType = DbType.Decimal;
                        break;
                    }
            }

            switch (direction.ToString().Trim().ToUpper())
            {
                case "INPUT":
                    {
                        param.Direction = ParameterDirection.Input;
                        break;
                    }

                case "OUTPUT":
                    {
                        param.Direction = ParameterDirection.Output;
                        break;
                    }

                case "INPUTOUTPUT":
                    {
                        param.Direction = ParameterDirection.InputOutput;
                        break;
                    }

                case "VALUE":
                    {
                        param.Direction = ParameterDirection.ReturnValue;
                        break;
                    }
            }

            command.Parameters.Add(param);
        }

        public static DbDataReader ExecuteReader(DbCommand command)
        {
            // Execute the command making sure the connection gets closed if an error occurred
            try
            {
                // Open the connection of the command 
                command.Connection.Open();
                // Execute the command and get the number of affected rows 
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them 
                // Utilitarios.LogError(ex)
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                throw ex;
            }
            finally
            {
            }
        }

        // execute a select command and return a single result as a string 
        public static string ExecuteScalar(DbCommand command, bool useTransaction = false)
        {
            // The value to be returned 
            string value = "";
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                if (useTransaction == false)
                    // Open the connection of the command 
                    command.Connection.Open();

                // Execute the command and get the number of affected rows 
                value = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them 
                // Utilities.LogError(ex)
                throw ex;
            }
            finally
            {
                if (useTransaction == false)
                    // Close the connection 
                    command.Connection.Close();
            }
            // return the result 
            return value;
        }
        public static int ExecuteNonQuery(DbCommand command, bool useTransaction = false)
        {
            // The number of affected rows 
            int affectedRows = -1;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                if (useTransaction == false)
                    // Open the connection of the command 
                    command.Connection.Open();
                // Execute the command and get the number of affected rows 
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them 
                // Utilitarios.LogError(ex)
                throw ex;
            }
            finally
            {
                if (useTransaction == false)
                    // Close the connection 
                    command.Connection.Close();
            }
            // return the number of affected rows 
            return affectedRows;
        }

        public static DataSet ExecuteSelectCommand(DbCommand command, string[] tables)
        {
            // The DataTable to be returned 
            DataSet oDataSet;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                // Open the data connection 
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                DbDataReader reader = command.ExecuteReader();
                oDataSet = new DataSet();
                oDataSet.Load(reader, LoadOption.OverwriteChanges, tables);
                // Close the reader 
                reader.Close();
            }
            catch (Exception ex)
            {
                // Utilities.LogError(ex)
                throw ex;
            }
            finally
            {
                // Close the connection 
                command.Connection.Close();
            }
            return oDataSet;
        }

        public static void CerrarConexion(DbCommand command, DbTransaction transaction)
        {
            if (transaction != null && transaction.Connection != null && transaction.Connection.State.Equals(ConnectionState.Open))
                transaction.Connection.Close();
            if (command != null && command.Connection != null && command.Connection.State.Equals(ConnectionState.Open))
                command.Connection.Close();
            transaction = null/* TODO Change to default(_) if this is not a reference type */;
            command = null/* TODO Change to default(_) if this is not a reference type */;
        }

    }
}
