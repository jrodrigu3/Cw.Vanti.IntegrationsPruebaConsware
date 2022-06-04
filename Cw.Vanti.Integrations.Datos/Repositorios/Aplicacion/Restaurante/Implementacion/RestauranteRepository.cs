//-----------------------------------------------------------------------
// <copyright file="ComidaRepository.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04-06-2022</date>
// <summary>Código fuente clase IRestauranteDtoDetalleRepository.</summary>
//-----------------------------------------------------------------------

namespace Cw.Vanti.Integrations.Datos
{
    using Cw.Vanti.Integrations.Datos.DbUtils;
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.Data.SqlClient;
    using Newtonsoft.Json;
    using System;
    using System.Data;
    using Cw.Vanti.Integrations.Entidades;

    
    /// <summary>
    /// Proporciona la implementacion definida para el repositorio
    /// </summary>
    internal class RestauranteRepository : EfRepository<Plato>, IRestauranteRepository
    {
        #region Attributes

        #endregion

        #region constructor
        public RestauranteRepository(IDatosUow datosUow)
            : base(datosUow)
        {

        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que guardar la entidad <see cref="Plato"/>
        /// </summary>
        /// <param name="plato">Entidad a ser creada</param>
        /// <returns>Retorna la informacion de la entidad que a sido creada.</returns>
        public PlatoResponseDto CrearPlato(PlatoRequestDto plato)
        {
            try
            {
                int errorCode = 0;
                StoredProcedure storedProcedure = new StoredProcedure("[Mat].[ChinoPlatosGuardar]");
                storedProcedure.AddParameter("@NombrePlato", plato.NombrePlato.ToString());

                SqlParameter outCodigoError = new SqlParameter("@CodigoError", 0)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                SqlParameter outResult = new SqlParameter("@Result", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                storedProcedure.AddParameter(outCodigoError);
                storedProcedure.AddParameter(outResult);

                this.ExecuteStoreProcedure<object>(storedProcedure);
                errorCode = Int32.Parse(outCodigoError.Value.ToString());
                PlatoResponseDto result = null;
                if (errorCode == 0)
                {
                    result = JsonConvert.DeserializeObject<PlatoResponseDto>(outResult.Value?.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que editar un plato <see cref="PlatoResponseDto"/>
        /// </summary>
        /// <param name="plato">Entidad a ser editada</param>
        /// <returns>PlatoResponseDto.</returns>
        public PlatoResponseDto EditarPlato(PlatoRequestDto plato)
        {
            try
            {
                int errorCode = 0;
                StoredProcedure storedProcedure = new StoredProcedure("[Mat].[PlatosEditar]");
                storedProcedure.AddParameter("@IdPlato", plato.IdPlato);
                storedProcedure.AddParameter("@NombrePlato", plato.NombrePlato);
                SqlParameter outCodigoError = new SqlParameter("@CodigoError", 0)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                SqlParameter outResult = new SqlParameter("@Result", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                storedProcedure.AddParameter(outCodigoError);
                storedProcedure.AddParameter(outResult);

                this.ExecuteStoreProcedure<object>(storedProcedure);
                errorCode = Int32.Parse(outCodigoError.Value.ToString());
                PlatoResponseDto result = null;
                if (errorCode == 0)
                {
                    result = JsonConvert.DeserializeObject<PlatoResponseDto>(outResult.Value?.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Metodo para llamar al procedimiento almacenado que editar la entidad <see cref="PlatoResponseDto"/>
        /// </summary>
        /// <param name="idPlato">id de la entidad a ser buscada</param>
        /// <returns>PlatoResponseDto.</returns>
        public PlatoResponseDto ObtenerPlatoPorId(int? idPlato)
        {
            try
            {
                int errorCode = 0;
                StoredProcedure storedProcedure = new StoredProcedure("[Mat].[PlatosObtenerPorId]");
                storedProcedure.AddParameter("@IdPlato", idPlato);

                SqlParameter outCodigoError = new SqlParameter("@CodigoError", 0)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                SqlParameter outResult = new SqlParameter("@Result", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = int.MaxValue
                };

                storedProcedure.AddParameter(outCodigoError);
                storedProcedure.AddParameter(outResult);

                this.ExecuteStoreProcedure<object>(storedProcedure);
                errorCode = Int32.Parse(outCodigoError.Value.ToString());
                PlatoResponseDto result = null;
                if (errorCode == 0)
                {
                    result = JsonConvert.DeserializeObject<PlatoResponseDto>(outResult.Value?.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                AppLogger.Instance().Exception(ex);
                throw new DatosException(ex.Message, ex);
            }
        }


        #endregion
    }
}
