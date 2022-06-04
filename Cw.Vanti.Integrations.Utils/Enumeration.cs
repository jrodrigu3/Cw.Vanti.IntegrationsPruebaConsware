//-----------------------------------------------------------------------
// <copyright file="Enumeration.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>3/7/2019 9:42:35 AM</date>
// <summary>Código fuente clase Enumeration.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    /// <summary>
    /// Clase usada para customizar un Enum.
    /// </summary>
    public abstract class Enumeration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        protected Enumeration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="id">Id del objeto.</param>
        protected Enumeration(string value, int id)
        {
            this.Value = value;
            this.Id = id;
            this.Message = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">Id del objeto.</param>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="param">Parametro que debe ser formateados en el mensaje.</param>
        protected Enumeration(int id, string value, string param)
        {
            this.Value = value;
            this.Id = id;
            this.Message = string.Format(value, param);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">Id del objeto.</param>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="parameters">Parametros que van ser formateados en el mensaje.</param>
        protected Enumeration(int id, string value, string[] parameters)
        {
            this.Value = value;
            this.Id = id;
            this.Message = string.Format(value, string.Join(",", parameters));
        }

        /// <summary>
        /// Gets or sets Propiedad que almacena el valor.
        /// </summary>
        /// <value>Valor de la propiedad.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el id.
        /// </summary>
        /// <value>Id de la propiedad.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el parametro.
        /// </summary>
        /// <value>Parametro de la propiedad.</value>
        public string Param { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena los parametros.
        /// </summary>
        /// <value>Parametros de la propiedad.</value>
        public string[] Params { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el mensaje resultado.
        /// </summary>
        /// <value>Mensaje de la propiedad.</value>
        public string Message { get; set; }

    }
}
