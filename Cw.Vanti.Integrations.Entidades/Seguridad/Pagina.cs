using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class Pagina
    {
        public Pagina()
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
        public string Icono { get; set; }
        public int IdModulo { get; set; }
        public int IdPaginaPadre { get; set; }
        public int Orden { get; set; }
        public string UrlPagina { get; set; }
        public bool EsTitulo { get; set; }
        public bool? VerEnMenu { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual ICollection<PerfilPaginaPermiso> PerfilesPaginasPermisos { get; set; }
    }
}
