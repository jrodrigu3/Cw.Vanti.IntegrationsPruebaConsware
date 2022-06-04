//----------------------------------------------------
// <copyright file="ModuloDto.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ModuloDto.</summary>
//----------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using Dnp.IO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Clase usada para utilidades de la aplicacion.
    /// </summary>
    public static class Utils
    {
        #region Attributes

        /// <summary>
        /// Atributo que almacena el Id del usuario del sistema.
        /// </summary>
        public static readonly int IdUserSystem = 105;

        /// <summary>
        /// Atributo que almacena el contenido del asunto que va a ser enviado por mail.
        /// </summary>
        public static readonly string AsuntoMail = "Notificacion Control Carga";

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Metodo usado para remover tildes de las palabras.
        /// </summary>
        /// <param name="texto">Texto que va a ser procesado.</param>
        /// <returns>Texto normalizado.</returns>
        public static string RemoveDiacritics(string texto)
        {
            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Metodo usado para obtener el valor de una variable de entorno.
        /// </summary>
        /// <param name="keyName">Nombre de la llave.</param>
        /// <returns>Valor de la variable.</returns>
        public static string GetValueFromEnvironmentVariable(string keyName)
        {
            return Environment.GetEnvironmentVariable(keyName);
        }

        /// <summary>
        /// Metodo usado para encriptar una cadena de texto con cifrado XOR y convertirlo a base 64.
        /// </summary>
        /// <param name="text">Texto a encriptar.</param>
        /// <param name="keyString">LLave de encriptacion.</param>
        /// <param name="isEmail">Saber si es una encriptación para las rutas enviadas por email
        /// o para las url.</param>
        /// <returns>Una cadena de texto</returns>
        public static string XorEncryptToBase64(string data, string key, bool isEmail)
        {
            string xorString = EncryptDecrypt(data, key);
            string base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(xorString));
            return isEmail ? System.Net.WebUtility.UrlEncode(base64) : base64;
        }

        /// <summary>
        /// Metodo usado para encriptar una cadena de texto con cifrado XOR.
        /// </summary>
        /// <param name="text">Texto a encriptar.</param>
        /// <param name="keyString">LLave de encriptacion.</param>
        /// <param name="isEmail">Saber si es una encriptación para las rutas enviadas por email
        /// o para las url.</param>
        /// <returns>Una cadena de texto</returns>
        public static string EncryptDecrypt(string data, string key)
        {
            StringBuilder szInputStringBuild = new StringBuilder(data);
            StringBuilder szOutStringBuild = new StringBuilder(data.Length);
            char Textch;
            for (int iCount = 0; iCount < data.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ key[iCount % key.Length]);
                szOutStringBuild.Append(Textch);
            }

            return szOutStringBuild.ToString();
        }

        /// <summary>
        /// Metodo usado para obtener el nombre del archivo a partir de la ruta del mismo.
        /// </summary>
        /// <param name="ruta">Ruta del archivo.</param>
        /// <returns>Nombre del archivo.</returns>
        public static string ObtenerNombreArchivo(string ruta)
        {
            string fileName = null;
            if (!string.IsNullOrEmpty(ruta))
            {
                int fileNamePosition = ruta.LastIndexOf("/") + 1;
                fileName = ruta.Substring(fileNamePosition, ruta.Length - fileNamePosition);
            }
            return fileName;
        }

        /// <summary>
        /// Metodo usado para convertir el base 64 en un array de byte.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo.</param>
        /// <param name="imageBase64">Imagen en base 64.</param>
        /// <returns></returns>
        public static FileUploadUtil ConvertBase64ToByte(string nombreArchivo, string imageBase64)
        {
            try
            {
                FileUploadUtil fileUploadUtil = null;
                if (!string.IsNullOrEmpty(nombreArchivo) && !string.IsNullOrEmpty(imageBase64))
                {
                    byte[] file = Convert.FromBase64String(imageBase64);
                    int extPosition = nombreArchivo.LastIndexOf(".");
                    string ext = nombreArchivo.Substring(extPosition, nombreArchivo.Length - extPosition).ToLower();
                    string fileNameWithoutExt = nombreArchivo.Substring(0, nombreArchivo.LastIndexOf("."));
                    string nombreArchivoResult = Utils.RemoveDiacritics(fileNameWithoutExt.Replace(" ", "_"))
                                           + "_"
                                           + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fffffff")
                                           + ext;

                    fileUploadUtil = new FileUploadUtil
                    {
                        File = file,
                        NombreArchivo = nombreArchivoResult
                    };

                }
                return fileUploadUtil;
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo usado para generar claves encriptadas MD5 o SHA_256, partiendo de una cadena o semilla.
        /// </summary>
        /// <param name="input">Cadena que desea ser encriptada.</param>
        /// <param name="algoritmo">Tipo de algoritmo a ser utilizado para la encriptacion (MD5 o SHA_256).</param>
        /// <returns>Cadena encriptada.</returns>
        public static string EncriptarCadena(string input, string algoritmo)
        {
            string cadenaEncriptada = null;
            if (!string.IsNullOrEmpty(input))
            {
                Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                Byte[] hashedBytes = null;
                HashAlgorithm algorithm;
                if (algoritmo == "MD5")
                {
                    algorithm = new MD5CryptoServiceProvider();
                    hashedBytes = algorithm.ComputeHash(inputBytes);
                }
                else if (algoritmo == "SHA_256")
                {
                    algorithm = new SHA256CryptoServiceProvider();
                    hashedBytes = algorithm.ComputeHash(inputBytes);
                }
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    stringbuilder.Append(hashedBytes[i].ToString("x2"));
                }
                cadenaEncriptada = stringbuilder.ToString();
            }
            return cadenaEncriptada;
        }

        /// <summary>
        /// Metodo para calcular la fecha de la ejecucion o consumo partiendo de donde esta ubicado el usuario
        /// </summary>
        /// <returns></returns>
        public static DateTime FechaActual(int timeOffSet = 300)
        {
            TimeSpan offsetServer = DateTimeOffset.Now.Offset;
            var dt = DateTime.Now;

            if (offsetServer.TotalMinutes != (-1 * timeOffSet))
            {
                dt = dt.AddMinutes(-1 * timeOffSet);
            }

            return dt;
        }

        /// <summary>
        /// Metodo para convertir una IList<T> a Datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Metodo para convertir una IList<T> a Datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable ConvertIdsToDataTable(IList<int> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            foreach (int id in data)
            {
                table.Rows.Add(id);
            }
            return table;
        }

        /// <summary>
        /// Converts an object to its serialized XML format.
        /// </summary>
        /// <typeparam name="T">The type of object we are operating on</typeparam>
        /// <param name="value">The object we are operating on</param>
        /// <param name="removeDefaultXmlNamespaces">Whether or not to remove the default XML namespaces from the output</param>
        /// <param name="omitXmlDeclaration">Whether or not to omit the XML declaration from the output</param>
        /// <param name="encoding">The character encoding to use</param>
        /// <returns>The XML string representation of the object</returns>
        public static string ToXmlString<T>(this T value, bool removeDefaultXmlNamespaces = true, bool omitXmlDeclaration = true, Encoding encoding = null, bool header = true) where T : class
        {
            XmlSerializerNamespaces namespaces = removeDefaultXmlNamespaces ? new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }) : null;

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = omitXmlDeclaration;
            settings.CheckCharacters = false;

            using (var stream = new StringWriterWithEncoding(encoding))
            using (var writer = XmlWriter.Create(stream, settings))
            {
                var serializer = new XmlSerializer(value.GetType());
                serializer.Serialize(writer, value, namespaces);
                return stream.ToString();
            }
        }

        /// <summary>
        /// Creates an object instance from the specified XML string.
        /// </summary>
        /// <typeparam name="T">The Type of the object we are operating on</typeparam>
        /// <param name="value">The object we are operating on</param>
        /// <param name="xml">The XML string to deserialize from</param>
        /// <returns>An object instance</returns>
        public static T FromXmlString<T>(this T value, string xml) where T : class
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Metodo para convertir un numero a letras tipo texto
        /// </summary>
        /// <param name="numberAsString">Numero que se quiere convertir</param>
        /// <returns>Cadena con el texto representativo del numero</returns>
        public static string NumeroALetras(this decimal numberAsString)
        {
            string dec = "";            
            
            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            if (decimales > 0)
            {
                // dec = " PESOS CON " + decimales.ToString() + "/100";
                // dec = $" PESOS {decimales:0,0} /100";
            }
            //Código agregado por mí
            else
            {
                // dec = " PESOS CON " + decimales.ToString() + "/100";
                dec = $" PESOS {decimales:0,0} /100";
            }
            var res = NumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        private static string NumeroALetras(double value)
        {
            string num2Text; value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        }

        /// <summary>
        /// Metodo para convertir el mes de numero a letras
        /// </summary>
        /// <param name="id">Id del mes a buscar</param>
        /// <returns>String de mes convertido en letras</returns>
        public static string ConvertirMesNumeroALetras(int id)
        {
            string result = "";
            IList<string> meses = new List<string>() { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (var i = 1; i <= meses.Count; i++)
            {
                if (i == id)
                {
                    result = meses[i - 1];
                }
            }
            return result;
        }

        #endregion
    }
}