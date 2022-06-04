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
    /// <summary>
    /// Esta clase define la estructura para la carga de archivos.
    /// </summary>
    public class FileUploadUtil
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadUtil"/> class.
        /// </summary>
        public FileUploadUtil()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Nombre del archivo.
        /// </summary>
        /// <value>Nombre del archivo.</value>
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que contiene el archivo.
        /// </summary>
        /// <value>Objeto que contiene el archivo.</value>
        public byte[] File { get; set; }

        #endregion

        #region Methods And Functionss

        #endregion
    }
}