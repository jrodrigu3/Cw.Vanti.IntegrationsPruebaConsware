//-----------------------------------------------------------------------
// <copyright file="ControlCargaDbContext.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>2/20/2019 2:40:04 PM</date>
// <summary>Código fuente clase ControlCargaDbContext.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Se definen las entidades y configuraciones que hacen parte del contexto de la base de datos.
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="configuration">Objeto que contiene las configuraciones del sistema.</param>
        public AppDbContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que almacena la configuracion de la base de datos.
        /// </summary>
        /// <value>Objeto que almacena la configuracion de la base de datos.</value>
        public IConfiguration Configuration { get; set; }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Metodo override.
        /// </summary>
        /// <param name="optionsBuilder">Objeto que realiza la construccion de las configuraciones
        /// de las tablas.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.Configuration["SistemaAgenciasDBConnectionString"]);
            }
        }

        /// <summary>
        /// Metodo override.
        /// </summary>
        /// <param name="modelBuilder">Objeto que realiza la construccion de las configuraciones
        /// de las tablas.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se encarga de añadir y ejecutar todas las configuraciones definidas para cada entidad en la base de datos.
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            DbEnitityConfiguration dbconfiguration = new DbEnitityConfiguration(modelBuilder);
            dbconfiguration.ExecuteConfiguration();
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}