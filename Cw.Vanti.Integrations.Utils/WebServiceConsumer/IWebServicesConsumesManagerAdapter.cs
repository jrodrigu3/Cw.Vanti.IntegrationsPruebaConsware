//-----------------------------------------------------------------------
// <copyright file="IWebServicesConsumesManagerAdapter.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>29/03/2020 17:02:19</date>
// <summary>Código fuente clase IWebServicesConsumesManagerAdapter.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using Cw.Vanti.Integrations.DtoModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Se definen los métodos de gestionar cualquier consumo con un api de tercero.
    /// </summary>
    public interface IWebServicesConsumesManagerAdapter<U>
    {
        /// <summary>
        /// Metodo usado para hacer el consumo por GET y obtener
        /// un objeto como respuesta. <see cref="IQueryable<T>"/>
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="paramsQuery">Array de parámetro que van a ser usados para realizar la consulta.</param>
        /// <returns>Objeto como respuesta. <see cref="IQueryable<T>"/></returns>
        Task<U> Get(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, IList<ParamApi> paramsQuery = null, IList<ParamApi> headersParams = null);

        /// <summary>
        /// Metodo usado para hacer el consumo por POST dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<U> Post(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad);

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<U> Put(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad);

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Id de la entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<U> Delete(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad);
    }
}