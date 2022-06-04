//----------------------------------------------------
// <copyright file="IModuloBL.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase IModuloBL.</summary>
//----------------------------------------------------

namespace WebAPI
{
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Security.Claims;

    /// <summary>
    /// Define la estructura y comportamiento base de los controladores
    /// empleados en la API.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        ///
        /// </summary>
        private UsuarioAutenticado usuarioAutenticado;


        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public string currentToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public string idPagina { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public string idPermiso { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 
        /// </summary>
        /// <value></value>
        public HeaderDto header { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController()
        {
        }

        /// <summary>
        /// Gets or sets el Id del usuario autenticado por token.
        /// </summary>
        /// <returns>Id del usuario autenticado por token.</returns>
        protected UsuarioAutenticado UsuarioAutenticado
        {
            get
            {
                if (this.usuarioAutenticado == null)
                {
                    UsuarioAutenticado headerUsuario = (UsuarioAutenticado) HttpContext.Items["usuarioAutenticado"];
                    
                    this.usuarioAutenticado = headerUsuario != null ? headerUsuario : new UsuarioAutenticado() { Id = 0 };
                    this.usuarioAutenticado.IpMaquina = HttpContext.Connection.RemoteIpAddress?.ToString();
                    if (this.usuarioAutenticado.IpMaquina is null) 
                        this.usuarioAutenticado.IpMaquina = "N/A";
                    this.usuarioAutenticado.TimeZone = HttpContext.Request.Headers["timeZone"].Count != 0 ? int.Parse(HttpContext.Request.Headers["timeZone"].ToString()) : 300;
                    var claims = HttpContext.User.Claims.ToList();
                    if (claims.Count > 0)
                    {
                        this.usuarioAutenticado.Id = int.Parse(claims.FirstOrDefault(c => c.Type == "IdUsuario").Value);
                        this.usuarioAutenticado.IdCliente = int.Parse(claims.FirstOrDefault(c => c.Type == "IdCliente").Value);
                        this.usuarioAutenticado.Username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                        this.usuarioAutenticado.IdPerfil = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value);
                        this.usuarioAutenticado.Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                        this.usuarioAutenticado.IdEmpresa = int.Parse(claims.FirstOrDefault(c => c.Type == "IdEmpresa").Value);
                        this.usuarioAutenticado.IdTipoUsuario = int.Parse(claims.FirstOrDefault(c => c.Type == "IdTipoUsuario").Value);
                    }
                }

                return usuarioAutenticado;
            }
        }

        /// <summary>
        /// Gets or sets el Id del usuario autenticado por token.
        /// </summary>
        /// <returns>Id del usuario autenticado por token.</returns>
        protected string CurrentToken
        {
            get
            {
                this.currentToken = (string)HttpContext.Items["currentToken"];

                return this.currentToken;
            }
        }

        /// <summary>
        /// Gets or sets el Id del usuario autenticado por token.
        /// </summary>
        /// <returns>Id del usuario autenticado por token.</returns>
        protected string IdPagina
        {
            get
            {
                this.idPagina = (string)HttpContext.Items["idPagina"];

                return this.idPagina;
            }
        }

        /// <summary>
        /// Gets or sets el Id del usuario autenticado por token.
        /// </summary>
        /// <returns>Id del usuario autenticado por token.</returns>
        protected string IdPermiso
        {
            get
            {
                this.idPermiso = (string)HttpContext.Items["idPermiso"];

                return this.idPermiso;
            }
        }

        /// <summary>
        /// Gets or sets el Id del usuario autenticado por token.
        /// </summary>
        /// <returns>Id del usuario autenticado por token.</returns>
        protected HeaderDto Header
        {
            get
            {
                this.header = new HeaderDto()
                {
                    IdPermiso = (string)HttpContext.Items["idPermiso"],
                    IdPagina = (string)HttpContext.Items["idPagina"],
                    CurrentToken = (string)HttpContext.Items["currentToken"]
                };

                return this.header;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que gestiona la dirección ip del cliente.
        /// </summary>
        /// <value>Objeto que gestiona la dirección ip del cliente.</value>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleErrorResponse(HttpStatusCode code, object message)
        {
            return this.StatusCode((int)code, ResponseResult.CreateError(message, new object()));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <param name="data">objeto respuesta.</param>
        /// <param name="isCaptcha">Establece si se debe enviar el captcha.</param>
        /// <param name="isExpired">Establece si la contraseña ha expirado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleErrorResponse(HttpStatusCode code, string message, object data, bool isCaptcha, bool isExpired)
        {
            return this.StatusCode((int)code, LoginReponseResult.CreateError(message, data, isCaptcha, isExpired));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <param name="data">objeto respuesta.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleErrorResponse(HttpStatusCode code, string message, object data)
        {
            return this.StatusCode((int)code, ResponseResult.CreateError(message, data));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleArrayErrorResponse(HttpStatusCode code, object message)
        {
            return this.StatusCode((int)code, ResponseResult.CreateError(message, new object[0]));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponse(object data, string message)
        {
            return this.Ok(ResponseResult.CreateResponse(true, message, data));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponse(object data)
        {
            return this.Ok(ResponseResult.CreateResponse(true, null, data));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <param name="meta">Enumerado con el meta del mensaje.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponsePagination(object data, string message, object meta)
        {
            return this.Ok(ResponseResultPagination.CreateResponse(true, message, data, meta));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <param name="exist">True o false.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponseExist(object data, string message, bool exist)
        {
            return this.Ok(ResponseResultExist.CreateResponse(true, message, data, exist));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="messages">Mensajes asociados al error.</param>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponseList(object data, object messages)
        {
            return this.StatusCode((int)HttpStatusCode.OK, ResponseResult.CreateResponseList(true, messages, data));
        }

        /// <summary>
        /// Método que va a evaluar el token.
        /// </summary>
        /// <param name="context">Contexto de la petición.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // this.IPAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            // this.VerifyModelState(context);
        }

        /// <summary>
        /// Metodo usado para verificar el estado del modelo a consultar.
        /// </summary>
        /// <param name="context">Contexto de la peticion.</param>
        private void VerifyModelState(ActionExecutingContext context)
        {
            try
            {
                if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
                {
                    foreach (var parameter in descriptor.MethodInfo.GetParameters())
                    {
                        object args = null;
                        if (context.ActionArguments.ContainsKey(parameter.Name))
                        {
                            args = context.ActionArguments[parameter.Name];
                        }

                        ValidateAttributes(parameter, args, context.ModelState);
                    }
                }

                if (!context.ModelState.IsValid)
                {
                    ResponseResult responseResult = ResponseResult.CreateError("error", context.ModelState.Select(s => new { s.Key, s.Value.Errors }));
                    context.Result = new OkObjectResult(responseResult);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
            }
        }

        /// <summary>
        /// Metodo usado para verificar que los parametros enviados en la peticion
        /// correspondan a la estructura del modelo.
        /// </summary>
        /// <param name="parameter">Parametros a verificar.</param>
        /// <param name="args">Acción a ejecutar.</param>
        /// <param name="modelState">Contiene el estado del modelo.</param>
        private void ValidateAttributes(ParameterInfo parameter, object args, ModelStateDictionary modelState)
        {
            foreach (var attributeData in parameter.CustomAttributes)
            {
                var attributeInstance = parameter.GetCustomAttribute(attributeData.AttributeType);

                if (attributeInstance is ValidationAttribute validationAttribute)
                {
                    var isValid = validationAttribute.IsValid(args);
                    if (!isValid)
                    {
                        modelState.AddModelError(parameter.Name, validationAttribute.FormatErrorMessage(parameter.Name));
                    }
                }
            }
        }
    }
}
