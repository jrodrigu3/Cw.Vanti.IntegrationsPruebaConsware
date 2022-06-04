//-----------------------------------------------------------------------
// <copyright file="UsuarioEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:04:41</date>
// <summary>Código fuente clase UsuarioEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// UsuarioEntityConfiguration class.
    /// </summary>
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioEntityConfiguration"/> class.
        /// </summary>
        public UsuarioEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "Sec");

            builder.HasIndex(e => e.Identificacion, "UN_Usuarios_Identificacion")
                .IsUnique();

            builder.HasIndex(e => e.UserName, "UN_Usuarios_UserName")
                .IsUnique();

            builder.Property(e => e.Celular)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NombreCompleto)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.RutaAvatar).HasMaxLength(500);

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasOne(d => d.IdBarrioNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("FK_Usuarios_Barrios");

            builder.HasOne(d => d.IdCiudadNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Ciudades");

            builder.HasOne(d => d.IdDepartamentoNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Departamentos");

            builder.HasOne(d => d.IdEmpresaNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Empresas");
        }
        #endregion
    }
}