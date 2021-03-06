﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiTU_CS.Entity
{
    abstract class BaseEntity: IDisposable
    {
        #region Variables

        private bool disposed = false;
        public string SQL = string.Empty;
        public MySqlConnection Connection;
        public MySqlCommand Command;
        public MySqlDataAdapter DataAdapter;
        public MySqlDataReader DataReader;

        #endregion

        #region Methods

        /// <summary>
        /// Adds a parameter to the parameteres collection of the command object
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="Size"></param>
        /// <param name="Value"></param>
        public void AddParameter(string Name, MySqlDbType Type, int Size, object Value)
        {
            try
            {
                Command.Parameters.Add(Name, Type, Size).Value = Value;
                Command.Parameters[Name].Direction = ParameterDirection.Input;
            }
            catch(MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Closes the connection to the MySQL server
        /// </summary>
        public void CloseConnection()
        {
            Connection.Close();
            MySqlConnection.ClearAllPools();

        }

        /// <summary>
        /// Executes a stored procedure based on the name in the SQL object
        /// </summary>
        /// <returns>The number of rows affected by the stored procedure</returns>
        public int ExecuteStoredProcedure()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    OpenConnection();

                return Command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
            }
        }

        /// <summary>
        /// Fills a dataset object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        public void FillDataSet(DataSet oDataSet)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataSet);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
            }
        }

        /// <summary>
        /// Fills a dataset object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        public void FillDataSet(DataSet oDataSet, string TableName)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataSet, TableName);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
            }
        }

        /// <summary>
        /// Fills a datatable object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        public void FillDataTable(DataTable oDataTable)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataTable);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
            }
        }

        /// <summary>
        /// Gets the name of the database to use based on the current mode of the application
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Initializes the data adapter object
        /// </summary>
        public void InitializeAdapter()
        {
            try
            {
                DataAdapter = new MySqlDataAdapter(Command);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Creates a new command based on the SQL statement and connection string provided
        /// </summary>
        public void InitializeCommand()
        {
            if (true)
            {
                try
                {
                    Command = new MySqlCommand(SQL, Connection);

                    if (!SQL.ToUpper().StartsWith("SELECT ") && 
                        !SQL.ToUpper().StartsWith("INSERT ") &&
                        !SQL.ToUpper().StartsWith("UPDATE ") && 
                        !SQL.ToUpper().StartsWith("DELETE "))
                        Command.CommandType = CommandType.StoredProcedure;
                }
                catch (MySqlException e)
                {
                    throw new System.Exception(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Opens a connection to the MySQL server based on the connection string provided
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e1)
            {
                throw new System.Exception(e1.Message, e1.InnerException);
            }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// sets up connection to database
        /// </summary>
        public BaseEntity()
        {
            Connection = new MySqlConnection(
                "server=97.74.31.73;" +
                "Uid=jituasu;" +
                "Pwd=eap3THui;" +
                "database=jituasu;" +
                "Pooling=False");
            OpenConnection();
        }

        ~BaseEntity()
        {
            CloseConnection();
            Dispose(false);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this.DataAdapter != null)
            {
                this.DataAdapter.Dispose();
                this.DataAdapter = null;
            }
            if (this.Command != null)
            {
                Command.Dispose();
                Command = null;
            }
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
            }

            disposed = true;
        }

        #endregion

    }
}
