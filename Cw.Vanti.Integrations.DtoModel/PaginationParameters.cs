//----------------------------------------------------
// <copyright file="PaginationParameters.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase PaginationParameters.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Clase usada como respuesta a una paginación.
    /// </summary>
    public class PaginationParameters
    {
        #region Attributes

        #endregion

        #region Constructors

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Total de registros.
        /// </summary>
        /// <value>Id de la marca.</value>
        public int TotalElements { get; set; }

        /// <summary>
        /// Gets or sets Limite de registros en una página.
        /// </summary>
        /// <value>Id de la linea.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets Página actual.
        /// </summary>
        /// <value> Página actual.</value>
        public int PageNumber { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}
