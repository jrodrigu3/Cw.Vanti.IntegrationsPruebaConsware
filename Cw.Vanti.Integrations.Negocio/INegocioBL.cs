//----------------------------------------------------
// <copyright file="INegocioBL.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase INegocioBL.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Negocio
{
    using Cw.Vanti.Integrations.DtoModel;

    /// <summary>
    /// Define el comportamiento esperado por los repositorios que
    /// gestionan datos de la base de datos.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el dato
    /// gestionado por el respositorio.</typeparam>
    public interface INegocioBL<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Metodo para crear un objeto de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será almacenada.</param>
        /// <param name="usuarioAutenticado">Usuario que realiza la creacion del objeto</param>
        /// <returns>Entidad con la respuesta.</returns>
        TEntity CrearBL(TEntity entity, UsuarioAutenticado usuarioAutenticado);

        /// <summary>
        /// Metodo para editar un objeto de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será almacenada.</param>
        /// <param name="usuarioAutenticado">Usuario que realiza la creacion del objeto</param>
        /// <returns>Entidad con la respuesta.</returns>
        TEntity EditarBL(TEntity entity, UsuarioAutenticado usuarioAutenticado);

        /// <summary>
        /// Metodo para activar o inactivar un objeto de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">Instancia que será almacenada.</param>
        /// <param name="usuarioAutenticado">Usuario que realiza la creacion del objeto</param>
        /// <returns>Entidad con la respuesta.</returns>
        TEntity ActivarInactivarBL(int Id, string estadoRegistro, string observacionEstado, UsuarioAutenticado usuarioAutenticado);

        /// <summary>
        /// Metodo para obtener una entidad por Id especifico de tipo <see cref="TEntity"/>.
        /// </summary>
        /// <param name="Id">Id unico de la entidad a ser buscada.</param>
        /// <returns>Entidad con la respuesta.</returns>
        TEntity ObtenerPorIdBL(int Id, UsuarioAutenticado usuarioAutenticado);

    }
}
