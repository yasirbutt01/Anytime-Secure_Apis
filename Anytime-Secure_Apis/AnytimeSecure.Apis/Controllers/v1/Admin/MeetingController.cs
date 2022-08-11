using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Response.Admin.v1;
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
    [AdminAuthorize(new[] { ERight.Meeting })]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService service;

        public MeetingController(IMeetingService service)
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
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetMeetingResponse>>), 200)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetMeetingResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("get")]
        public IActionResult Get(ListGenralModelNew<GetMeetingResponse, DateTime> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<GridGeneralModel<GetMeetingResponse>>()
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
        [ProducesResponseType(typeof(Response<MeetingDetailResponse>), 200)]
        [HttpGet]
        [Route("getdetail/{id}")]
        public IActionResult GetDetail(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<MeetingDetailResponse>()
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
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [HttpGet]
        [Route("changestatus/{id}/{status:int}")]
        public async Task<IActionResult> ChangeStatus(Guid id, int status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ChangeStatus(id, status, userId)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
