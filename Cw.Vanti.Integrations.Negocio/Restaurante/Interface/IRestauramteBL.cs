
//-----------------------------------------------------------------------
// <copyright file="IRestauramteBL.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04-06-2022</date>
// <summary>Código fuente clase IRestauramteBL.</summary>
//-----------------------------------------------------------------------


namespace Cw.Vanti.Integrations.Negocio
{
    using Cw.Vanti.Integrations.DtoModel;
    /// <summary>
    /// IRestauramteBL interface.
    /// </summary>
    public interface IRestauramteBL
    {
        /// <summary>
        /// Método para la creacion de un nuevo plato
        /// </summary>
        /// <param name="plato">Entidad a ser creada</param>
        /// <returns></returns>
        PlatoResponseDto CrearPlatoBL(PlatoRequestDto plato);

        /// <summary>
        /// Metodo para editar un plato especifico
        /// </summary>
        /// <param name="platoRequestEdit">Objeto con la informacion de un plato que desea ser editada</param>
        /// <returns>PlatoResponseDto</returns>
        public PlatoResponseDto EditarPlatoBL(PlatoRequestDto platoRequestEdit);

        /// <summary>
        /// Metodo para buscar una encuesta por id especifico
        /// </summary>
        /// <param name="idPlato">Id unico del plato que esta siendo consultada</param>
        /// <returns>Objeto con la informacion del prestamo</returns>
        public PlatoResponseDto ObtenerPlatoPorIdBL(int idPlato);

    }
}
