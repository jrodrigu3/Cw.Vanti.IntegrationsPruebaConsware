//----------------------------------------------------
// <copyright file="ParamApi.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ParamApi.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    public class ParamApi
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParam"/> class.
        /// </summary>
        public ParamApi()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Nombre del parametro
        /// </summary>
        /// <value>Key.</value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets Valor del parametro.
        /// </summary>
        /// <value>Value.</value>
        public string Value { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}
