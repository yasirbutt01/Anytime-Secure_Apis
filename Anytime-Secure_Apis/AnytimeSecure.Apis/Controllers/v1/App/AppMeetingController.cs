using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.Common;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Request.App.v1;
using AnytimeSecure.DataViewModels.Response.App.v1;
using AnytimeSecure.Services.Interface.v1.App;
using Microsoft.AspNetCore.Hosting;
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
    public class AppMeetingController : ControllerBase
    {
        private readonly IAppMeetingsService service;
        private readonly IWebHostEnvironment _env;

        public AppMeetingController(IAppMeetingsService service, IWebHostEnvironment _env)
        {
            this.service = service;
            this._env = _env;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<General<Guid>>), 200)]
        [ProducesResponseType(typeof(Response<General<Guid>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpGet]
        [Route("getroomtypes")]
        public IActionResult GetRoomtypes()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<General<Guid>>>() { IsError = false, Message = "", Data = service.GetRoomTypes() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<AvailableBuidlingResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<AvailableBuidlingResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("getavailablebuildings")]
        public async Task<IActionResult> GetAvailableBuildings(AvailableBuildingsRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<AvailableBuidlingResponse>>() { IsError = false, Message = "", Data =await service.GetAvailableBuidling(request) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<RoomsData>>), 200)]
        [ProducesResponseType(typeof(Response<List<RoomsData>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("getavailablerooms")]
        public async Task<IActionResult> GetAvailablRooms(AvailableBuildingsRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<RoomsData>>() { IsError = false, Message = "", Data = await service.GetAvailableRooms(request) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("createmeeting")]
        public async Task<IActionResult> CreateMeeting(CreateMeetingRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.CreateMeeting(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<bool>() { IsError = false, Message = Error.SlotTaken, Data =  res });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<DashboardResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<DashboardResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(true)]
        [HttpPost]
        [Route("getdashboard")]
        public async Task<IActionResult> GetDashboard(DashboardRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<DashboardResponse>>() { IsError = false, Message = "", Data =await service.GetDashboard(request,userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<DashboardResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<DashboardResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(true)]
        [HttpPost]
        [Route("getmeetingbydate")]
        public async Task<IActionResult> GetMeetingByDate(MeetingOnCalenderRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<DashboardResponse>>() { IsError = false, Message = "", Data = await service.GetMeetingByDate(request ,userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<MeetingDetailResponse>), 200)]
        [ProducesResponseType(typeof(Response<MeetingDetailResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(true)]
        [HttpGet]
        [Route("getmeetingdetail")]
        public async Task<IActionResult> GetMeetingDetail(Guid meetingId)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<MeetingDetailResponse>() { IsError = false, Message = "", Data = await service.GetMeetingDetail(meetingId,userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("updatemeetingdescription")]
        public async Task<IActionResult> UpdateMeetingDiscription(UpdateMeetingStringRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.UpdateMeetingDiscription(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("updatemeetingtitle")]
        public async Task<IActionResult> UpdateMeetingTitle(UpdateMeetingStringRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.UpdateMeetingTitle(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(403)]
        //[ProducesResponseType(500)]
        //[ProducesResponseType(typeof(Response<bool>), 200)]
        //[ProducesResponseType(typeof(Response<bool>), 403)]
        //[ProducesResponseType(typeof(string[]), 400)]
        //[HttpPost]
        //[AppAuthorize(true)]
        //[Route("updatemeetingtime")]
        //public async Task<IActionResult> UpdateMeetingTime(UpdateMeetingTimeRequest request)
        //{
        //    try
        //    {
        //        var userId = Guid.Parse(RouteData.Values["userId"].ToString());
        //        if (!ModelState.IsValid)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
        //        }
        //        bool res = await service.UpdateMeetingTime(request, userId);
        //        if (res)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("cancelmeeting")]
        public async Task<IActionResult> CancelMeeting(IdRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.CancelMeeting(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }

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
        [ProducesResponseType(typeof(Response<AttendeeImageResponse>), 200)]
        [ProducesResponseType(typeof(Response<AttendeeImageResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(true)]
        [Route("uploadattendeeimage")]
        public async Task<IActionResult> UpdateAttendeeImage([FromForm] IdRequest request, IFormFile profilePicture)
        {
            try
            {
                FileUrlResponce file = new FileUrlResponce();
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                Guid userId = Guid.Empty;
                if (!String.IsNullOrEmpty(RouteData.Values["userId"].ToString()))
                {
                    userId = Guid.Parse(RouteData.Values["userId"].ToString());
                }
                if (profilePicture != null && profilePicture.Length > 0)
                {
                    file = new SaveFiles().SaveImage(_env.WebRootPath, profilePicture, "ProfilePics", "ProfilePicsThum");
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<AttendeeImageResponse>()
                    { IsError = false, Message = "", Data = await service.UpdateAttendeeImage(file, userId, request.Id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("updatemeetingspecifications")]
        public async Task<IActionResult> UpdateMeetingSpecifications(UpdateSpecifications request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.UpdateMeetingSpecifications(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<MeetingTimeResponse>), 200)]
        [ProducesResponseType(typeof(Response<MeetingTimeResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(true)]
        [HttpPost]
        [Route("getmeetingtime")]
        public async Task<IActionResult> GetMeetingTime(IdRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<MeetingTimeResponse>() { IsError = false, Message = "", Data = await service.GetMeetingTime(request) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("updatemeetingtime")]
        public async Task<IActionResult> UpdateMeetingTime(MeetingTimeResponse request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var res = await service.UpdateMeetingTime(request, userId);
                if (res.Item1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "Slot not avilable", Data = res.Item2 });
                }
                if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res.Item2 });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res.Item2 });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<AttendeeResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<AttendeeResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AppAuthorize(false)]
        [HttpPost]
        [Route("getattendees")]
        public async Task<IActionResult> GetAttendees(AttendeeRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<AttendeeResponse>>() { IsError = false, Message = "", Data = await service.GetAttendees(request,userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("saveattendee")]
        public async Task<IActionResult> AddMeetingAttendee(MeetingAttendeeRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.AddMeetingAttendee(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("checkout")]
        public IActionResult checkOut(IdRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = service.CheckOut(request, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "No meeting found", Data = res });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [AppAuthorize(true)]
        [Route("attachcovidreport")]
        public IActionResult AttchedCovid(IdRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = service.AttchedCovid(request.Id, userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response<bool>() { IsError = true, Message = "Please try again", Data = res });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
