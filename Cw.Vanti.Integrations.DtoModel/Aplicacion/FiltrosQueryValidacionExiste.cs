//-----------------------------------------------------------------------
// <copyright file="FiltrosQueryValidacionExiste.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>jperez</author>
// <date>11/03/2022 15:10:00</date>
// <summary>Código fuente clase FiltrosQueryValidacionExiste.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// FiltrosQueryValidacionExiste class para almacenar los campos a comparar para validar existencia.
    /// </summary>
    public class FiltrosQueryValidacionExiste
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltrosQueryValidacionExiste"/> class.
        /// </summary>
        public FiltrosQueryValidacionExiste()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating TipoValidacion 
        /// </summary>
        /// <value>TipoValidacion</value>
        public string TipoValidacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating NombreCompleto 
        /// </summary>
        /// <value>NombreCompleto</value>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Codigo 
        /// </summary>
        /// <value>Codigo</value>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Nombre 
        /// </summary>
        /// <value>Nombre</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Id 
        /// </summary>
        /// <value>Id</value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating IdTipoPoliza 
        /// </summary>
        /// <value>IdTipoPoliza</value>
        public int IdTipoPoliza { get; set; }

        /// <summary>
        /// Gets or sets a value indicating IdProceso 
        /// </summary>
        /// <value>IdProceso</value>
        public int IdProceso { get; set; }

        /// <summary>
        /// Gets or sets a value indicating IdUsuario 
        /// </summary>
        /// <value>IdUsuario</value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets a value indicating NumeroIdentificacion 
        /// </summary>
        /// <value>NumeroIdentificacion</value>
        public string NumeroIdentificacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Periodo 
        /// </summary>
        /// <value>Periodo</value>
        public int Periodo { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}