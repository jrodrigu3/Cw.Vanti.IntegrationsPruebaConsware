//-----------------------------------------------------------------------
// <copyright file="PaginaEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:03:47</date>
// <summary>Código fuente clase PaginaEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    /// <summary>
    /// PaginaEntityConfiguration class.
    /// </summary>
    public class PaginaEntityConfiguration : IEntityTypeConfiguration<Pagina>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginaEntityConfiguration"/> class.
        /// </summary>
        public PaginaEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<Pagina> builder)
        {
            builder.ToTable("Paginas", "Sec");

            builder.HasIndex(e => e.IdModulo, "IX_Paginas_IdModulo");

            builder.HasIndex(e => e.Nombre, "UN_Paginas_Nombre")
                .IsUnique();

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.Icono)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.UrlPagina)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.VerEnMenu).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.IdModuloNavigation)
                .WithMany(p => p.Paginas)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paginas_IdModulo");
        }
        #endregion
    }
}