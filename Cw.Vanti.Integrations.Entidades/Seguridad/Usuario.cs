using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuariosPerfiles = new HashSet<UsuarioPerfil>();
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
        public string NombreCompleto { get; set; }
        public int IndicativoTelefono { get; set; }
        public string Telefono { get; set; }
        public int IndicativoCelular { get; set; }
        public string Celular { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RutaAvatar { get; set; }
        public int IdEmpresa { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCiudad { get; set; }
        public int? IdBarrio { get; set; }
        public string Direccion { get; set; }
        public int? IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }

        public virtual Barrio IdBarrioNavigation { get; set; }
        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; }
    }
}
