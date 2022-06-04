//-----------------------------------------------------------------------
// <copyright file="IDatosUow.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>2/20/2019 6:35:00 PM</date>
// <summary>Código fuente clase IDatosUow.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{

    /// <summary>
    /// Define el comportamiento requirido por una unidad de trabajo que engloba
    /// la gestión de los repositorios utilizados en la capa de datos.
    /// </summary>
    public interface IDatosUow : IUnitOfWorkDA, IRepositoryBuilder
    {
        /// <summary>
        /// Gets contexto de la base de datos.
        /// </summary>
        AppDbContext Context { get; }

        /// <summary>
        /// Gets el repositorio que gestiona los datos de transacciones vanti.
        /// </summary>
        // ITransaccionVantiRepository TransaccionVantiRepository { get; }


        /// <summary>
        /// Gets el repositorio que gestiona el repositorio del restaurante
        /// </summary>
        IRestauranteRepository RestauranteRepository { get; }

    }
}