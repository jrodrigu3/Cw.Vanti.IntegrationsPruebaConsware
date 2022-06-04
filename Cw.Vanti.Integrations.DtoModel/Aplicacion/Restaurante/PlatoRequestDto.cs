//----------------------------------------------------
// <copyright file="PlatoRequestDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04/06/2022</date>
// <summary>Definición de atributos para la clase PlatoRequestDto.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{

    /// <summary>
    /// Clase encargada de definir el objeto de transferencia de un plato
    /// </summary>
    public class PlatoRequestDto 
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatoRequestDto"/> class.
        /// </summary>
        public PlatoRequestDto()
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
