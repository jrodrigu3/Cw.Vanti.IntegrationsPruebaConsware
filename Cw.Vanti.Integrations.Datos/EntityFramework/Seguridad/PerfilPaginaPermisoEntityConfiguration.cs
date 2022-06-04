//-----------------------------------------------------------------------
// <copyright file="PerfilPaginaPermisoEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:04:16</date>
// <summary>Código fuente clase PerfilPaginaPermisoEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// PerfilPaginaPermisoEntityConfiguration class.
    /// </summary>
    public class PerfilPaginaPermisoEntityConfiguration : IEntityTypeConfiguration<PerfilPaginaPermiso>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfilPaginaPermisoEntityConfiguration"/> class.
        /// </summary>
        public PerfilPaginaPermisoEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<PerfilPaginaPermiso> builder)
        {
            builder.HasKey(e => new { e.IdPerfil, e.IdPermiso, e.IdPagina })
                    .HasName("PK_Perfil_Usuario_Permiso_Pagina");

            builder.ToTable("PerfilesPaginasPermisos", "Sec");

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.HasOne(d => d.IdPaginaNavigation)
                .WithMany(p => p.PerfilesPaginasPermisos)
                .HasForeignKey(d => d.IdPagina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilesUsuarios_Paginas");

            builder.HasOne(d => d.IdPerfilNavigation)
                .WithMany(p => p.PerfilesPaginasPermisos)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilesUsuarios_perfiles");

            builder.HasOne(d => d.IdPermisoNavigation)
                .WithMany(p => p.PerfilesPaginasPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilesUsuarios_Permisos");
        }
        #endregion
    }
}