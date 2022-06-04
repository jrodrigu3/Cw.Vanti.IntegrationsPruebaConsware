//-----------------------------------------------------------------------
// <copyright file="IUsuarioIdentityBL.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>4/1/2019 9:17:19 AM</date>
// <summary>Código fuente clase IUsuarioIdentityBL.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Negocio
{
    using Cw.Vanti.Integrations.DtoModel;
    using System.Security.Claims;

    /// <summary>
    /// Se define la estructura base de la logica de negocio
    /// que representa un usuario.
    /// </summary>
    public interface IUsuarioBL
    {
        /// <summary>
        /// Metodo usado para validar la vigencia del token.
        /// </summary>
        /// <param name="jwt">Token que va a ser validado.</param>
        /// <param name="idUsuario">Parametros de autenticacion del usuario que intenta acceder.</param>
        /// <returns>True sí el token es valido, false sí no es valido.</returns>
        ClaimsPrincipal ValidarToken(string jwt, int idUsuario = 0);

        /// <summary>
        /// Metodo usado para actualizar el token.
        /// </summary>
        /// <param name="token">Objeto que contiene la informacion del token.</param>
        /// <returns>True sí se guardó.</returns>
        bool ActualizarJwr(Token token);
    }
}