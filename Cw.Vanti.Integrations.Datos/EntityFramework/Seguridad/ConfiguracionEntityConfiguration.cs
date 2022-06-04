//-----------------------------------------------------------------------
// <copyright file="ConfiguracionEntityConfiguration.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>04/05/2021 15:03:00</date>
// <summary>Código fuente clase ConfiguracionEntityConfiguration.</summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// ConfiguracionEntityConfiguration class.
    /// </summary>
    public class ConfiguracionEntityConfiguration : IEntityTypeConfiguration<Configuracion>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguracionEntityConfiguration"/> class.
        /// </summary>
        public ConfiguracionEntityConfiguration()
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
        public void Configure(EntityTypeBuilder<Configuracion> builder)
        {
            builder.ToTable("Configuracion", "Sec");

            builder.Property(e => e.EstadoRegistro)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true);

            builder.Property(e => e.ProveedorNube).HasMaxLength(100);

            builder.Property(e => e.UrlAplicacion).HasMaxLength(250);
        }
        #endregion
    }
}