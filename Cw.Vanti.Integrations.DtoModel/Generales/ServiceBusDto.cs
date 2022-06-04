//-----------------------------------------------------------------------
// <copyright file="ServiceBusDto.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>12/05/2020 9:16:30</date>
// <summary>Código fuente clase ServiceBusDto.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// ServiceBusDto class.
    /// </summary>
    public class ServiceBusDto
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusDto"/> class.
        /// </summary>
        public ServiceBusDto()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether tag name identificador del objeto de la cola
        /// </summary>
        /// <value></value>
        public string TagName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Object objeto que contiene el cuerpo del mensje de la cola
        /// </summary>
        /// <value></value>
        public object Objeto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Object objeto que contiene el cuerpo del mensje de la cola
        /// </summary>
        /// <value></value>
        public object Object { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Maneja error de respuesta de BL
        /// </summary>
        /// <value></value>
        public bool Error { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}