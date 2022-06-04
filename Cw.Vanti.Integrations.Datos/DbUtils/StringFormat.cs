//-----------------------------------------------------------------------
// <copyright file="StringFormat.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>8/14/2019 10:30:02 AM</date>
// <summary>Código fuente clase StringFormat.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos.DbUtils
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Proporciona métodos utiles para la construcción
    /// de mensajes personalizados.
    /// </summary>
    public static class StringFormat
    {
        #region Attributes

        #endregion

        #region Constructors
        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Gets or sets la cultura empleada para la construcción.
        /// </summary>
        /// <value>Cultura empleada para la construcción.</value>
        public static CultureInfo Culture { get; set; }

        /// <summary>
        /// Obtiene una cadena formateada con los
        /// valores suministrados.
        /// </summary>
        /// <param name="f">Formato de la cadena.</param>
        /// <param name="values">Valores de la candena.</param>
        /// <returns>Cadena formateada.</returns>
        public static string Format(string f, params object[] values)
        {
            return string.Format(Culture, f, values);
        }

        /// <summary>
        /// Gestiona la codificacion en base 64 de la cadena proporcionada.
        /// </summary>
        /// <param name="c">Cadena a codificada.</param>
        /// <param name="encoding">Codificación de caracteres a emplear.</param>
        /// <returns>Cadena en base 64.</returns>
        public static string ToBase64String(string c, Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            byte[] bytes = encoding.GetBytes(c);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Gestiona la codificacion en base 64 de la cadena proporcionada.
        /// </summary>
        /// <param name="c">Cadena a codificada.</param>
        /// <param name="encoding">Codificación de caracteres a emplear.</param>
        /// <returns>Cadena en base 64.</returns>
        public static byte[] ToBase64Bytes(string c, Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            byte[] bytes = encoding.GetBytes(c);
            string base64 = Convert.ToBase64String(bytes);
            return encoding.GetBytes(base64);
        }

        /// <summary>
        /// Dada la represenación en cadena de un elemento en formato
        /// hexadecimal, retorna su equivalente en bytes.
        /// </summary>
        /// <param name="hex">Cadena en formato hexadecimal.</param>
        /// <returns>Bytes equivalentes de la cadena dada.</returns>
        public static byte[] StringHexToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];

            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return bytes;
        }

        /// <summary>
        /// Dado un conjunto de bytes, retorna la representación equivalente de estos
        /// en forma de cadena con formato hexadecimal.
        /// </summary>
        /// <param name="ba">Cw.Vanti.Integrations.Datos a ser convertidos.</param>
        /// <returns>Cadena con formato hexadecimal de los bytes dados.</returns>
        public static string ByteArrayToStringHex(byte[] ba)
        {
            return StringFormat.ByteArrayToStringHex(ba, 0);
        }

        /// <summary>
        /// Dado un conjunto de bytes, retorna la representación equivalente de estos
        /// en forma de cadena con formato hexadecimal.
        /// </summary>
        /// <param name="ba">Cw.Vanti.Integrations.Datos a ser convertidos.</param>
        /// <param name="startIndex">Posición a partir de la cual iniciará
        /// el procesamiento.</param>
        /// <returns>Cadena con formato hexadecimal de los bytes dados.</returns>
        public static string ByteArrayToStringHex(byte[] ba, int startIndex)
        {
            return StringFormat.ByteArrayToStringHex(ba, startIndex, ba.Length);
        }

        /// <summary>
        /// Dado un conjunto de bytes, retorna la representación equivalente de estos
        /// en forma de cadena con formato hexadecimal.
        /// </summary>
        /// <param name="ba">Cw.Vanti.Integrations.Datos a ser convertidos.</param>
        /// <param name="startIndex">Posición a partir de la cual iniciará
        /// el procesamiento.</param>
        /// <param name="length">Número de elementos que serán procesados.</param>
        /// <returns>Cadena con formato hexadecimal de los bytes dados.</returns>
        public static string ByteArrayToStringHex(byte[] ba, int startIndex, int length)
        {
            if (startIndex > length)
                throw new ArgumentException("Start index must be less than length.");

            string hex = BitConverter.ToString(ba, startIndex, length - startIndex);
            return hex.Replace("-", "");
        }

        #endregion
    }
}