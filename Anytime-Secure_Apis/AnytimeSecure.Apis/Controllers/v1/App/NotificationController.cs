using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Response.App.v1;
using AnytimeSecure.Services.Interface.v1.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.App
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationService notificationService;
        private readonly IConfiguration configuration;
        public NotificationController(INotificationService service, IConfiguration configuration)
        {
            this.notificationService = service;
            this.configuration = configuration;
        }
        /// <summary>
        ///         ENUMS:
        ///         SentYouCard,
        ///         CardSent,
        ///         PackageSubscribed,
        ///         SentYouReminder,
        ///         CalenderEventReminder
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<NotificationListResponse>>), 200)]
        [HttpGet]
        [Route("getnotifications")]
        [AppAuthorize(true)]
        public IActionResult GetNotifications(int skip, int take)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                return StatusCode(StatusCodes.Status200OK, new Response<List<NotificationListResponse>>() { IsError = false, Message = "", Data = notificationService.GetNotificationList(userId, skip, take) });
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
        [HttpGet]
        [Route("markasread")]
        [AppAuthorize(true)]
        public IActionResult MarkAsRead(string notificationId)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = notificationService.Read(string.IsNullOrWhiteSpace(notificationId) ? "" : notificationId) });
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
        [HttpGet]
        [Route("delete")]
        [AppAuthorize(true)]
        public IActionResult DeleteNotification(string notificationId)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = notificationService.Delete(userId, string.IsNullOrWhiteSpace(notificationId) ? "" : notificationId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
