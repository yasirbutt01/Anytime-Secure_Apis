using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Request.App.v1.Laboratory;
using AnytimeSecure.DataViewModels.Response.App.v1.Laboratory;
using AnytimeSecure.Services.Interface.v1.App.Laboratory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnytimeSecure.Apis.Controllers.v1.App.Laboratory
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService service;

        public LaboratoryController(ILaboratoryService service)
        {
            this.service = service;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<LaboratoryResponse>>), 200)]
        [ProducesResponseType(typeof(Response<List<LaboratoryResponse>>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        [Route("getavailablebuildings")]
        public async Task<IActionResult> GetAvailableBuildings(LaboratoryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                return StatusCode(StatusCodes.Status200OK, new Response<List<LaboratoryResponse>>() { IsError = false, Message = "", Data = await service.GetLaboratories(request) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
