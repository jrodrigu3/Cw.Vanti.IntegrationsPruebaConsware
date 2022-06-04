//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>9/26/2019 9:51:35 AM</date>
// <summary>Código fuente clase Repository.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Cw.Vanti.Integrations.Datos.DbUtils;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// Repository class.
    /// </summary>
    internal class Repository
    {
        #region Attributes

        /// <summary>
        /// Objeto usado para llamar a procedimientos almacenados.
        /// </summary>
        private SqlServerDbHandler sqlServerDbHandler;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Cadena de conexion a la base de datos.
        /// </summary>
        /// <value>Cadena de conexion a la base de datos.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets el contexto de la conexion para base de datos.
        /// </summary>
        /// <value>contexto de la base de datos.</value>
        public SqlConnection SqlConnection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Objeto usado para llamar a
        /// procedimientos almacenados.
        /// </summary>
		/// <value></value>
        public SqlServerDbHandler SqlServerDbHandler
        {
            get
            {
                if (this.sqlServerDbHandler == null)
                {
                    this.sqlServerDbHandler = new SqlServerDbHandler(this.SqlConnection);
                }

                return sqlServerDbHandler;
            }
        }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public IQueryable<T> ExecuteStoreProcedure<T>(StoredProcedure storedProcedure) where T : class, new()
        {
            try
            {
                return this.ExecuteAndGetDataTable<T>(storedProcedure);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        protected IQueryable<T> ExecuteAndGetDataTable<T>(StoredProcedure storedProcedure) where T : class, new()
        {
            try
            {
                DataTable data = this.SqlServerDbHandler.ExecuteAndGetDataTable(storedProcedure);
                ICollection<T> lista = DbUtil.LoadData<T>(data);
                return lista?.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados de manera
        /// asincrona.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        protected async Task<IQueryable<T>> ExecuteAndGetDataTableAsync<T>(StoredProcedure storedProcedure) where T : class, new()
        {
            try
            {
                DataTable data = await this.SqlServerDbHandler.ExecuteAndGetDataTableAsync(storedProcedure);
                ICollection<T> lista = DbUtil.LoadData<T>(data);
                return lista?.AsQueryable();
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene un resultado de ejecutar la funcion especificada
        /// con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos de la funcion.</param>
        /// <returns>Objeto resultado de la operacion</returns>
        protected U ExecuteAndGetScalar<U>(StoredProcedure storedProcedure)
        {
            try
            {
                return this.SqlServerDbHandler.ExecuteAndGetScalar<U>(storedProcedure);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene un resultado de ejecutar la funcion especificada
        /// con los parámetros proporcionados de manera asincrona.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos de la funcion.</param>
        /// <returns>Objeto resultado de la operacion</returns>
        protected async Task<U> ExecuteAndGetScalarAsync<U>(StoredProcedure storedProcedure)
        {
            try
            {
                return await this.SqlServerDbHandler.ExecuteAndGetScalarAsync<U>(storedProcedure);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        protected DataSet ExecuteAndGetDataSet(StoredProcedure storedProcedure)
        {
            try
            {
                return this.SqlServerDbHandler.ExecuteAndGetDataSet(storedProcedure);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        #endregion
    }
}