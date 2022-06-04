//----------------------------------------------------
// <copyright file="PasswordPolicyDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase PasswordPolicyDto.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Este objeto representa la estructura de las politicas de la contraseña.
    /// </summary>
    public class PasswordPolicyDto
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordPolicyDto"/> class.
        /// </summary>
        public PasswordPolicyDto()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Id de la politica.
        /// </summary>
        /// <value>Id de la politica.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Nombre de la politica.
        /// </summary>
        /// <value>Nombre de la politica.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Estado de la politica.
        /// </summary>
        /// <value>Estado de la politica.</value>
        public bool Estado { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}