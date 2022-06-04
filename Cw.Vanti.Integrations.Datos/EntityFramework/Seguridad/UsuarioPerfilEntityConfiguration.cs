//-----------------------------------------------------------------------
// <copyright file="UsuarioPerfilEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:04:54</date>
// <summary>Código fuente clase UsuarioPerfilEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// UsuarioPerfilEntityConfiguration class.
    /// </summary>
    public class UsuarioPerfilEntityConfiguration : IEntityTypeConfiguration<UsuarioPerfil>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioPerfilEntityConfiguration"/> class.
        /// </summary>
        public UsuarioPerfilEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasKey(e => new { e.IdUsuario, e.IdPerfil });

            builder.ToTable("UsuariosPerfiles", "Sec");

            builder.Property(e => e.EstadoRegistro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.ObservacionEstado)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPerfilNavigation)
                .WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UsuariosPerfiles_Perfiles_1");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosPerfiles_Usuarios");
        }
        #endregion
    }
}