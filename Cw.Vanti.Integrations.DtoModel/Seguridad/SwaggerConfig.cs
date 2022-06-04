//----------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase SwaggerConfig.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Se define la estructura base que representa a la configuracion del Swagger
    /// que se autentican en el api.
    /// </summary>
    public class SwaggerConfig
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerConfig"/> class.
        /// </summary>
        public SwaggerConfig()
        {
        }

        #endregion

        #region Properties

        public string VersionWebApi { get; set; }
        public string NombreWebApi { get; set; }
        public string DescripcionWebApi { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
        public string TipoAutorizacion { get; set; }
        public string DescripcionAutorizacion { get; set; }
        public string HeaderAutorizacion { get; set; }
        public string NombreAutorizacion { get; set; }
        public string TipoEsquemaAutorizacion { get; set; }
        public string Enviroment { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}