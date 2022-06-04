using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class UsuarioPerfil
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public int? AnuladoPor { get; set; }
        public string EstadoRegistro { get; set; }
        public string ObservacionEstado { get; set; }
        public bool? PorDefecto { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
