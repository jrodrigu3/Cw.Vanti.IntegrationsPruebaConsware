//-----------------------------------------------------------------------
// <copyright file="AppLogger.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Código fuente clase AppLogger.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using System;
    using NLog;

    /// <summary>
    /// Proporciona métodos útiles para gestionar los logs del sistema.
    /// </summary>
    public class AppLogger
    {
        #region Attributes

        /// <summary>
        /// Representa los datos de instancia de logger actual.
        /// </summary>
        private static AppLogger singleton;

        /// <summary>
        /// Gets or sets la instancia del objeto usado para capturar
        /// los errores de la aplicacion.
        /// </summary>
        /// <value></value>
        private static Logger Logger { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="AppLogger"/> class from being created.
        /// </summary>
        private AppLogger()
        {
            Logger =  NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Gestiona la construcción de una instancia única de logger.
        /// </summary>
        /// <returns>Instancia que gestiona el logger.</returns>
        public static AppLogger Instance()
        {
            if (singleton == null)
            {
                singleton = new AppLogger();
            }

            return singleton;
        }

        ////

        /// <summary>
        /// Registra una excepción, empleando como datos
        /// una instancia de <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="ex">Instancia con los datos de la excepción.</param>
        /// <exception cref="LoggerException">Cuando falla el
        /// registro del log especificado.</exception>
        public void Exception(Exception ex)
        {
            Logger.Error(ex);
        }

        /// <summary>
        /// Registra un mensaje de depuración.
        /// </summary>
        /// <param name="message">Mensaje de depuración.</param>
        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// Registra un mensaje informativo.
        /// </summary>
        /// <param name="message">Mensaje informativo.</param>
        public void Info(string message)
        {
            Logger.Info(message);
        }

        #endregion
    }
}