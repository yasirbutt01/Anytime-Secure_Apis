using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.Common;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Request;
using AnytimeSecure.DataViewModels.Request.Admin.v1;
using AnytimeSecure.DataViewModels.Response;
using AnytimeSecure.DataViewModels.Response.Admin;
using AnytimeSecure.DataViewModels.Response.Admin.v1;
using AnytimeSecure.Services.Interface.v1.Admin;

namespace AnytimeSecure.Apis.Controllers.v1.Admin
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;

        public RegisterController(IAccountService accountService, IConfiguration configuration)
        {
            this.accountService = accountService;
            this.configuration = configuration;
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
        [ProducesResponseType(typeof(Response<AdminLoginResponse>), 200)]
        [ProducesResponseType(typeof(Response<AdminLoginResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [Route("adminlogin")]
        public IActionResult AdminLogin(AdminLoginRequest login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var res = accountService.AdminLogin(login);

                if (res.Item3)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new Response<AdminLoginResponse>()
                        { IsError = true, Message = Error.AccountBlocked, Data = new AdminLoginResponse() });
                }

                if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response<AdminLoginResponse>() { IsError = false, Message = "", Data = res.Item1 });
                }

                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response<AdminLoginResponse>()
                    { IsError = true, Message = Error.LoginFailed, Data = new AdminLoginResponse() });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("addrole/{name}")]
        public async Task<IActionResult> AddRole(string name)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    { IsError = false, Message = "", Data = await accountService.AddRole(name, userId) });
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
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpPost]
        [Route("updaterole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest roleRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response<bool>()
                    { IsError = false, Message = "", Data = await accountService.UpdateRole(roleRequest, userId) });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("controllroleactivation/{roleId}/{activation:bool}")]
        public async Task<IActionResult> ControllRoleActivation(Guid roleId, bool activation)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await accountService.ControllRoleActivation(roleId, activation, userId)
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
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetRoles>>), 200)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetRoles>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("getroles")]
        public IActionResult GetRoles(ListGenralModelNew<GetRoles, bool> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<GridGeneralModel<GetRoles>>()
                    { IsError = false, Message = "", Data = accountService.GetRoles(request) });
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
        [ProducesResponseType(typeof(Response<List<RightResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<RightResponse>>), 403)]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("getrights/{roleId}")]
        public IActionResult GetRights(Guid roleId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<List<RightResponse>>()
                    { IsError = false, Message = "", Data = accountService.GetRights(roleId) });
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
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpPost]
        [Route("assignrights")]
        public async Task<IActionResult> AssignRights(AssignRight assignRight)
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
                    { IsError = false, Message = "", Data = await accountService.AssignRights(assignRight, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// param is *IsCompanyEmployee*
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetUserResponse>>), 200)]
        [ProducesResponseType(typeof(Response<GridGeneralModel<GetUserResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpPost]
        [Route("getusers")]
        public IActionResult GetUsers(ListGenralModelNew<GetUserResponse, bool> request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK,
                    new Response<GridGeneralModel<GetUserResponse>>()
                    { IsError = false, Message = "", Data = accountService.GetUsers(request) });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [Route("saveuser")]
        public async Task<IActionResult> SaveUser(CreateUserRequest createUser)
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
                    { IsError = false, Message = "", Data = await accountService.SaveUser(createUser, userId) });
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
        [ProducesResponseType(typeof(Response<CreateUserRequest>), 200)]
        [ProducesResponseType(typeof(Response<CreateUserRequest>), 403)]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("getedituser/{id}")]
        public IActionResult GetEditUser(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<CreateUserRequest>()
                    { IsError = false, Message = "", Data = accountService.GetUserDetail(id) });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("allowadminaccess/{id}")]
        public async Task<IActionResult> AllowAdminAccess(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    { IsError = false, Message = "", Data = await accountService.AllowAdminAccess(id) });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("allowinfrastructureaccess/{id}")]
        public async Task<IActionResult> AllowInfrastructureAccess(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    { IsError = false, Message = "", Data = await accountService.AllowInfrastructureAccess(id) });
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
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [HttpGet]
        [Route("controlluseractivation/{adminUserId}/{activation:bool}/{isRemove:bool}")]
        public async Task<IActionResult> ControllUserActivation(Guid adminUserId, bool activation, bool isRemove)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await accountService.ControllUserActivation(adminUserId, activation, isRemove, userId)
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
        /// <response code="400">If client made Validation Error</response>  
        /// <response code="403">If client made some mistake</response>  
        /// <response code="500">If Server Error</response>  
        [HttpPost]
        [AdminAuthorize(new[] { ERight.UserManagement })]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(AdminChangePasswordRequest changePassword)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await accountService.ChangePassword(changePassword, userId)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}