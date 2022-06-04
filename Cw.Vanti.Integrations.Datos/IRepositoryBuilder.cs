//-----------------------------------------------------------------------
// <copyright file="IRepositoryBuilder.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>3/7/2019 4:12:18 PM</date>
// <summary>Código fuente clase IRepositoryBuilder.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    /// <summary>
    /// IRepositoryBuilder inteface.
    /// </summary>
    public interface IRepositoryBuilder
    {
        /// <summary>
        /// Gestiona la construccion del respositorio genérico asociado al tipo dado.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa la entidad gestionada por el repositorio.</typeparam>
        /// <returns>Instancia de <see cref="IRepository{T}"/> que gestiona el tipo dado.</returns>
        IRepository<T> CreateRepository<T>()
            where T : class, new();
    }
}