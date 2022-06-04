//----------------------------------------------------
// <copyright file="BaseAuditoriaHistorial.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Angie Arrieta</author>
// <date>24-08-2021</date>
// <summary>Definición de atributos para la clase BaseAuditoriaHistorial.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Entidades
{
    /// <summary>
    /// Clase encargada de definir los parametros de historial
    /// herendando de Baseauditoria
    /// </summary>
    public class BaseAuditoriaHistorial: BaseAuditoria
    {

        /// <summary>
        /// Gets or sets a value indica la maquina ip el cual el usuario se encuentra
        /// </summary>
        /// <value></value>
        public string IpMaquina { get; set; }

        /// <summary>
        /// Gets or sets a value indica la version del historial
        /// </summary>
        /// <value></value>
        public string Version { get; set; }

    }
}
