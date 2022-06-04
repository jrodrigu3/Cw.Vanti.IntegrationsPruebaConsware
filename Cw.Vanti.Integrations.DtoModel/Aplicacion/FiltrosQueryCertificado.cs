//-----------------------------------------------------------------------
// <copyright file="FiltrosQueryCertificado.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>jperez</author>
// <date>29/11/2021 16:28:55</date>
// <summary>Código fuente clase FiltrosQueryCertificado.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// FiltrosQueryCertificado class.
    /// </summary>
    public class FiltrosQueryCertificado : FiltrosQueryParameters
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltrosQueryCertificado"/> class.
        /// </summary>
        public FiltrosQueryCertificado()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating NumeroIdentificacion 
        /// </summary>
        /// <value></value>
        public string NumeroIdentificacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating PeriodoInicial 
        /// </summary>
        /// <value></value>
        public string PeriodoInicial { get; set; }

        /// <summary>
        /// Gets or sets a value indicating PeriodoFinal 
        /// </summary>
        /// <value></value>
        public string PeriodoFinal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating CodigoEmpresa 
        /// </summary>
        /// <value></value>
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Periodo 
        /// </summary>
        /// <value></value>
        public string Periodo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Placa 
        /// </summary>
        /// <value></value>
        public string Placa { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Quincena 
        /// </summary>
        /// <value></value>
        public string Quincena { get; set; }

        /// <summary>
        /// Gets or sets a value indicating IdAfiliado 
        /// </summary>
        /// <value></value>
        public int IdAfiliado { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public string NombreAfiliado { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public int Estado { get; set; }

        /// <summary>
        /// Gets or sets a value indicating FechaInicial 
        /// </summary>
        /// <value>FechaInicial</value>
        public string FechaInicial { get; set; }

        /// <summary>
        /// Gets or sets a value indicating FechaFinal 
        /// </summary>
        /// <value>FechaFinal</value>
        public string FechaFinal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating IdUsuario
        /// </summary>
        /// <value>IdUsuario</value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets LogoSupertransporte
        /// </summary>
        /// <value>LogoSupertransporte.</value>
        public string LogoSupertransporte { get; set; }

        /// <summary>
        /// Gets or sets RutaImagen
        /// </summary>
        /// <value>RutaImagen.</value>
        public string RutaImagen { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}