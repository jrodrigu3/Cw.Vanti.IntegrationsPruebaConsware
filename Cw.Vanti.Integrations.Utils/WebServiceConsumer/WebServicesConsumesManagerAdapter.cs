//-----------------------------------------------------------------------
// <copyright file="WebServicesConsumesManagerAdapter.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>29/03/2020 17:00:47</date>
// <summary>Código fuente clase WebServicesConsumesManagerAdapter.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using Cw.Vanti.Integrations.DtoModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase usada como manejadora de consumos a servicios web.
    /// </summary>
    public class WebServicesConsumesManagerAdapter<T,U> : IWebServicesConsumesManagerAdapter<U>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServicesConsumesManagerAdapter<T>"/> class.
        /// </summary>
        public WebServicesConsumesManagerAdapter()
        {
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets a value indicating whether Objeto que realiza la peticion Http.
        /// </summary>
        /// <value>Objeto que realiza la peticion Http.</value>
        public HttpClient Client { get; set; }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Id de la entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<U> Delete(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad)
        {
            try
            {
                using (this.Client = new HttpClient())
                {
                    this.Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await this.Client.DeleteAsync(url);
                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<U>(await result.Content.ReadAsStringAsync());
                    }
                }

                return default(U);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por GET y obtener
        /// un objeto como respuesta. <see cref="IQueryable<T>"/>
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="getParam">Array de parámetro que van a ser usados para realizar la consulta.</param>
        /// <returns>Objeto como respuesta. <see cref="IQueryable<T>"/></returns>
        public async Task<U> Get(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, IList<ParamApi> queryParams = null, IList<ParamApi> headersParams = null)
        {
            try
            {
                string urlParams = url.ToString();
                if (queryParams != null && queryParams.Count > 0)
                {
                    urlParams += this.TransforQueryParamUrl(queryParams);
                }

                U resultadoEntidad = default;
                using (this.Client = new HttpClient())
                {
                    this.Client.DefaultRequestHeaders.Authorization = authorize;
                    if (headersParams != null && headersParams.Count > 0)
                    {
                        foreach (ParamApi paramH in headersParams)
                        {
                            this.Client.DefaultRequestHeaders.Add(paramH.Key, paramH.Value);
                        }
                    }
                    HttpResponseMessage result = await this.Client.GetAsync(new Uri(urlParams));
                    if (result.IsSuccessStatusCode)
                    {
                        resultadoEntidad = await result.Content.ReadAsAsync<U>();
                    }
                    else
                    {
                        throw new Exception("Error en la petición: StatusCode=" + result.StatusCode + ", Mensaje=" + result.ReasonPhrase);
                    }
                }

                return resultadoEntidad;
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por POST dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<U> Post(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad)
        {
            try
            {
                using (this.Client = new HttpClient())
                {
                    this.Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await this.Client.PostAsync(url, entidad, mediaTypeFormatter);
                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<U>(await result.Content.ReadAsStringAsync());
                    }
                }

                return default(U);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<U> Put(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad)
        {
            try
            {
                using (this.Client = new HttpClient())
                {
                    this.Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await this.Client.PutAsync(url, entidad, mediaTypeFormatter);
                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<U>(await result.Content.ReadAsStringAsync());
                    }
                }

                return default(U);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Trasforma una lista de parametros a formato url QueryParams
        /// </summary>
        /// <param name="paramsQuery">Listado de parametros</param>
        /// <returns></returns>
        public string TransforQueryParamUrl(IList<ParamApi> queryParams)
        {
            string urlParams = "?";
            foreach (var param in queryParams)
            {
                urlParams += param.Key + "=" + param.Value + "&";
            }
            urlParams = urlParams.Substring(0, (urlParams.Length - 1));
            return urlParams;
        }

        #endregion
    }
}