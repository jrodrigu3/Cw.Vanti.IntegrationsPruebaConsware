using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class Permiso
    {
        public Permiso()
        {
            PerfilesPaginasPermisos = new HashSet<PerfilPaginaPermiso>();
        }

        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public int? AnuladoPor { get; set; }
        public string EstadoRegistro { get; set; }
        public string ObservacionEstado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PerfilPaginaPermiso> PerfilesPaginasPermisos { get; set; }
    }
}
