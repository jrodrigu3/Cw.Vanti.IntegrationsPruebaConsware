
//-----------------------------------------------------------------------
// <copyright file="RestauranteBL.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Jose Rodriguez</author>
// <date>04-06-2022</date>
// <summary>Código fuente clase RestauranteBL.</summary>
//-----------------------------------------------------------------------


namespace Cw.Vanti.Integrations.Negocio
{
    using Cw.Vanti.Integrations.Datos;
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Utils;
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Clase encargada de procesar el negocio para RestauranteBL
    /// </summary>
    public class RestauranteBL : IRestauramteBL
    {
        /// <summary>
        /// Importacion del negocio Negocio
        /// </summary>
        public NegocioBL Negocio { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RestauranteBL(NegocioBL negocio)
        {
            this.Negocio = negocio;
        }

        /// <summary>
        /// Clase encargada de procesar el negocio para RestauranteBL
        /// </summary>
        public PlatoResponseDto CrearPlatoBL(PlatoRequestDto plato)
        {
            try
            {
                PlatoResponseDto comida = null;

                using (var scope = new TransactionScope())
                {
                    comida = this.Negocio.Repositorios.RestauranteRepository.CrearPlato(plato);
                    scope.Complete();
                }
                return comida;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible buscar los datos solicitados.", ex);
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
        /// Metodo para editar un plato especifico
        /// </summary>
        /// <param name="platoRequestEdit">Objeto con la informacion de un plato que desea ser editada</param>
        /// <returns>PlatoResponseDto</returns>
        public PlatoResponseDto EditarPlatoBL(PlatoRequestDto platoRequestEdit)
        {
            try
            {
                PlatoResponseDto platoNew = null;

                using (var scope = new TransactionScope())
                {
                    if (platoRequestEdit != null)
                        platoNew = this.Negocio.Repositorios.RestauranteRepository.EditarPlato(platoRequestEdit);

                    scope.Complete();
                }

                return platoNew;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible buscar los datos solicitados.", ex);
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
        /// Metodo para buscar una encuesta por id especifico
        /// </summary>
        /// <param name="idPlato">Id unico del plato que esta siendo consultada</param>
        /// <returns>Objeto con la informacion del prestamo</returns>
        public PlatoResponseDto ObtenerPlatoPorIdBL(int idPlato)
        {
            try
            {
                PlatoResponseDto obtenido = null;

                obtenido = this.Negocio.Repositorios.RestauranteRepository.ObtenerPlatoPorId(idPlato);

                return obtenido;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible buscar los datos solicitados.", ex);
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
        /// Metodo para buscar una encuesta por id especifico
        /// </summary>
        /// <returns>Objeto con la informacion del prestamo</returns>
        public IList<PlatoResponseDto> ObtenerPlatoListadoBL()
        {
            try
            {
                IList<PlatoResponseDto> obtenido = null;

                obtenido = this.Negocio.Repositorios.RestauranteRepository.ObtenerPlatoListado();

                return obtenido;
            }
            catch (DatosException ex)
            {
                throw new FallaTecnicaException("No es posible buscar los datos solicitados.", ex);
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

    }
}
