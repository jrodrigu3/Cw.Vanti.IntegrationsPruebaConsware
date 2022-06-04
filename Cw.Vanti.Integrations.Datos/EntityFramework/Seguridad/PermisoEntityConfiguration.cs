//-----------------------------------------------------------------------
// <copyright file="PermisoEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:04:30</date>
// <summary>Código fuente clase PermisoEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// PermisoEntityConfiguration class.
    /// </summary>
    public class PermisoEntityConfiguration : IEntityTypeConfiguration<Permiso>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PermisoEntityConfiguration"/> class.
        /// </summary>
        public PermisoEntityConfiguration()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss
        /// <summary>
        /// Metodo usado para realizar la configuracion de la entidad.
        /// </summary>
        /// <param name="builder">Objeto que construye la configuracion.</param>
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permisos", "Sec");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
        }
        #endregion
    }
}