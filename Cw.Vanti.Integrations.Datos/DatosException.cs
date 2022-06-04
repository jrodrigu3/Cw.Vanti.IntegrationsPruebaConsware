//-----------------------------------------------------------------------
// <copyright file="DatosException.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>3/11/2019 6:03:35 PM</date>
// <summary>Código fuente clase DatosException.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using Cw.Vanti.Integrations.Utils;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Define la base jerárquica de las excepciones generadas en
    /// la comunicación con la base de datos.
    /// </summary>
    [Serializable]
    public class DatosException : Exception
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosException"/> class.
        /// </summary>
        public DatosException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosException"/>
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DatosException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DatosException(string message, Exception innerException)
            : base(message, innerException)
        {
            AppLogger.Instance().Exception(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="q">Cadena con la consulta que se ejecuto con error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DatosException(string message, string q, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatosException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo
        /// that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext
        /// that contains contextual information about the source or destination.</param>
        protected DatosException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        #endregion
    }
}