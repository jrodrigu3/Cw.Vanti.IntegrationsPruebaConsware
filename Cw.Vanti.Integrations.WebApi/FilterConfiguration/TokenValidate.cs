namespace Cw.Vanti.Integrations.WebApi
{
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Negocio;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    
    /// <summary>
    /// Clase usada para validar el token.
    /// </summary>
    public class TokenValidate : IActionFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenValidate"/> class.
        /// </summary>
        /// <param name="configuration">Objeto manejador de configuraciones.</param>
        /// <param name="usuarioBL">Objeto manejador de usuarios.</param>
        public TokenValidate(IConfiguration configuration, IUsuarioBL usuarioBL)
        {
            this.Configuration = configuration;
            this.UsuarioBL = usuarioBL;
        }

        /// <summary>
        /// Gets or sets objeto manejador de configuraciones.
        /// </summary>
        /// <value>Objeto manejador de configuraciones.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets Objeto manejador de usuarios.
        /// </summary>
        /// <value>Objeto manejador de usuarios.</value>
        public IUsuarioBL UsuarioBL { get; set; }

        /// <summary>
        /// Metodo que se ejecuta despúes del la validación.
        /// </summary>
        /// <param name="context">Contexto de la petición.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// Método que va a evaluar el token.
        /// </summary>
        /// <param name="context">Contexto de la petición.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                StringValues token = context.HttpContext.Request.Headers["Authorization"];
                StringValues timeZoneStringValues = context.HttpContext.Request.Headers["timeZone"];
                SwaggerConfig swaggerConfig = Configuration.GetSection("SwaggerConfig").Get<SwaggerConfig>();
                string tokenIn = token.FirstOrDefault()?.Replace(swaggerConfig.TipoAutorizacion, "").Trim();
                if (!string.IsNullOrEmpty(tokenIn))
                {
                    StringValues pagina = context.HttpContext.Request.Headers["idPagina"];
                    StringValues permiso = context.HttpContext.Request.Headers["idPermiso"];
                    string IpMaquina = context.HttpContext.Connection.RemoteIpAddress?.ToString();

                    int idPagina = string.IsNullOrEmpty(pagina.FirstOrDefault()) ? 0 : int.Parse(pagina.FirstOrDefault());
                    int idPermiso = string.IsNullOrEmpty(permiso.FirstOrDefault()) ? 0 : int.Parse(permiso.FirstOrDefault());
                    int timeZone = !timeZoneStringValues.Any() ? 0 : int.Parse(context.HttpContext.Request.Headers["timeZone"]);

                    int idPerfil = 0;
                    IList<ParamApi> collectionHeaders = new List<ParamApi>();
                    collectionHeaders.Add(new ParamApi() { Key = "timeZone", Value = timeZone.ToString() });
                    collectionHeaders.Add(new ParamApi() { Key = "idPagina", Value = idPagina.ToString() });
                    collectionHeaders.Add(new ParamApi() { Key = "idPermiso", Value = idPermiso.ToString() });

                    ClaimsPrincipal claim = this.UsuarioBL.ValidarToken(tokenIn);
                    if (claim == null)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                    else
                    {
                        UsuarioAutenticado usuarioAutenticado = new UsuarioAutenticado
                        {
                            Email = claim.FindFirstValue(ClaimTypes.Name),
                            Username = claim.FindFirstValue(ClaimTypes.Email),
                            Id = int.Parse(claim.FindFirstValue("IdUsuario")),
                            IpMaquina = IpMaquina,
                            IdPerfil = int.Parse(claim.FindFirstValue(ClaimTypes.Role)),
                            TimeZone = timeZone,
                            IdCliente = int.Parse(claim.FindFirstValue("IdCliente")),
                            IdEmpresa = int.Parse(claim.FindFirstValue("IdEmpresa")),
                            IdAgencia = int.Parse(claim.FindFirstValue("IdAgencia")),
                            CodigoAgencia = claim.FindFirstValue("CodigoAgencia"),
                            CodigoEmpresa = claim.FindFirstValue("CodigoEmpresa"),
                            CodigoCliente = claim.FindFirstValue("CodigoCliente"),
                            IdAfiliado = int.Parse(claim.FindFirstValue("IdAfiliado"))
                        };

                        context.HttpContext.Items["usuarioAutenticado"] = usuarioAutenticado;
                        context.HttpContext.Items["currentToken"] = tokenIn;
                        context.HttpContext.Items["idPermiso"] = (string)permiso;
                        context.HttpContext.Items["idPagina"] = (string)pagina;
                        context.HttpContext.Items["tokenValid"] = new
                        {
                            Username = usuarioAutenticado.Username,
                            IdPerfil = idPerfil,
                            IdPagina = idPagina,
                            IdPermiso = idPermiso
                        };
                    }
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
