using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.Common;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.App.v1;
using AnytimeSecure.DataViewModels.Request.App.v1;
using AnytimeSecure.DataViewModels.Response.App.v1;
using AnytimeSecure.Services.Interface.v1.App;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.App
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AppAccountController : ControllerBase
    {
        private readonly IAppAccountService service;
        private readonly IConfiguration configuration; 
        private readonly IWebHostEnvironment _env;
        public AppAccountController(IAppAccountService service, IConfiguration configuration, IWebHostEnvironment _env)
        {
            this.service = service; 
            this._env = _env;
            this.configuration = configuration;
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
        [ProducesResponseType(typeof(Response<CheckEmailResponse>), 200)]
        [ProducesResponseType(typeof(Response<CheckEmailResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("checkemail")]
        public IActionResult CheckEmail(CheckEmailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK,new Response<CheckEmailResponse>(){ IsError = false, Message = "", Data = service.CheckEmail(request.email) });
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
        [AppAuthorize(false)]
        [Route("updatepassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                Guid userId = Guid.Empty;
                if (!String.IsNullOrEmpty(RouteData.Values["userId"].ToString()))
                {
                    userId = Guid.Parse(RouteData.Values["userId"].ToString());
                }
                var res = await service.UpdatePassword(request, userId);
                if (res.Item1)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<bool>() { IsError = true, Message = "Old password does not matched", Data = res.Item2 });
                }
                else if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res.Item2 });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "No user found", Data = res.Item2 });
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
        [Route("resendemail")]
        public async Task<IActionResult> ResendEmail(ResendEmailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var res = await service.ResendVerificationEmail(request.Email, request.IsEmailVerification);
                if (!res.Item1)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<bool>() { IsError = true, Message = Error.UserDoesnotExists, Data = false });
                }
                if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<bool>() { IsError = true, Message = Error.EmailAlreadyVerified, Data = false });
                }
                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = true });
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
        [ProducesResponseType(typeof(Response<CodeVerificationResponse>), 200)]
        [ProducesResponseType(typeof(Response<CodeVerificationResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("codeverification")]
        public async Task<IActionResult> CodeVerification(CodeVerificationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                CodeVerificationResponse res = await service.CodeVerification(request);
                if (res.IsCodeMatched)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<CodeVerificationResponse>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<CodeVerificationResponse>() { IsError = true, Message = "Code is not matched", Data = res });
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<LoginResponse>), 200)]
        [ProducesResponseType(typeof(Response<LoginResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var res = await service.AppLoginUser(request);

                switch (res.Item2)
                {
                    case ELoginStatus.Success:
                        return StatusCode(StatusCodes.Status200OK, new Response<LoginResponse>() { IsError = false, Message = "", Data = res.Item1 });
                    case ELoginStatus.EmailNotVerified:
                        return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.AccoutNotVerified, Data = new LoginResponse() });
                    case ELoginStatus.NotApproved:
                        return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.AccoutNotApproved, Data = new LoginResponse() });
                    case ELoginStatus.Blocked:
                        return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.AccountBlocked, Data = new LoginResponse() });
                    case ELoginStatus.NotFound:
                        return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.LoginFailed, Data = new LoginResponse() });
                    case ELoginStatus.Failed:
                        return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.ServerError, Data = new LoginResponse() });
                }

                return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.ServerError, Data = new LoginResponse() });
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
        [AppAuthorize(false)]
        [Route("saveuser")]
        public async Task<IActionResult> SaveUser([FromForm] SaveUserRequest request, IFormFile profilePicture)
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
                    //var abc = configuration.GetValue<string>("BaseUrlServer");
                    file = new SaveFiles().SaveImage(_env.WebRootPath, profilePicture,"ProfilePics", "ProfilePicsThum");
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    { IsError = false, Message = "", Data = await service.SaveUser(request,file, userId) });
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
        [HttpGet]
        [Route("activateemail")]
        public async Task<IActionResult> ActivateEmail(Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.ActivateEmail(userId);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "No User found", Data = res });
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
        [ProducesResponseType(typeof(Response<List<General<Guid>>>), 200)]
        [ProducesResponseType(typeof(Response<List<General<Guid>>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpGet]
        [Route("getemails")]
        public async Task<IActionResult> getEmails()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var res = await service.GetUnVerifiedEmail();
                
                return StatusCode(StatusCodes.Status200OK, new Response<List<General<Guid>>>() { IsError = false, Message = "", Data = res });
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
        [ProducesResponseType(typeof(Response<UserProfileResponse>), 200)]
        [ProducesResponseType(typeof(Response<UserProfileResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpGet]
        [AppAuthorize(true)]
        [Route("getprofile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                    return StatusCode(StatusCodes.Status200OK, new Response<UserProfileResponse>() { IsError = false, Message = "", Data = await service.GetProfile(userId) });
                
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
        [AppAuthorize(true)]
        [HttpPost]
        [Route("updatephonenumber")]
        public async Task<IActionResult> UpdatePhoneNumber(PhoneNumberRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var res = await service.UpdatePhoneNumber(request,userId);
                if (res.Item1)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<bool>() { IsError = true, Message = "Old contact does not matched", Data = res.Item2 });
                }
                else if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res.Item2 });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "No user found", Data = res.Item2 });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [HttpGet]
        [AppAuthorize(true)]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                var deviceToken = RouteData.Values["DeviceToken"].ToString();

                await service.Logout(userId, deviceToken);

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = true });
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
        [AppAuthorize(true)]
        [HttpPost]
        [Route("enablepush")]
        public async Task<IActionResult> EnablePush(EnablePushRequest request)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                bool res = await service.EnablePush(userId, request.IsEnable);
                if (res)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = res });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response<bool>() { IsError = true, Message = "No user found", Data = res });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

   
}
