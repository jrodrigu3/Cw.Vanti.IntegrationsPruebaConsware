//----------------------------------------------------
// <copyright file="ComidaDto.cs" company="Consware">
//  All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04-06-2022</date>
// <summary>Definición de atributos para la clase ComidaDto.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Entidades
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase utilizada para definir propiedades de la tabla chinos platos
    /// </summary>
    public class Plato
    {
        #region Attributes

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Plato"/> class.
        /// </summary>
        public Plato()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Get or set IdPlato
        /// </summary>
        /// <value>IdPlato.</value>
        [Key]
        public int IdPlato { get; set; }

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
