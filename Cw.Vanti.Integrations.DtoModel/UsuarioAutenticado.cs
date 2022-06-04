//-----------------------------------------------------------------------
// <copyright file="UsuarioAutenticado.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Código fuente clase UsuarioAutenticado.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Esta clase es usada para almacenar los datos de un usuario que se encuentra autenticado.
    /// </summary>
    public class UsuarioAutenticado
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioAutenticado"/> class.
        /// </summary>
        public UsuarioAutenticado()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Id del usuario.
        /// </summary>
        /// <value>Id del usuario.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Id del cliente dueño del usuario
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Gets or sets Codigo del cliente.
        /// </summary>
        public string CodigoCliente { get; set; }

        /// <summary>
        /// Gets or sets Id de la agencia.
        /// </summary>
        public int IdAgencia { get; set; }

        /// <summary>
        /// Gets or sets Codigo de la agencia.
        /// </summary>
        public string CodigoAgencia { get; set; }

        /// <summary>
        /// Gets or sets Id de la empresa.
        /// </summary>
        public int IdEmpresa { get; set; }

        /// <summary>
        /// Gets or sets Codigo de la Empresa.
        /// </summary>
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// Gets or sets Id del afiliado.
        /// </summary>
        public int IdAfiliado { get; set; }

        /// <summary>
        /// Gets or sets Username del usuario.
        /// </summary>
        /// <value>Username unico.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Email del usuario.
        /// </summary>
        /// <value>Username unico.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Ip de la maquina del usuario autenticado
        /// </summary>
        /// <value>IpMaquina.</value>
        public string IpMaquina { get; set; }

        /// <summary>
        /// Gets or sets IdPerfil
        /// </summary>
        /// <value>Id del perfil del usuario que esta logueado.</value>
        public int IdPerfil { get; set; }

        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        /// <value>Numero unido del TimeZone.</value>
        public int? TimeZone { get; set; }
        /// <summary>
        /// Gets or sets IdTipoUsuario
        /// </summary>
        /// <value>Id del tipo de usuario que esta logueado.</value>
        public int IdTipoUsuario { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}