//-----------------------------------------------------------------------
// <copyright file="UtilHttpClient.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>09/11/2021 16:27:32</date>
// <summary>Código fuente clase UtilHttpClient.</summary>
//-----------------------------------------------------------------------
namespace WebAPI
{
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase usada para manejar utilidades que impliquen consumir otros web Api's.
    /// </summary>
    public class UtilHttpClient
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilHttpClient"/> class.
        /// </summary>
        /// <param name="configuration">Objeto que contiene los parametros de configuración.</param>
        public UtilHttpClient(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Objeto que contiene los parametros de configuracion.
        /// </summary>
        public IConfiguration Configuration { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
