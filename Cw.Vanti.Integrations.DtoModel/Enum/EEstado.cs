//-----------------------------------------------------------------------
// <copyright file="ETipoEstado.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>16-03-2021 11:16:05 AM</date>
// <summary>Código fuente clase ETipoEstado.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// ETipoEstado class. usado para enumera los estados
    /// </summary>
    public enum EEstado
    {
        /// <summary>
        /// Describe el alias correspondiente a Pendiente
        /// </summary>
        Pendiente = 2,

        /// <summary>
        /// Describe el alias correspondiente a Agendado
        /// </summary>
        Agendado = 3,

        /// <summary>
        /// Describe el alias correspondiente a PorAprobar
        /// </summary>
        PorAprobar = 4,

        /// <summary>
        /// Describe el alias correspondiente a Descartado
        /// </summary>
        Descartado = 5,

        /// <summary>
        /// Describe el alias correspondiente a Afiliado
        /// </summary>
        Afiliado =  6,

        /// <summary>
        /// Describe el alias correspondiente a Activo
        /// </summary>
        Activo = 7,

        /// <summary>
        /// Describe el alias correspondiente a Inactivo
        /// </summary>
        Inactivo = 8,

        /// <summary>
        /// Describe el alias correspondiente a Finalizado
        /// </summary>
        Finalizado = 9,

        /// <summary>
        /// Describe el alias correspondiente a Matriculado
        /// </summary>
        Matriculado = 10,

        /// <summary>
        /// Describe el alias correspondiente a Vinculado
        /// </summary>
        Vinculado = 12,

        /// <summary>
        /// Describe el alias correspondiente a Cancelado
        /// </summary>
        Cancelado = 13,

        /// <summary>
        /// Describe el alias correspondiente a Aprobado
        /// </summary>
        Aprobado = 14,

        /// <summary>
        /// Describe el alias correspondiente a NoAprobado
        /// </summary>
        NoAprobado = 15,

        /// <summary>
        /// Describe el alias correspondiente a AprobadoParcial
        /// </summary>
        AprobadoParcial = 16,

        /// <summary>
        /// Describe el alias correspondiente a Gestionado
        /// </summary>
        Gestionado = 17,

        /// <summary>
        /// Describe el alias correspondiente a Vigente
        /// </summary>
        Vigente = 34,

        /// <summary>
        /// Describe el alias correspondiente a Desvinculado
        /// </summary>
        Desvinculado = 22,

        /// <summary>
        /// Describe el alias correspondiente a Aplazado
        /// </summary>
        Aplazado = 23,

        /// <summary>
        /// Describe el alias correspondiente a Solicitado
        /// </summary>
        Solicitado = 24,

        /// <summary>
        /// Describe el alias correspondiente a Comité
        /// </summary>
        Comite = 31,

        /// <summary>
        /// Describe el estado completado de una acta
        /// </summary>
        Completado = 29,

        /// <summary>
        ///  Describe el estado incompleto de una acta
        /// </summary>
        Incompleto = 30,

        /// <summary>
        ///  Describe el estado Liquidado
        /// </summary>
        Liquidado = 43,

        ///  Describe el estado de la transaccion SAP generada
        /// </summary>
        GeneradoSAP = 39,

        /// <summary>
        ///  Describe el estado de la transaccion SAP enviada
        /// </summary>
        EnviadoSAP = 40,

        /// <summary>
        ///  Describe el estado de la transaccion SAP rechazada
        /// </summary>
        RechazadoSAP = 41,

        /// <summary>
        ///  Describe el estado de la transaccion SAP procesada exitosa
        /// </summary>
        ExitosoSAP = 42,

        /// <summary>
        ///  Describe el estado de la transaccion SAP fue recibida
        /// </summary>
        RecibidoSAP = 44
    }
}
