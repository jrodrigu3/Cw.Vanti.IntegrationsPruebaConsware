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
    public class JwtTokenConfig
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenConfig"/> class.
        /// </summary>
        public JwtTokenConfig()
        {
        }

        #endregion

        #region Properties

        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}