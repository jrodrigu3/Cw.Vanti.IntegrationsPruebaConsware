//-----------------------------------------------------------------------
// <copyright file="NegocioBL.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>23/07/2020 18:13:20</date>
// <summary>Código fuente clase NegocioBL.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Negocio
{
    using Azure.Storage.Blobs;
    using Cw.Vanti.Integrations.Datos;
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Clase usada como principal para instanciar el unit of work.
    /// </summary>
    public class NegocioBL
    {
        #region Attributes

        /// <summary>
        /// Gets objeto manejador del Unit of work de los this.Cw.Vanti.Integrations.Negocio.Repositorios.
        /// </summary>
        private IDatosUow repositorios;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NegocioBL"/> class.
        /// </summary>
        /// <param name="configuration">Objeto que contiene la configuracion de aplicativo.</param>
        /// <param name="notificacionBL">Manejador de logica de negocio de notificaciones.</param>
        public NegocioBL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que contiene la configuracion de aplicativo.
        /// </summary>
        /// <value>Objeto que contiene la configuracion de aplicativo.</value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets el acceso a los repositorios de datos.
        /// </summary>
        public IDatosUow Repositorios
        {
            get
            {
                if (this.repositorios == null)
                {
                    this.repositorios = new EfDatosUow(this.Configuration);
                }

                return this.repositorios;
            }
        }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}