//-----------------------------------------------------------------------
// <copyright file="ClienteEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:02:47</date>
// <summary>Código fuente clase ClienteEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// ClienteEntityConfiguration class.
    /// </summary>
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClienteEntityConfiguration"/> class.
        /// </summary>
        public ClienteEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "Sec");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

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

            builder.Property(e => e.NombreCompletoJuridica)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.PrimerApellidoNatural)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PrimerNombreNatural)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.RutaAvatar).HasMaxLength(500);

            builder.Property(e => e.SegundoApellidoNatural)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SegundoNombreNatural)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Configuracion");

            builder.HasOne(d => d.IdCiudadNavigation)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdDepartamentoNavigation)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdTipoIdentificacionNavigation)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoIdentificacion);
        }
        #endregion
    }
}