using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Request.Admin.v1;
using AnytimeSecure.DataViewModels.Request.Admin.v1.Laboratory;
using AnytimeSecure.Services.Interface.v1.Admin.Laboratory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.Admin.Laboratory
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AdminAuthorize(new[] { ERight.Test, ERight.Laboratory })]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService service;

        public TestController(ITestService service)
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
        [ProducesResponseType(typeof(Response<GridGeneralModel<CreateTestRequest>>), 200)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<CreateTestRequest>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("get")]
        public IActionResult Get(ListGenralModelNew<CreateTestRequest, bool> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<GridGeneralModel<CreateTestRequest>>()
                    { IsError = false, Message = "", Data = service.Get(request) });
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
        [ProducesResponseType(typeof(Response<CreateTestRequest>), 200)]
        [HttpGet]
        [Route("getdetail/{id}")]
        public IActionResult GetDetail(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<CreateTestRequest>()
                    { IsError = false, Message = "", Data = service.GetDetail(id) });
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
        [Route("save")]
        public async Task<IActionResult> Save(ParameterRequest<List<CreateTestRequest>> request)
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
                        Data = await service.Save(request, userId)
                    });
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
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [HttpGet]
        [Route("controllactivation/{id}/{isDisable:bool}/{status:bool}")]
        public async Task<IActionResult> ControllActivation(Guid id, bool isDisable, bool status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ControllActivation(id, isDisable, status, userId)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
