//-----------------------------------------------------------------------
// <copyright file="SecretKeyManager.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>3/28/2019 5:18:56 PM</date>
// <summary>Código fuente clase SecretKeyManager.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Utils
{
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Rest.Azure;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase manejadora de los repositorios de llaves.
    /// </summary>
    public class SecretKeyManager
    {
        #region Attributes

        /// <summary>
        /// Objeto usado para acceder a los metodos para obtener
        /// la llave secreta.
        /// </summary>
        private static IKeyVault secretKey;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretKeyManager"/> class.
        /// </summary>
        protected SecretKeyManager()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Metodo usado para obtener la llave secreta.
        /// </summary>
        /// <param name="tag">Identificador de la llave.</param>
        /// <param name="clientId">Usuario para acceder al azure keyvault.</param>
        /// <param name="clientSecret">Contraseña para acceder al azure keyvault.</param>
        /// <returns>Llave secreta.</returns>
        public static async Task<string> GetValueFromSecretKey(string clientId, string clientSecret, string tag)
        {
            return await GetSecretKey(clientId, clientSecret).GetSecretKey(tag);
        }

        /// <summary>
        /// Metodo usado para obtener las llaves secretas.
        /// </summary>
        /// <param name="tag">Identificador de la llave.</param>
        /// <param name="clientId">Usuario para acceder al azure keyvault.</param>
        /// <param name="clientSecret">Contraseña para acceder al azure keyvault.</param>
        /// <returns>lista de llaves secretas.</returns>
        public static async Task<IPage<SecretItem>> GetSecretsKeys(string clientId, string clientSecret, string tag)
        {
            return await GetSecretKey(clientId, clientSecret).GetSecretsKeys(tag);
        }

        /// <summary>
        /// Metodo usado para obtener la instancia del
        /// Objeto usado para acceder a los metodos para obtener la llave secreta.
        /// </summary>
        /// <param name="clientId">Usuario para acceder al azure keyvault.</param>
        /// <param name="clientSecret">Contraseña para acceder al azure keyvault.</param>
        /// <returns>Objeto azure key vault.</returns>
        public static IKeyVault GetSecretKey(string clientId, string clientSecret)
        {
            if (secretKey == null)
            {
                secretKey = new AzureKeyVault(clientId, clientSecret);
            }

            return secretKey;
        }

        #endregion
    }
}