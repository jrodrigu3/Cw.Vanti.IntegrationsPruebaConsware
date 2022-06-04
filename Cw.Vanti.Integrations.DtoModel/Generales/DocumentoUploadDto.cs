//-----------------------------------------------------------------------
// <copyright file="DocumentoUploadDto.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aarrieta</author>
// <date>09/06/2021 14:36:27</date>
// <summary>Código fuente clase DocumentoUploadDto.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.DtoModel
{
    /// <summary>
    /// Interfaz que define el objeto de transferencia de una imagen
    /// </summary>
    public class DocumentoUploadDto
    {

        /// <summary>
        /// Gets or sets a value del id del documento
        /// </summary>
        /// <value>Id</value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether archivo de la imagen
        /// </summary>
        /// <value>Archivo</value>
        public string Archivo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether nombre de la imagen
        /// </summary>
        /// <value>Nombre</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether archivo de la Url
        /// </summary>
        /// <value>Url</value>
        public string Ruta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether archivo de la Url
        /// </summary>
        /// <value>RutaStorage</value>
        public string RutaStorage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether id del documento al que pertenece el adjunto
        /// </summary>
        /// <value>Url</value>
        public int? IdDocumento { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether id de la entidad al que pertenece el adjunto
        /// </summary>
        /// <value>Url</value>
        public int? IdEntidad { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether id de la entidad al que pertenece el adjunto
        /// </summary>
        /// <value>Url</value>
        public decimal? Size { get; set; }
    }
}