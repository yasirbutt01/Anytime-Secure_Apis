using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Request.Admin.v1;
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
    [AdminAuthorize(new[] { ERight.Building, ERight.Floor })]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IInfrastructureService service;

        public FloorController(IInfrastructureService service)
        {
            this.service = service;
        }

        /// <summary>        
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<FloorRequestResponse>>), 200)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<FloorRequestResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("getfloors")]
        public IActionResult GetFloors(ListGenralModelNew<FloorRequestResponse, Guid> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<GridGeneralModel<FloorRequestResponse>>()
                    { IsError = false, Message = "", Data = service.GetFloors(request) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>        
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<FloorRequestResponse>), 200)]
        [HttpGet]
        [Route("getfloordetail/{id}")]
        public IActionResult GetFloorDetail(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<FloorRequestResponse>()
                    { IsError = false, Message = "", Data = service.GetFloorDetail(id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [Route("savefloor")]
        public async Task<IActionResult> SaveFloor(ParameterRequest<List<CreateFloorRequest>> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.SaveFloor(request, userId)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
