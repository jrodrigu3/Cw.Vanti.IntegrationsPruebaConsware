//----------------------------------------------------
// <copyright file="BaseAuditoriaDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase BaseAuditoriaDto.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Entidades
{
    using System;

    /// <summary>
    /// Clase utilizada para definir propiedades de auditoria base para cada entidad
    /// </summary>
    public class BaseAuditoria
    {
        #region Attributes

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAuditoriaDto"/> class.
        /// </summary>
        public BaseAuditoria()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Get or set Fecha de creacion
        /// </summary>
        /// <value>Fecha de creacion del registro.</value>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Get or set Creado por
        /// </summary>
        /// <value>Usuario que realizo la creacion del registro.</value>
        public int CreadoPor { get; set; }

        /// <summary>
        /// Get or set Fecha de modificacion
        /// </summary>
        /// <value>Fecha de modificacion del registro.</value>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Get or set Modificado por
        /// </summary>
        /// <value>Usuario que realizo la modificacion del registro.</value>
        public int? ModificadoPor { get; set; }

        /// <summary>
        /// Get or set Fecha de anulacion
        /// </summary>
        /// <value>Fecha de anulacion del registro.</value>
        public DateTime? FechaAnulacion { get; set; }

        /// <summary>
        /// Get or set Anulado por
        /// </summary>
        /// <value>Usuario que realizo la anulacion del registro.</value>
        public int? AnuladoPor { get; set; }

        /// <summary>
        /// Get or set Estado del registro
        /// </summary>
        /// <value>Estado en el que se encuentra el registro.</value>
        public String EstadoRegistro { get; set; }

        /// <summary>
        /// Get or set Observacion del registro
        /// </summary>
        /// <value>Observacion basada en el cambio de estado del registro.</value>
        public String ObservacionEstado { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}
