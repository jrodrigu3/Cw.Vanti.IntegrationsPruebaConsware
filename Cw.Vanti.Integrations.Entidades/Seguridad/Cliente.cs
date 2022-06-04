using System;
using System.Collections.Generic;

#nullable disable

namespace Cw.Vanti.Integrations.Datos
{
    public partial class Cliente
    {
        public Cliente()
        {
            Empresas = new HashSet<Empresa>();
            Terceros = new HashSet<Tercero>();
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
        public int IdTipoPersona { get; set; }
        public string NombreCompletoJuridica { get; set; }
        public string PrimerNombreNatural { get; set; }
        public string SegundoNombreNatural { get; set; }
        public string PrimerApellidoNatural { get; set; }
        public string SegundoApellidoNatural { get; set; }
        public int IndicativoTelefono { get; set; }
        public string Telefono { get; set; }
        public int IndicativoCelular { get; set; }
        public string Celular { get; set; }
        public string RutaAvatar { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
        public int? IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Configuracion IdNavigation { get; set; }
        public virtual TipoDetalle IdTipoIdentificacionNavigation { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Tercero> Terceros { get; set; }
    }
}
