//-----------------------------------------------------------------------
// <copyright file="SqlServerDbHandler.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>8/14/2019 10:10:47 AM</date>
// <summary>Código fuente clase SqlServerDbHandler.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos.DbUtils
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;
    using System.Globalization;
    using System.Threading.Tasks;

    /// <summary>
    /// Proporciona la implementación básica y requerida por la
    /// interface <see cref="IDbHandler"/> para el manejo
    /// de conexiones y consultas a una base de datos SqlServer.
    /// </summary>
    public class SqlServerDbHandler : IDbHandler
    {
        #region Attributes

        /// <summary>
        /// Representa la cadena de conexión.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Representa el tiempo (en segundos) maximo en que se espera finalice
        /// la ejecución de una consulta a la base de datos, antes de que
        /// se genere una excepción por tiempo de espera agotado (TimeOut).
        /// </summary>
        private readonly int timeout;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDbHandler"/> class.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        /// <param name="timeout">Tiempo en segundos de espera de respuesta o
        /// finalización de una consulta a al base de datos.</param>
        /// <exception cref="ArgumentException">Cuando la cadena de conexión no es válida.</exception>
        public SqlServerDbHandler(string connectionString, int timeout)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("La cadena de conexión proporcionada no es válida.");
            }

            this.connectionString = connectionString;
            this.timeout = (timeout >= 0) ? timeout : 30;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDbHandler"/> class.
        /// </summary>
        /// <param name="sqlConnection">Objeto de conexion.</param>
        /// <exception cref="ArgumentException">Cuando la cadena de conexión no es válida.</exception>
        public SqlServerDbHandler(SqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets el contexto de la conexion para base de datos.
        /// </summary>
        /// <value>contexto de la base de datos.</value>
        public SqlConnection SqlConnection { get; set; }

        #endregion

        #region Methods And Functionss
        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de
        /// almacenado especificado.</returns>
        public DataTable ExecuteAndGetDataTable(string procedure)
        {
            return this.ExecuteAndGetDataTable(new StoredProcedure(procedure));
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public DataTable ExecuteAndGetDataTable(string procedure, SqlParameter[] parameters)
        {
            return this.ExecuteAndGetDataTable(new StoredProcedure(procedure, parameters));
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public DataTable ExecuteAndGetDataTable(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            DataTable data = null;

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        data = new DataTable
                        {
                            Locale = CultureInfo.InvariantCulture
                        };
                        data.Load(dr);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }


            return data;
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados
        /// de manera asíncrona.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public async Task<DataTable> ExecuteAndGetDataTableAsync(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            DataTable data = null;

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        data = new DataTable
                        {
                            Locale = CultureInfo.InvariantCulture
                        };
                        data.Load(dr);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de
        /// almacenado especificado.</returns>
        public DataSet ExecuteAndGetDataSet(string procedure)
        {
            return this.ExecuteAndGetDataSet(new StoredProcedure(procedure));
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public DataSet ExecuteAndGetDataSet(string procedure, SqlParameter[] parameters)
        {
            return this.ExecuteAndGetDataSet(new StoredProcedure(procedure, parameters));
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public DataSet ExecuteAndGetDataSet(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            DataSet data = null;

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        data = new DataSet
                        {
                            Locale = CultureInfo.InvariantCulture
                        };
                        da.Fill(data);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Número de registros afectados.</returns>
        public int ExecuteWithoutRetrieveData(string procedure)
        {
            return this.ExecuteWithoutRetrieveData(new StoredProcedure(procedure));
        }

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        public int ExecuteWithoutRetrieveData(string procedure, SqlParameter[] parameters)
        {
            return this.ExecuteWithoutRetrieveData(new StoredProcedure(procedure, parameters));
        }

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        public int ExecuteWithoutRetrieveData(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            int ans = 0;

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    ans = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }

            return ans;
        }
        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="U"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado.
        /// </summary>
        /// <typeparam name="U">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="U"/>
        /// que se obtiene al procedimiento de almacenado especificado.</returns>
        public U ExecuteAndGetScalar<U>(string procedure)
        {
            return this.ExecuteAndGetScalar<U>(new StoredProcedure(procedure));
        }

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="U"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado con los
        /// parámetros proporcionado.
        /// </summary>
        /// <typeparam name="U">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="U"/>.</returns>
        public U ExecuteAndGetScalar<U>(string procedure, SqlParameter[] parameters)
        {
            return this.ExecuteAndGetScalar<U>(new StoredProcedure(procedure, parameters));
        }

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="U"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado con los
        /// parámetros proporcionado de manera asíncrona.
        /// </summary>
        /// <typeparam name="U">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="U"/>.</returns>
        public U ExecuteAndGetScalar<U>(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            U data = default(U);

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    cmd.ExecuteNonQuery();

                    object scalar = cmd.Parameters["@RETURN_VALUE"].Value;

                    if (scalar != null && !DBNull.Value.Equals(scalar))
                    {
                        data = (U)Convert.ChangeType(scalar, typeof(U), CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="U"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado con los
        /// parámetros proporcionado.
        /// </summary>
        /// <typeparam name="U">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="U"/>.</returns>
        public async Task<U> ExecuteAndGetScalarAsync<U>(StoredProcedure procedure)
        {
            bool isConnectionByEf = false;
            StoredProcedure.Validate(procedure);
            U data = default(U);

            if (this.SqlConnection.State == ConnectionState.Closed)
            {
                isConnectionByEf = true;
                this.SqlConnection.Open();
            }

            using (SqlCommand cmd = CreateProcedureCommand(this.SqlConnection, procedure, this.SqlConnection.ConnectionTimeout))
            {
                try
                {
                    cmd.CommandTimeout = this.timeout;

                    object scalar = await cmd.ExecuteScalarAsync();

                    if (scalar != null && !DBNull.Value.Equals(scalar))
                    {
                        data = (U)Convert.ChangeType(scalar, typeof(U), CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (isConnectionByEf)
                    {
                        this.SqlConnection.Close();
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con el datatable proporcionado.
        /// </summary>
        /// <param name="tableName">Nombre de tabla a ingresar.</param>
        /// <param name="dataTable">Cw.Vanti.Integrations.Datos a ingresar en la tabla.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        public int ExecuteBulkInsertDataTable(string tableName, DataTable dataTable)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }

            int ans = 0;

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = tableName;

                    try
                    {
                        bulkCopy.WriteToServer(dataTable);
                    }
                    catch (Exception)
                    {
                        CloseConnection(con);
                        throw;
                    }
                }

                CloseConnection(con);
            }

            return ans;
        }

        /// <summary>
        /// Cierra la conexión especificada.
        /// </summary>
        /// <param name="con">Instancia de <see cref="SqlConnection"/> a cerrar.</param>
        private static void CloseConnection(SqlConnection con)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        /// <summary>
        /// Crea la instancia de <see cref="SqlCommand"/> requerida para
        /// ejecuturar el procedimiento de almacenado especificado, junto
        /// con  los parámtros que acompañana la ejecuciónn del mismo.
        /// </summary>
        /// <param name="con">Conexión con la base de datos.</param>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <param name="timeout">Tiempo de espera de ejecución de la consulta.</param>
        /// <param name="isFunction">Parametro que valida si la estructura que va a ser llamada
        /// es una funcion o nó. True si es una funcion, false si es procedimiento.</param>
        /// <returns>Instancia de <see cref="SqlCommand"/> apta para ejecutar
        /// un procedimiento de almacenado.</returns>
        private static SqlCommand CreateProcedureCommand(SqlConnection con, StoredProcedure procedure, int timeout)
        {
            SqlCommand cmd = new SqlCommand(procedure.Name, con)
            {
                CommandTimeout = timeout,
                CommandType = CommandType.StoredProcedure
            };
            procedure.AddParameter("@RETURN_VALUE", new object(), ParameterDirection.ReturnValue);

            if (procedure.Parameters != null && procedure.Parameters.Count > 0)
            {
                foreach (SqlParameter p in procedure.Parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }

            return cmd;
        }

        #endregion
    }
}