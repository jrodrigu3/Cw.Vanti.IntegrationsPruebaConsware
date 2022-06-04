//-----------------------------------------------------------------------
// <copyright file="FiltrosQueryHistorialDto.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>kcastillo</author>
// <date>9/24/2021 2:29:46 PM</date>
// <summary>Código fuente clase FiltrosQueryHistorialDto.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Clase que representa el objeto de filtros para un historial.
    /// </summary>
    public class FiltrosQueryHistorialDto : FiltrosQueryParameters
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltrosQueryHistorialDto"/> class.
        /// </summary>
        public FiltrosQueryHistorialDto()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value id del usuario
        /// </summary>
        /// <value></value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets a value Id del registro padre del que queremos ver los historiales
        /// </summary>
        /// <value></value>
        public int IdHistorial { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}