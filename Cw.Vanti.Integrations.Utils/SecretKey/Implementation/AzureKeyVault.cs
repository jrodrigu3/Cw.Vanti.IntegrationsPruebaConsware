//-----------------------------------------------------------------------
// <copyright file="AzureKeyVault.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>3/28/2019 4:50:20 PM</date>
// <summary>Código fuente clase AzureKeyVault.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.Azure;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Se definen los metodos para acceder al repositorio de llaves de azure.
    /// </summary>
    public class AzureKeyVault : IKeyVault
    {
        #region Attributes

        /// <summary>
        /// Objeto usado para la generacion de token del servicio de azure.
        /// </summary>
        private AzureServiceTokenProvider azureServiceTokenProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVault"/> class.
        /// </summary>
        /// <param name="clientId">Identificador del cliente de azure.</param>
        /// <param name="clientSecret">Clave secreta del cliente de azure.</param>
        public AzureKeyVault(string clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Identificador del cliente.
        /// </summary>
        /// <value>Id del cliente.</value>
        private string ClientId { get; set; }

        /// <summary>
        /// Gets or sets Clave del cliente.
        /// </summary>
        /// <value>Clave secreta del cliente.</value>
        private string ClientSecret { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Metodo usado para obtener la llave secreta.
        /// </summary>
        /// <param name="tag">Identificador de la llave.</param>
        /// <returns>La llave secreta.</returns>
        public async Task<string> GetSecretKey(string tag)
        {
            try
            {
                var secret = await GetKeyVaultClient().GetSecretAsync(tag);
                return secret.Value;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Metodo usado para obtener las llaves secretas.
        /// </summary>
        /// <param name="tag">Identificador de la llave.</param>
        /// <returns>Lista de llaves secretas.</returns>
        public async Task<IPage<SecretItem>> GetSecretsKeys(string tag)
        {
            try
            {
                var secret = await GetKeyVaultClient().GetSecretsAsync(tag);
                return secret;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        ///  This method fetches a token from Azure Active Directory, which can then be provided to Azure Key Vault to authenticate
        /// </summary>
        /// <param name="authority">Parametro de authorizacion del api de zure key vault</param>
        /// <param name="resource">Parametro de recurso del api de zure key vault</param>
        /// <param name="scope">Parametro de entorno del api de zure key vault</param>
        /// <returns>Token de acceso al key vault</returns>
        public async Task<string> AuthenticateVault(string authority, string resource, string scope)
        {
            var clientCredential = new ClientCredential(this.ClientId, this.ClientSecret);
            var authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }

        /// <summary>
        /// Metodo usado para obtener el Objeto cliente para acceder a azure KeyVault.
        /// </summary>
        /// <returns>Objeto cliente para acceder a azure KeyVault.</returns>
        public KeyVaultClient GetKeyVaultClient()
        {
            return new KeyVaultClient(this.AuthenticateVault);
        }

        /// <summary>
        /// Sets Objeto usado para la generacion de token del servicio de azure.
        /// </summary>
        /// <param name="value">Nuevo valor.</param>
        public void SetAzureServiceTokenProvider(AzureServiceTokenProvider value)
        {
            this.azureServiceTokenProvider = value;
        }

        /// <summary>
        /// Gets Objeto usado para la generacion de token del servicio de azure.
        /// </summary>
        /// <returns>Objeto usado para la generacion de token del servicio de azure.</returns>
        public AzureServiceTokenProvider GetAzureServiceTokenProvider()
        {
            if (this.azureServiceTokenProvider == null)
            {
                this.azureServiceTokenProvider = new AzureServiceTokenProvider();
            }

            return this.azureServiceTokenProvider;
        }

        #endregion
    }
}