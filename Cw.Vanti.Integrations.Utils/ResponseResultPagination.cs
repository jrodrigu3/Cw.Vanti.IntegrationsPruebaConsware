//----------------------------------------------------
// <copyright file="ResponseResultPagination.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ResponseResultPagination.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    /// <summary>
    /// Gets la estructura de las respuesta para los controller.
    /// </summary>
    public class ResponseResultPagination : ResponseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResultPagination"/> class.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta. </param>
        /// <param name="message">Establece el mensaje de la respuesta. </param>
        /// <param name="data">Establece los datos de la respuesta. </param>
        /// <param name="meta">Establece los meta de la respuesta. </param>
        public ResponseResultPagination(bool status, object message, object data, object meta) : base(status, message, data)
        {
            this.Meta = meta;
        }

        /// <summary>
        /// Gets estable el Meta de la respuesta.
        /// </summary>
        /// <value>Objeto Meta.</value>
        public object Meta { get; }

        /// <summary>
        /// Crea la respuesta del controllador para establecer un error en el mensaje con datos.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <param name="data">Datos de repuesta para establecer el error.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResultPagination CreateError(object message, object data, object meta)
        {
            return ResponseResultPagination.CreateResponse(false, message, data, meta);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer una respuesta dado el mensaje los datos y su estado.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta.</param>
        /// <param name="message">Establece el mensaje de la respuesta</param>
        /// <param name="data">Establece los datos de la respuesta</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResultPagination CreateResponse(bool status, object message, object data, object meta)
        {
            return new ResponseResultPagination(status, message, data ?? (new object[0]), meta ?? (new object[0]));
        }
    }
}
