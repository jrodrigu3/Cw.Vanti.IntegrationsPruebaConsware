
namespace Cw.Vanti.Integrations.WebApi
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Collections.Generic;
    
    /// <summary>
    /// Clase para configurar los parametros personalizados de tipo Headers para los EndPoints
    /// </summary>
    public class OperationFilters : IOperationFilter
    {

        /// <summary>
        /// Realiza la aplicacion de la configuracion de los Headers paralos Endpoint
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

        }
    }
}
