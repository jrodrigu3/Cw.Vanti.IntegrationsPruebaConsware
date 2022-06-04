//----------------------------------------------------
// <copyright file="HeaderDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Angie Arrieta</author>
// <date>11-10-2021</date>
// <summary>Definición de atributos para la clase HeaderDto.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// HeaderDto class define las propiedades de header para las peticiones http
    /// </summary>
    public class HeaderDto
    {
        /// <summary>
        /// Get or Set del token actual del usuario
        /// </summary>
        public string CurrentToken { get; set; }

        /// <summary>
        /// Get or Set del id pagina 
        /// </summary>
        public string IdPagina { get; set; }

        /// <summary>
        /// Get or Set del id permiso
        /// </summary>
        public string IdPermiso { get; set; }
    }
}
