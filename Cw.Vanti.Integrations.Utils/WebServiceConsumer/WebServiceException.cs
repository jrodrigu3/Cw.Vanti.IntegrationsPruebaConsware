//-----------------------------------------------------------------------
// <copyright file="WebServiceException.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>29/03/2020 17:20:48</date>
// <summary>Código fuente clase WebServiceException.cs</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Define la base jerárquica de las excepciones asociadas al consumo de servicios web.
    /// </summary>
    [Serializable]
    public class WebServiceException : Exception
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceException"/> class.
        /// </summary>
        public WebServiceException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceException"/>
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public WebServiceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public WebServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="q">Cadena con la consulta que se ejecuto con error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public WebServiceException(string message, string q, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo
        /// that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext
        /// that contains contextual information about the source or destination.</param>
        protected WebServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        #endregion
    }
}