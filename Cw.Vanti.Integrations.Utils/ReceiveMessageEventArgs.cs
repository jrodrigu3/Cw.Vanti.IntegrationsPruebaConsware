//-----------------------------------------------------------------------
// <copyright file="ReceiveMessageEventArgs.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>marrieta</author>
// <date>09/05/2020 16:53:30</date>
// <summary>Código fuente clase ReceiveMessageEventArgs.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using System;

    /// <summary>
    /// ReceiveMessageEventHandler class.
    /// </summary>
    public class ReceiveMessageEventArgs<T> : EventArgs
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiveMessageEventArgs"/> class.
        /// </summary>
        public ReceiveMessageEventArgs()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que contiene el mensaje recibido.
        /// </summary>
        /// <value>Objeto que contiene el mensaje recibido.</value>
        public T ObjectReceived { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}