
//-----------------------------------------------------------------------
// <copyright file="EmailSender.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>21/04/2021</date>
// <summary>Código fuente clase EmailSender.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Backend
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Clase que representa el contexto de identity de brasilia.
    /// </summary>
    public class BrasiliaIdentityDbContext : IdentityDbContext
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BrasiliaIdentityDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">option params.</param>
        public BrasiliaIdentityDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo override.
        /// </summary>
        /// <param name="modelBuilder">Objeto que realiza la construccion de las configuraciones
        /// de las tablas.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
