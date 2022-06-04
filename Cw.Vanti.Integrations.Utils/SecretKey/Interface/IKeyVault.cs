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
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Rest.Azure;
    using System.Threading.Tasks;

    /// <summary>
    /// Se definen los metodos basicos para acceder a un repositorio de llaves.
    /// </summary>
    public interface IKeyVault
    {
        /// <summary>
        /// Metodo usado para obtener la llave secreta.
        /// </summary>
        /// <param name="tag">identificador de la llave.</param>
        /// <returns>la llave secreta.</returns>
        Task<string> GetSecretKey(string tag);

        /// <summary>
        /// Metodo usado para obtener las llaves secretas.
        /// </summary>
        /// <param name="tag">identificador de la llave.</param>
        /// <returns>las llaves secretas.</returns>
        Task<IPage<SecretItem>> GetSecretsKeys(string tag);

        /// <summary>
        /// Metodo usado para obtener el Objeto cliente para acceder a azure KeyVault.
        /// </summary>
        /// <returns>Objeto cliente para acceder a azure KeyVault.</returns>
        KeyVaultClient GetKeyVaultClient();
    }
}