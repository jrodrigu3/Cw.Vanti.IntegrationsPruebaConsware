//-----------------------------------------------------------------------
// <copyright file="UsuarioIdentityBL.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>4/1/2019 9:17:36 AM</date>
// <summary>Código fuente clase UsuarioBL.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Negocio
{
    using Cw.Vanti.Integrations.Datos;
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// Se define la estructura base de la logica de negocio
    /// que representa un usuario.
    /// </summary>
    public class UsuarioBL : IUsuarioBL
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioBL"/> class.
        /// </summary>
        /// <param name="configuration">Manejador de caché.</param>
        /// <param name="negocio">Objeto principal de negocio</param>
        public UsuarioBL(IConfiguration configuration, NegocioBL negocio)
        {
            this.Negocio = negocio;
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets objeto manejador de configuraciones.
        /// </summary>
        /// <value>Objeto manejador de configuraciones.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets objeto que contiene las configuraciones del servicio de twillio.
        /// </summary>
        public NegocioBL Negocio { get; set; }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo usado para validar la vigencia del token.
        /// </summary>
        /// <param name="jwt">Token que va a ser validado.</param>
        /// <param name="idUsuario">Id del usuario que intenta acceder.</param>
        /// <returns>True sí el token es valido, false sí no es valido.</returns>
        public ClaimsPrincipal ValidarToken(string jwt, int idUsuario)
        {
            try
            {
                JwtTokenConfig jwtTokenConfig = Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();
                ClaimsPrincipal user = null;
                if (!string.IsNullOrEmpty(jwt))
                {
                    TokenValidationParameters validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.FromHours(jwtTokenConfig.AccessTokenExpiration),
                        SaveSigninToken = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.SecretKey)),
                    };

                    // Now validate the token. If the token is not valid for any reason, an exception will be thrown by the method
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    SecurityToken validatedToken = handler.ReadToken(jwt);
                    if (validatedToken != null)
                    {
                        /*
                        tokenExist = this.Negocio.Repositorios.RefreshTokenRepository.FindAll().Any(u => u.TokenUsuario == jwt);
                        tokenWasRevoked = this.Negocio.Repositorios.RefreshTokenRepository.FindAll().Any(u => u.IsRevoked && u.TokenUsuario == jwt);

                        if (DateTime.Now < validatedToken.ValidTo && tokenExist && !tokenWasRevoked)
                        {
                            user = handler.ValidateToken(jwt, validationParameters, out validatedToken);
                        }
                        */
                    }
                }

                return user;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible guardar los datos solicitados.", ex);
            }
            catch (NegocioException ex)
            {
                throw new NegocioException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new FallaTecnicaException("Ha ocurrido un error procesando la solicitud.", ex);
            }
        }

        /// <summary>
        /// Metodo usado para actualizar el token.
        /// </summary>
        /// <param name="token">Objeto que contiene la informacion del token.</param>
        /// <returns>True sí se guardó.</returns>
        public bool ActualizarJwr(Token token)
        {
            try
            {
                /*
                Token tokenExist = this.Negocio.Repositorios.RefreshTokenRepository.FindByCondition(f => f.Username.Equals(token.Username)).FirstOrDefault();
                if (tokenExist != null)
                {
                    tokenExist.TokenUsuario = token.TokenUsuario;
                    tokenExist.RefreshTokenGUID = token.RefreshTokenGUID;
                    tokenExist.IsRevoked = token.IsRevoked;
                    tokenExist.FechaModificacion = token.FechaModificacion;
                    this.Negocio.Repositorios.RefreshTokenRepository.Update(tokenExist);
                }
                else
                {
                    token.TokenId = 0;
                    this.Negocio.Repositorios.RefreshTokenRepository.Add(token);
                }

                this.Negocio.Repositorios.SaveChanges();
                */
                return true;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible guardar los datos solicitados.", ex);
            }
            catch (NegocioException ex)
            {
                throw new NegocioException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new FallaTecnicaException("Ha ocurrido un error procesando la solicitud.", ex);
            }
        }

        #endregion
    }
}