using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Response.App.v1;
using AnytimeSecure.Services.Interface.v1.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.App
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AppCommonController : ControllerBase
    {
        private readonly IAppCommonService service;

        public AppCommonController(IAppCommonService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Content from this Api
        /// </summary>
        /// <param name="contentId">1. for Terms And Condition
        /// 2. for Help</param>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [AppAuthorize(false)]
        [HttpGet]
        [Route("getcontent")]
        public IActionResult GetContent(int contentId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new Response<string>() { IsError = false, Message = "", Data = service.GetContent(contentId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<General<int>>>), 200)]
        [HttpGet]
        [Route("getcountries")]
        public IActionResult GetCountries()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new Response<List<General<int>>>() { IsError = false, Message = "", Data = service.GetCountries() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<General<int>>>), 200)]
        [HttpGet]
        [Route("getstates")]
        public IActionResult GetStates(int countryId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new Response<List<General<int>>>() { IsError = false, Message = "", Data = service.GetStates(countryId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<General<int>>>), 200)]
        [HttpGet]
        [Route("getcities")]
        public IActionResult GetCities(int stateId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new Response<List<General<int>>>() { IsError = false, Message = "", Data = service.GetCities(stateId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<StaticResponse>), 200)]
        [AppAuthorize(true)]
        [HttpGet]
        [Route("getstaticdata")]
        public IActionResult StaticData()
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                return StatusCode(StatusCodes.Status200OK, new Response<StaticResponse>() { IsError = false, Message = "", Data = service.StaticData(userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
