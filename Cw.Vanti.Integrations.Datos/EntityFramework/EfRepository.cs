//-----------------------------------------------------------------------
// <copyright file="EfRepository.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>2/20/2019 2:35:27 PM</date>
// <summary>Código fuente clase EfRepository.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using Cw.Vanti.Integrations.Utils;
    using DbUtils;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Proporciona una implementación básica con EntityFramework del comportamiento definido por
    /// la interface <see cref="IRepository{TEntity}"/>.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el dado
    /// gestionado por el respositorio.</typeparam>
    internal class EfRepository<TEntity> : Repository, IDisposable, IRepository<TEntity>
        where TEntity : class, new()
    {

        #region Attributes

        /// <summary>
        /// Representa la colección de elementos contenidos en el <see cref="DbSet{TEntity}"/>.
        /// </summary>
        private readonly DbSet<TEntity> entidades;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="datosUow">Objeto unit of work.</param>
        public EfRepository(IDatosUow datosUow)
        {
            this.DatosUow = datosUow;
            this.Contexto = datosUow.Context;
            this.entidades = datosUow.Context.Set<TEntity>();
            this.SqlConnection = (SqlConnection)datosUow.Context.Database.GetDbConnection();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets el contexto de la conexion para base de datos.
        /// </summary>
        /// <value>contexto de la base de datos.</value>
        protected AppDbContext Contexto { get; }

        /// <summary>
        /// Gets el acceso a los repositorios de datos.
        /// </summary>
        protected IDatosUow DatosUow
        {
            get; set;
        }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Obtiene todos los elementos de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        public virtual ICollection<TEntity> GetAll()
        {
            try
            {
                return this.entidades.ToList();
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene los datos de la entidad de tipo <see cref="TEntity"/> asociada al id proporcionado.
        /// </summary>
        /// <param name="id">Id de la entidad.</param>
        /// <returns>Instancia de tipo <see cref="TEntity"/> asociada al id dado.</returns>
        public virtual TEntity GetById(int id)
        {
            try
            {
                return this.entidades.Find(id);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona el registro de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será almacenada.</param>
        public virtual void Add(TEntity entity)
        {
            try
            {
                this.entidades.Add(entity);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona lista de registros de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entities">Instancia que será almacenada.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        public virtual void AddRange(List<TEntity> entities)
        {
            try
            {
                this.entidades.AddRange(entities);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la actualización de los datos de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será actualizada.</param>
        public virtual void Update(TEntity entity)
        {
            try
            {
                this.entidades.Attach(entity);
                this.Contexto.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la actualización del estado de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">Id unico de la entidad a gestionar.</param>
        /// <param name="estadoRegistro">Valor del estado que tomara la entidad.</param>
        public TEntity ActiveInactive(int id, string estadoRegistro)
        {
            try
            {
                return this.entidades.Find(id);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Getiona la eliminación de la entidad asociada al id dado de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar.</param>
        public virtual void Delete(int id)
        {
            try
            {
                TEntity entidad = this.GetById(id);

                if (entidad != null)
                {
                    this.Delete(entidad);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la eliminación de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será eliminada.</param>
        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (this.Contexto.Entry(entity).State == EntityState.Detached)
                {
                    this.entidades.Attach(entity);
                }

                this.entidades.Remove(entity);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la eliminación de la entidad de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Lista de instancias que serán eliminadas.</param>
        /// <exception cref="DatosException">Si ocurre un error procesando la solicitud
        /// con la base de datos.</exception>
        public void DeleteRange(List<TEntity> entities)
        {
            try
            {
                this.entidades.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados.
        /// </summary>
        public virtual void SaveChanges()
        {
            try
            {
                int rowsAffected = this.Contexto.SaveChanges();
                if (rowsAffected <= 0)
                {
                    throw new DatosException("No se pudo procesar la solicitud");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados de manera asincrona.
        /// </summary>
        /// <returns>Succeded si el guardado fue exitoso.</returns>
        public virtual async Task SaveChangesAsync()
        {
            try
            {
                int rowsAffected = await this.Contexto.SaveChangesAsync();
                if (rowsAffected <= 0)
                {
                    throw new DatosException("No se pudo procesar la solicitud");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo usado para gestionar por condiciones. Es decir parametrizar el Where de cada repositorio.
        /// </summary>
        /// <param name="expression">Expresion de parametros que va a ser procesada.</param>
        /// <returns>Objeto con la respuesta.</returns>
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return this.Contexto.Set<TEntity>().Where(expression).AsQueryable();
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo usado para obtener todos los registros de una entidad.
        /// </summary>
        /// <returns>Lista de objetos de una entidad.</returns>
        public IQueryable<TEntity> FindAll()
        {
            try
            {
                return this.Contexto.Set<TEntity>().AsQueryable().AsNoTracking();
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
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public new IQueryable<T> ExecuteStoreProcedure<T>(StoredProcedure storedProcedure) where T : class, new()
        {
            try
            {
                return this.ExecuteAndGetDataTable<T>(storedProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene una instancia de <see cref="DataTable"/> cuyo contenido
        /// corresponde al resultado de ejecutar el procedimiento de
        /// almacenado especificado con los parámetros proporcionados de manera asincrona.
        /// </summary>
        /// <param name="procedure">Datos del procedimiento de almacenado.</param>
        /// <returns>Instancia de <see cref="DataTable"/> cuyo contenido corresponde
        /// al resultado de la ejecución del procedimiento de almacenado especificado.</returns>
        public async Task<IQueryable<T>> ExecuteStoreProcedureAsync<T>(StoredProcedure storedProcedure) where T : class, new()
        {
            try
            {
                return await this.ExecuteAndGetDataTableAsync<T>(storedProcedure);
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
        /// <param name="procedure">Datos de la funcion.</param>
        /// <returns>Objeto resultado de la operacion</returns>
        public U GetScalar<U>(StoredProcedure storedProcedure)
        {
            try
            {
                return this.ExecuteAndGetScalar<U>(storedProcedure);
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
        /// <param name="procedure">Datos de la funcion.</param>
        /// <returns>Objeto resultado de la operacion</returns>
        public async Task<U> GetScalarAsync<U>(StoredProcedure storedProcedure)
        {
            try
            {
                return await this.ExecuteAndGetScalarAsync<U>(storedProcedure);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gestiona la correcta liberación de los recursos utilizados por <see cref="EfUnitOfWork"/>.
        /// </summary>
        /// <param name="disposing">True para liberar, false en caso contrario.</param>
        protected virtual void Dispose(bool disposing)
        {
            ////Clean up.
        }

        #endregion
    }
}