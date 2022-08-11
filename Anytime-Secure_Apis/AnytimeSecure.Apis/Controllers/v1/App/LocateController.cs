using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Request.App.v1;
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
    public class LocateController : ControllerBase
    {
        private readonly ILocatorService service;
        
        public LocateController(ILocatorService service)
        {
            this.service = service;
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
        [Route("locateuser")]
        public async Task<IActionResult> LocateUser(LocateUserRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.LocateFriend(userId, request);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "No record found", Data = res });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
