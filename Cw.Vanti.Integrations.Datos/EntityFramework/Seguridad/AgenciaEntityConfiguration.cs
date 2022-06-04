//-----------------------------------------------------------------------
// <copyright file="AgenciaEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:02:36</date>
// <summary>Código fuente clase AgenciaEntityConfiguration.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// AgenciaEntityConfiguration class.
    /// </summary>
    public class AgenciaEntityConfiguration : IEntityTypeConfiguration<Agencia>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AgenciaEntityConfiguration"/> class.
        /// </summary>
        public AgenciaEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.ToTable("Agencias", "Sec");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true);

            builder.Property(e => e.NombreAgencia)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.HasOne(d => d.IdEmpresaNavigation)
                .WithMany(p => p.Agencia)
                .HasForeignKey(d => d.IdEmpresa);
        }
        #endregion
    }
}