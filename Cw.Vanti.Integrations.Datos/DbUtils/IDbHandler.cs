//-----------------------------------------------------------------------
// <copyright file="IDbHandler.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>8/14/2019 10:18:22 AM</date>
// <summary>Código fuente clase IDbHandler.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos.DbUtils
{
    using Microsoft.Data.SqlClient;
    using System.Data;

    /// <summary>
    /// Define el comportamiento de los componentes que gestionan
    /// conexiones y consultas a una base de datos SqlServer.
    /// </summary>
    public interface IDbHandler
    {
        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de
        /// almacenado especificado.</returns>
        DataTable ExecuteAndGetDataTable(string procedure);

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        DataTable ExecuteAndGetDataTable(string procedure, SqlParameter[] parameters);

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        DataTable ExecuteAndGetDataTable(StoredProcedure procedure);

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de
        /// almacenado especificado.</returns>
        DataSet ExecuteAndGetDataSet(string procedure);

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        DataSet ExecuteAndGetDataSet(string procedure, SqlParameter[] parameters);

        /// <summary>
        /// Obtiene una instancia de <see cref="DataSet"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataSet"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        DataSet ExecuteAndGetDataSet(StoredProcedure procedure);

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Número de registros afectados.</returns>
        int ExecuteWithoutRetrieveData(string procedure);

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        int ExecuteWithoutRetrieveData(string procedure, SqlParameter[] parameters);

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con los parámetros proporcionados.
        /// </summary>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        int ExecuteWithoutRetrieveData(StoredProcedure procedure);

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="T"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="T"/>
        /// que se obtiene al procedimiento de almacenado especificado.</returns>
        T ExecuteAndGetScalar<T>(string procedure);

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="T"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado con los
        /// parámetros proporcionado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        /// <param name="parameters">Parámetros del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="T"/>.</returns>
        T ExecuteAndGetScalar<T>(string procedure, SqlParameter[] parameters);

        /// <summary>
        /// Obtiene un valor escalar de tipo <typeparamref name="T"/> como resultado
        /// de la ejecución del procedimiento de almacenado especificado con los
        /// parámetros proporcionado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a obtener de la base de datos.</typeparam>
        /// <param name="procedure">Cw.Vanti.Integrations.Datos del procedimiento de almacenado.</param>
        /// <returns>Valor escalar de tipo <typeparamref name="T"/>.</returns>
        T ExecuteAndGetScalar<T>(StoredProcedure procedure);

        /// <summary>
        /// Obtiene el número de registros afectados por la ejecución
        /// del procedimiento de almacenado especificado con el datatable proporcionado.
        /// </summary>
        /// <param name="tableName">Nombre de tabla a ingresar.</param>
        /// <param name="dataTable">Cw.Vanti.Integrations.Datos a ingresar en la tabla.</param>
        /// <returns>Instancia de DataTable con los datos obtenidos.</returns>
        int ExecuteBulkInsertDataTable(string tableName, DataTable dataTable);
    }
}