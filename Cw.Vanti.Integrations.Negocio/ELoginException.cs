//-----------------------------------------------------------------------
// <copyright file="ELoginException.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>5/3/2019 11:51:19 AM</date>
// <summary>Código fuente clase ELoginException.</summary>
//-----------------------------------------------------------------------
namespace Cw.GasData.ControlCarga.Negocio
{
    using System;

    /// <summary>
    /// Enum de login para identificar el fallo de esta
    /// operacion.
    /// </summary>
    [Serializable]
    public enum ELoginException
    {
        /// <summary>
        /// Identifica que el usuario esta bloqueado.
        /// </summary>
        UsuarioBloqueado,

        /// <summary>
        /// Identifica que la contraseña es incorrecta.
        /// </summary>
        ContraseñaInvalida,

        /// <summary>
        /// Identifica el maximo de intentos para mostrar captcha.
        /// </summary>
        MaxIntentosCaptcha,

        /// <summary>
        /// Identifica que la contraseña ya expiró.
        /// </summary>
        ContraseñaExpiro,

        /// <summary>
        /// Identifica cuando el usuario se encuentra inactivo.
        /// </summary>
        UsuarioInactivo,

        /// <summary>
        /// Identifica cuando el usuario ya se encuentra autenticado.
        /// </summary>
        UsuarioAutenticado,

        /// <summary>
        /// Es usado para obviar las anteriores y solo mostrar el error.
        /// </summary>
        Ninguno
    }
}