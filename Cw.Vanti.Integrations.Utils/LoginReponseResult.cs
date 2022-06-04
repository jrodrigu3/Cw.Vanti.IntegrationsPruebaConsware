//----------------------------------------------------
// <copyright file="LoginReponseResult.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase LoginReponseResult.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    /// <summary>
    /// LoginReponseResult class.
    /// </summary>
    public class LoginReponseResult
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginReponseResult"/> class.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta. </param>
        /// <param name="message">Establece el mensaje de la respuesta. </param>
        /// <param name="data">Establece los datos de la respuesta. </param>
        /// <param name="isCaptcha">Establece si se debe enviar el captcha.</param>
        /// <param name="isExpired">Establece si la contraseña ha expirado.</param>
        public LoginReponseResult(bool status, object message, object data, bool isCaptcha = false, bool isExpired = false)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
            this.IsCaptcha = isCaptcha;
            this.IsExpired = isExpired;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets estable el mensaje de la respuesta.
        /// </summary>
        /// <value>Mensaje repuesta.</value>
        public object Message { get; }

        /// <summary>
        /// Gets a value indicating whether que Establece el estado de la respuesta.
        /// </summary>
        /// <value>Estado resultado de la operacion.</value>
        public bool Status { get; }

        /// <summary>
        /// Gets Establece los datos de la respuesta.
        /// </summary>
        /// <value>Datos retornados como resultado de la operacion.</value>
        public object Data { get; }

        /// <summary>
        /// Gets Establece si se debe enviar el captcha.
        /// </summary>
        /// <value>True si se debe enviar el captcha. false si nó.</value>
        public bool IsCaptcha { get; }

        /// <summary>
        /// Gets Establece si la contraseña ha expirado.
        /// </summary>
        /// <value>True si si la contraseña ha expiró. false si nó.</value>
        public bool IsExpired { get; }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Crea la respuesta del controllador para establecer un error en el mensaje.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static LoginReponseResult CreateError(object message)
        {
            return LoginReponseResult.CreateError(message, null);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer un error en el mensaje con datos.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <param name="data">Datos de repuesta para establecer el error.</param>
        /// <param name="isCaptcha">Establece si se debe enviar el captcha.</param>
        /// <param name="isExpired">Establece si la contraseña ha expirado.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static LoginReponseResult CreateError(object message, object data, bool isCaptcha = false, bool isExpired = false)
        {
            return LoginReponseResult.CreateResponse(false, message, data, isCaptcha, isExpired);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer una respuesta dado el mensaje los datos y su estado.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta.</param>
        /// <param name="message">Establece el mensaje de la respuesta</param>
        /// <param name="data">Establece los datos de la respuesta</param>
        /// <param name="isCaptcha">Establece si se debe enviar el captcha.</param>
        /// <param name="isExpired">Establece si la contraseña ha expirado.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static LoginReponseResult CreateResponse(bool status, object message, object data, bool isCaptcha, bool isExpired)
        {
            return new LoginReponseResult(status, message, data ?? new object[0], isCaptcha, isExpired);
        }

        #endregion
    }
}