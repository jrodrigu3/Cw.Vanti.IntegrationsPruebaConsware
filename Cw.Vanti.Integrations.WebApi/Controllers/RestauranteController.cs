using Cw.Vanti.Integrations.DtoModel;
using Cw.Vanti.Integrations.Negocio;
using Cw.Vanti.Integrations.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using WebAPI;

namespace Cw.Vanti.Integrations.WebApi
{

    public class RestauranteController : BaseController
    {
        public IRestauramteBL RestauranteBL { get; set; }
        public RestauranteController(IRestauramteBL comidaBL) : base()
        {
            this.RestauranteBL = comidaBL;
        }

        /// <summary>
        /// 
        /// Metodo usado para guardar un plato.
        /// </summary>
        /// Objeto a ser creado de tipo <param name="platoRequestDto"></param>
        /// <returns>PlatoResponseDto.</returns>
        [HttpPost("platos")]
        [SwaggerResponse(statusCode: 200, type: typeof(PlatoResponseDto), description: "Metodo usado para guardar un plato.")]
        public IActionResult PlatoGuardar(PlatoRequestDto platoRequestDto)
        {
            try
            {
                //PlatoRequestDto data = new();
                //data.NombrePlato = platoRequestDto;

                PlatoResponseDto result = this.RestauranteBL.CrearPlatoBL(platoRequestDto);
                return this.HandleResponse(result, EResponseMessage.OperacionOk().Message);
            }
            catch (NegocioException ex)
            {
                return this.HandleErrorResponse(HttpStatusCode.OK, ex.Message);
            }
            catch (FallaTecnicaException)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
            catch (Exception ex)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
        }


        /// <summary>
        /// Metodo usado para editar un plato
        /// </summary>
        /// <param name="platosDTO">Objeto modulo con plato a editar</param>
        /// <returns>Objeto con la respuesta.</returns>
        [HttpPut("platos")]
        public IActionResult EditarEncuesta(PlatoRequestDto platosDTO)
        {
            try
            {
                PlatoResponseDto result = this.RestauranteBL.EditarPlatoBL(platosDTO);
                return this.HandleResponse(result, EResponseMessage.OperacionOk().Message);
            }
            catch (NegocioException ex)
            {
                return this.HandleErrorResponse(HttpStatusCode.OK, ex.Message);
            }
            catch (FallaTecnicaException)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
            catch (Exception)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
        }

        /// <summary>
        /// Metodo usado para obtener un objeto de la entidad por Id especifico
        /// </summary>
        /// <param name="idPlato">Id unico de la entidad a ser consultada</param>
        /// <returns>Objeto con la respuesta.</returns>
        [HttpGet("plato/{idPlato}")]
        public IActionResult ObtenerEncuestaPorId(int idPlato)
        {
            try
            {
                PlatoResponseDto result = this.RestauranteBL.ObtenerPlatoPorIdBL(idPlato);
                return this.HandleResponse(result, EResponseMessage.OperacionOk().Message);
            }
            catch (NegocioException ex)
            {
                return this.HandleErrorResponse(HttpStatusCode.OK, ex.Message);
            }
            catch (FallaTecnicaException)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
            catch (Exception)
            {
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, EResponseMessage.ErrorGral().Message);
            }
        }

    }
}
