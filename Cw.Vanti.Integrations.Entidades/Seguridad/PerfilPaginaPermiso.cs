using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class PerfilPaginaPermiso
    {
        public int IdPerfil { get; set; }
        public int IdPermiso { get; set; }
        public int IdPagina { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadorPor { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public int? AnuladoPor { get; set; }
        public string EstadoRegistro { get; set; }
        public string ObservacionEstado { get; set; }

        public virtual Pagina IdPaginaNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Permiso IdPermisoNavigation { get; set; }
    }
}
