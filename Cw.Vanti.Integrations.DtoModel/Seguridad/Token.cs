//----------------------------------------------------
// <copyright file="Token.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase Token.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Se define la estructura base que representa los Token generados a los usuarios
    /// que se autentican en el api.
    /// </summary>
    public class Token
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        public Token()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets el id del token.
        /// </summary>
        /// <value>Id del token.</value>
        public int TokenId { get; set; }

        /// <summary>
        /// Gets or sets nombre del usuario.
        /// </summary>
        /// <value>Nombre del usuario.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value el GUID del token para refrescarlo.
        /// </summary>
        /// <value>GUID del token para refrescarlo.</value>
        public string RefreshTokenGUID { get; set; }

        /// <summary>
        /// Gets or sets la fecha de creacion del token.
        /// </summary>
        /// <value>Fecha de creacion del token.</value>
        public string FechaCreacion { get; set; }

        /// <summary>
        /// Gets or sets la fecha de modificacion del token.
        /// </summary>
        /// <value>Fecha de modificacion del token.</value>
        public string FechaModificacion { get; set; }

        /// <summary>
        /// Gets or sets el token generado para un usuario.
        /// </summary>
        /// <value>Token generado para un usuario.</value>
        public string TokenUsuario { get; set; }

        /// <summary>
        /// Gets or sets si el token ha sido revocado o no.
        /// </summary>
        /// <value>True, si el token fué revocado.</value>
        public bool IsRevoked { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}