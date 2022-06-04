//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>2/20/2019 2:18:03 PM</date>
// <summary>Código fuente clase IRepository.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Define el comportamiento esperado por los repositorios que
    /// gestionan datos de la base de datos.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el dato
    /// gestionado por el respositorio.</typeparam>
    public interface IRepository<TEntity> : IUnitOfWorkDA
        where TEntity : class, new()
    {
        /// <summary>
        /// Obtiene todos los elementos de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        ICollection<TEntity> GetAll();

        /// <summary>
        /// Obtiene los datos de la entidad de tipo <see cref="TEntity"/> asociada al id proporcionado.
        /// </summary>
        /// <param name="id">Id de la entidad.</param>
        /// <returns>Instancia de tipo <see cref="TEntity"/> asociada al id dado.</returns>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        TEntity GetById(int id);

        /// <summary>
        /// Gestiona el registro de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será almacenada.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void Add(TEntity entity);

        /// <summary>
        /// Gestiona lista de registros de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entities">Instancia que será almacenada.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void AddRange(List<TEntity> entities);

        /// <summary>
        /// Gestiona la actualización de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será actualizada.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void Update(TEntity entity);

        /// <summary>
        /// Gestiona la activacion o inactivacion de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">Id del objeto que se va a modificar.</param>
        /// <exception cref="estadoRegistro">Estado que va a ser mguardadoguardado.</exception>
        TEntity ActiveInactive(int id, string estadoRegistro);

        /// <summary>
        /// Getiona la eliminación de la entidad asociada al id dado de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void Delete(int id);

        /// <summary>
        /// Gestiona la eliminación de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será eliminada.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void Delete(TEntity entity);

        /// <summary>
        /// Gestiona la eliminación de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Lista de instancias que serán eliminadas.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        void DeleteRange(List<TEntity> entities);

        /// <summary>
        /// Metodo usado para obtener todos los registros de una entidad.
        /// </summary>
        /// <returns>Lista de objetos de una entidad.</returns>
        IQueryable<TEntity> FindAll();

        /// <summary>
        /// Metodo usado para gestionar por condiciones. Es decir parametrizar el Where de cada repositorio.
        /// </summary>
        /// <param name="expression">Expresion de parametros que va a ser procesada.</param>
        /// <returns>Objeto con la respuesta.</returns>
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    }
}