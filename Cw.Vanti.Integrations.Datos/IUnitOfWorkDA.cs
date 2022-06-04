//-----------------------------------------------------------------------
// <copyright file="IUnitOfWorkDA.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>3/7/2019 3:22:14 PM</date>
// <summary>Código fuente clase IUnitOfWorkDA.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using System.Threading.Tasks;

    /// <summary>
    /// Define el comportamiento requerido por el patro unidad de trabajo, enfocado
    /// a modelo de datos.
    /// </summary>
    public interface IUnitOfWorkDA
    {
        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados de manera asincrona.
        /// </summary>
        /// <returns>Succeded si el guardado fue exitoso.</returns>
        Task SaveChangesAsync();
    }
}