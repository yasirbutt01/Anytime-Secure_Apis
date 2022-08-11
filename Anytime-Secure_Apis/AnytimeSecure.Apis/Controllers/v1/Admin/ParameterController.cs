using AnytimeSecure.Apis.Models.Authorizations;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Request.Admin.v1;
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
    [AdminAuthorize(new[] { ERight.Parameter, ERight.Floor, ERight.UserManagement })]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterService service;

        public ParameterController(IParameterService service)
        {
            this.service = service;
        }

        /// <summary>
        /// </summary>
        /// <response code="200">If all working fine</response>
        /// <response code="500">If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 403)]
        [HttpGet]
        [Route("getroomtypes")]
        public IActionResult GetRoomTypes()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<List<ParameterGnericResponse>>()
                    { IsError = false, Message = "", Data = service.GetRoomTypes() });
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
        [Route("saveroomtype")]
        public async Task<IActionResult> SaveRoomType(ParameterRequest<List<GenericDetailRequest>> request)
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
                        Data = await service.SaveRoomType(request, userId)
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
        [Route("controllactivationroomtype/{id}/{isDisable:bool}/{status:bool}")]
        public async Task<IActionResult> ControllActivationRoomType(Guid id, bool isDisable, bool status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ControllActivationRoomType(id, isDisable, status, userId)
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
        [ProducesResponseType(typeof(Response<List<SpecificationResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<SpecificationResponse>>), 403)]
        [HttpGet]
        [Route("getspecifications")]
        public IActionResult GetSpecifications()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<List<SpecificationResponse>>()
                    { IsError = false, Message = "", Data = service.GetSpecifications() });
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
        [Route("savespecification")]
        public async Task<IActionResult> SaveSpecification(ParameterRequest<List<SpecificationRequest>> request)
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
                        Data = await service.SaveSpecification(request, userId)
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
        [Route("controllactivationspecification/{id}/{isDisable:bool}/{status:bool}")]
        public async Task<IActionResult> ControllActivationSpecification(Guid id, bool isDisable, bool status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ControllActivationSpecification(id, isDisable, status, userId)
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
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 403)]
        [HttpGet]
        [Route("getdepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<List<ParameterGnericResponse>>()
                    { IsError = false, Message = "", Data = service.GetDepartments() });
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
        [Route("savedepartment")]
        public async Task<IActionResult> SaveDepartment(ParameterRequest<List<GenericDetailRequest>> request)
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
                        Data = await service.SaveDepartment(request, userId)
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
        [Route("controllactivationdepartment/{id}/{isDisable:bool}/{status:bool}")]
        public async Task<IActionResult> ControllActivationDepartment(Guid id, bool isDisable, bool status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ControllActivationDepartment(id, isDisable, status, userId)
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
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<ParameterGnericResponse>>), 403)]
        [HttpGet]
        [Route("getjobtitles")]
        public IActionResult GetJobTitles()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response<List<ParameterGnericResponse>>()
                    { IsError = false, Message = "", Data = service.GetJobTitles() });
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
        [Route("savejobtitle")]
        public async Task<IActionResult> SaveJobTitle(ParameterRequest<List<GenericDetailRequest>> request)
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
                        Data = await service.SaveJobTitle(request, userId)
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
        [Route("controllactivationjobtitle/{id}/{isDisable:bool}/{status:bool}")]
        public async Task<IActionResult> ControllActivationJobTitle(Guid id, bool isDisable, bool status)
        {
            try
            {
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK,
                    new Response<bool>()
                    {
                        IsError = false,
                        Message = "",
                        Data = await service.ControllActivationJobTitle(id, isDisable, status, userId)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
