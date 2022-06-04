//----------------------------------------------------
// <copyright file="ResponseResult.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ResponseResult.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Utils
{
    /// <summary>
    /// Gets la estructura de las respuesta para los controller.
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult"/> class.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta. </param>
        /// <param name="message">Establece el mensaje de la respuesta. </param>
        /// <param name="data">Establece los datos de la respuesta. </param>
        public ResponseResult(bool status, object message, object data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

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
        /// Crea la respuesta del controllador para establecer un error en el mensaje.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResult CreateError(object message)
        {
            return ResponseResult.CreateError(message, null);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer un error en el mensaje con datos.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <param name="data">Datos de repuesta para establecer el error.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResult CreateError(object message, object data)
        {
            return ResponseResult.CreateResponse(false, message, data);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer una respuesta dado el mensaje los datos y su estado.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta.</param>
        /// <param name="message">Establece el mensaje de la respuesta</param>
        /// <param name="data">Establece los datos de la respuesta</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResult CreateResponse(bool status, object message, object data)
        {
            return new ResponseResult(status, message, data ?? (new object()));
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer una respuesta dado el mensaje los datos y su estado.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta.</param>
        /// <param name="message">Establece el mensaje de la respuesta</param>
        /// <param name="data">Establece los datos de la respuesta</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResult CreateResponseList(bool status, object message, object data)
        {
            return new ResponseResult(status, message, data ?? (new object[0]));
        }
    }
}
