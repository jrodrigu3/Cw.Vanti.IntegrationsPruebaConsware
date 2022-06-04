//-----------------------------------------------------------------------
// <copyright file="Util.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>3/15/2019 9:27:15 AM</date>
// <summary>Código fuente clase Util.</summary>
//-----------------------------------------------------------------------
namespace WebAPI
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Clase usada para utilidades de la aplicacion.
    /// </summary>
    public static class UtilsWebApi
    {
        #region Attributes

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
        /// Gets or sets si los nombres de la lista de archivos cumplen con
        /// los mimeTypes permitidos.
        /// </summary>
        /// <param name="formFiles">Lista de archivos que van a ser procesados.</param>
        /// <returns>Lista con los nombres de los documentos no aceptados.</returns>
        public static List<string> GetFilesPathsNoAllowed(IFormFile formFiles)
        {
            List<string> filesPathNoAllowed = null;
            if (formFiles != null)
            {
                if (!HasMimeTypeAllowed(formFiles.FileName))
                {
                    if (filesPathNoAllowed == null)
                    {
                        filesPathNoAllowed = new List<string>();
                    }

                    filesPathNoAllowed.Add(formFiles.FileName);
                }

            }

            return filesPathNoAllowed;
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
        /// Metodo usado para convertir un objeto de tipo IFormFile a un array de byte[].
        /// </summary>
        /// <param name="documento">Objeto que va a ser convertido.</param>
        /// <returns>Array de bytes.</returns>
        public static byte[] ConvertFormFileToByte(IFormFile documento)
        {
            ////se carga el documento adjunto en memoria que va ser procesado.
            if (documento == null)
            {
                return null;
            }

            var stream = new MemoryStream();
            documento.CopyToAsync(stream).GetAwaiter().GetResult();
            return stream.ToArray();
        }

        /// <summary>
        /// Metodo usado para obtener el usuario por el token ingresado y capturado
        /// desde la cabecera.
        /// </summary>
        /// <returns>Los datos del usuario.</returns>
        public static string GetTokenFromAuthorization(Controller controller)
        {
            controller.Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            return authToken.First();
        }

        /// <summary>
        /// Metodo usado para obtener si la extension del archivo esta dentro
        /// de las definidas.
        /// </summary>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>True si cumple, false si no cumple</returns>
        private static bool HasMimeTypeAllowed(string fileName)
        {
            var types = GetMimeTypes();
            int extPosition = fileName.LastIndexOf(".");
            string ext = fileName.Substring(extPosition, fileName.Length - extPosition);

            if (types.ContainsKey(ext.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Metodo usado para obtener un diccionario con los Mimetypes
        /// habilitados.
        /// </summary>
        /// <returns>Diccionario con los Mimetypes habilitados.</returns>
        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                { ".pdf", "application/pdf" },
                { ".doc", "application/vnd.ms-word" },
                { ".docx", "application/vnd.ms-word" },
                { ".xls", "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet" },
                { ".png", "image/png" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".csv", "text/csv" }
            };
        }

        /// <summary>
        /// Metodo usado para obtener el nombre del archivo que se carga.
        /// </summary>
        /// <param name="documento">Objeto que va a ser procesado.</param>
        /// <returns>Nombre del archivo.</returns>
        public static string ObtenerNombreArchivo(IFormFile documento)
        {
            if (documento == null)
            {
                return null;
            }
            int extPosition = documento.FileName.LastIndexOf(".");
            string ext = documento.FileName.Substring(extPosition, documento.FileName.Length - extPosition);

            string fileNameWithoutExt = documento.FileName.Substring(0, documento.FileName.LastIndexOf("."));
            string nombreArchivo = UtilsWebApi.RemoveDiacritics(fileNameWithoutExt.Replace(" ", "_"))
                                   + "_"
                                   + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fffffff")
                                   + ext;
            return nombreArchivo;
        }

        #endregion
    }
}