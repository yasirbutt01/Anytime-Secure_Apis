﻿using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.Services.Interface.v1.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.Admin
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService service;

        public CommonController(ICommonService service)
        {
            this.service = service;
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
        [Route("getstates/{countryId:int}")]
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
        [Route("getcities/{stateId:int}")]
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
    }
}
