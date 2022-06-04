//----------------------------------------------------
// <copyright file="RestauranteResponseDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04/06/2022</date>
// <summary>Definición de atributos para la clase RestauranteResponseDto.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{

    /// <summary>
    /// Clase encargada de definir el objeto de transferencia de salida un plato
    /// </summary>
    public class PlatoResponseDto
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatoResponseDto"/> class.
        /// </summary>
        public PlatoResponseDto()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get or set IdPlato
        /// </summary>
        /// <value>IdPlato.</value>
        public int? IdPlato { get; set; }

        /// <summary>
        /// Get or set NombrePlato
        /// </summary>
        /// <value>NombrePlato.</value>
        public string NombrePlato { get; set; }


        #endregion

        #region Methods And Functionss

        #endregion
    }
}
