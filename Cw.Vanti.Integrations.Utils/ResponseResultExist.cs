//----------------------------------------------------
// <copyright file="ResponseResultExist.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ResponseResultExist.cs</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    /// <summary>
    /// Gets la estructura de las respuesta para los controller.
    /// </summary>
    public class ResponseResultExist : ResponseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResultExist"/> class.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta. </param>
        /// <param name="message">Establece el mensaje de la respuesta. </param>
        /// <param name="data">Establece los datos de la respuesta. </param>
        /// <param name="exist">True o false.</param>
        public ResponseResultExist(bool status, object message, object data, bool exist) : base(status, message, data)
        {
            this.Exist = exist;
        }

        /// <summary>
        /// Gets estable el Exist de la respuesta.
        /// </summary>
        /// <value>True or false.</value>
        public bool Exist { get; }

        /// <summary>
        /// Crea la respuesta del controllador para establecer un error en el mensaje con datos.
        /// </summary>
        /// <param name="message">Representa el mensaje de error.</param>
        /// <param name="data">Datos de repuesta para establecer el error.</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResultExist CreateError(object message, object data, bool exist)
        {
            return ResponseResultExist.CreateResponse(false, message, data, exist);
        }

        /// <summary>
        /// Crea la respuesta del controllador para establecer una respuesta dado el mensaje los datos y su estado.
        /// </summary>
        /// <param name="status">Establece el estado de la respuesta.</param>
        /// <param name="message">Establece el mensaje de la respuesta</param>
        /// <param name="data">Establece los datos de la respuesta</param>
        /// <returns>Resultado de la respueta.</returns>
        public static ResponseResultExist CreateResponse(bool status, object message, object data, bool exist)
        {
            return new ResponseResultExist(status, message, data ?? (new object()), exist);
        }
    }
}
