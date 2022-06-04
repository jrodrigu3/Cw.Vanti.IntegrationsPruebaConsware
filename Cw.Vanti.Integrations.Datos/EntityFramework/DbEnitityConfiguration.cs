//-----------------------------------------------------------------------
// <copyright file="DbConfiguration.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>3/7/2019 8:45:45 AM</date>
// <summary>Código fuente clase DbConfiguration.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Clase usada para definir la configuracion de la entidades de la base de datos.
    /// </summary>
    internal class DbEnitityConfiguration
    {
        #region Attributes

        /// <summary>
        /// Propiedad que establece las configuraciones en la bd.
        /// </summary>
        private readonly ModelBuilder modelBuilder;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DbEnitityConfiguration"/> class.
        /// </summary>
        /// <param name="modelBuilder">Parametro que establece las configuraciones en la bd.</param>
        public DbEnitityConfiguration(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Metodo usado para ejecutar las configuraciones de las entidades.
        /// </summary>
        public void ExecuteConfiguration()
        {
            this.AddAplicationConfiguration();
            this.AddGeneralConfiguration();
        }

        /// <summary>
        /// Metodo usado para añadir las configuraciones de aplicacion.
        /// </summary>
        private void AddAplicationConfiguration()
        {
        }

        /// <summary>
        /// Metodo usado para añadir las configuraciones generales.
        /// </summary>
        private void AddGeneralConfiguration()
        {
        }

        #endregion
    }
}