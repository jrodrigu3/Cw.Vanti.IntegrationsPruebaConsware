//-----------------------------------------------------------------------
// <copyright file="ICreditos.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04-06-2022</date>
// <summary>Código fuente clase Comida.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Cw.Vanti.Integrations.DtoModel;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona la implementacion definida para el repositorio
    /// </summary>
    public interface IRestauranteRepository
    {
        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que guardar la entidad <see cref="PlatoResponseDto/>
        /// </summary>
        /// <param name="plato">Entidad a ser creada</param>
        /// <returns>PlatoResponseDto.</returns>
        PlatoResponseDto CrearPlato(PlatoRequestDto plato);

        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que editar un plato <see cref="PlatoResponseDto"/>
        /// </summary>
        /// <param name="plato">Entidad a ser editada</param>
        /// <returns>PlatoResponseDto.</returns>
        PlatoResponseDto EditarPlato(PlatoRequestDto plato);

        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que editar la entidad <see cref="PlatoResponseDto"/>
        /// </summary>
        /// <param name="idPlato">id de la entidad a ser buscada</param>
        /// <returns>PlatoResponseDto.</returns>
        PlatoResponseDto ObtenerPlatoPorId(int? idPlato);

        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que lista los platos <see cref="PlatoResponseDto"/>
        /// </summary>
        /// <returns>PlatoResponseDto.</returns>
        IList<PlatoResponseDto> ObtenerPlatoListado();
    }
}
