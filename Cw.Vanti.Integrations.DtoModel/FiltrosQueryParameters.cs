//-----------------------------------------------------------------------
// <copyright file="FiltrosQueryParameters.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>acharris</author>
// <date>14/05/2021</date>
// <summary>Código fuente clase FiltrosQueryParameters.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// FiltrosQueryParameters class.
    /// </summary>
    public class FiltrosQueryParameters
    {
        /// <summary>
        /// Gets or sets Fecha de inicio.
        /// </summary>
        /// <value>Fecha de Inicio.</value>
        public string FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets Fecha fin.
        /// </summary>
        /// <value>Fecha fin.</value>
        public string FechaFin { get; set; }

        /// <summary>
        /// Gets or sets Texto predictivo.
        /// </summary>
        /// <value>Texto predictivo.</value>
        public string TextoPredictivo { get; set; }

        /// <summary>
        /// Gets or sets Estado de registro.
        /// </summary>
        /// <value>Estado registro.</value>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Gets or sets id del tipo de reporte
        /// </summary>
        /// <value>IdTipoReporte.</value>
        public int IdTipoReporte { get; set; }

        /// <summary>
        /// Gets or sets Seleccionable para identificar si es un select o un listado
        /// </summary>
        /// <value>Seleccionable.</value>
        public bool Seleccionable { get; set; }
    }
}