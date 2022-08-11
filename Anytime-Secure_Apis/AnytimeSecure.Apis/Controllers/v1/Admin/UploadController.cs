using AnytimeSecure.Common;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.DataViewModels.Request.Admin.v1;
using Microsoft.AspNetCore.Hosting;
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
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment _env)
        {
            this._env = _env;
        }

        /// <summary>
        /// </summary>
        /// <response code = "200" > If all working fine</response>
        /// <response code = "403" > If client made some mistake</response>  
        /// <response code = "500" > If Server Error</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<List<FileUrlResponce>>), 200)]
        [ProducesResponseType(typeof(Response<List<FileUrlResponce>>), 403)]
        [HttpPost]
        [Route("uploadmedia")]
        public IActionResult UploadMedia([FromForm] UploadDocuments param, IFormFile mediaFile)
        {
            try
            {
                var response = new List<FileUrlResponce>();
                FileUrlResponce vedioFile = new FileUrlResponce();

                var fileName = mediaFile.FileName;
                if (param.Type == (int)EDocumentType.Image)
                {
                    var file = new SaveFiles().SaveImage(_env.WebRootPath, mediaFile, "Images", "Images");

                    if (!string.IsNullOrEmpty(file.URL))
                    {
                        file.URL = file.URL;
                        response.Add(file);
                    }
                }
                else if (param.Type == (int)EDocumentType.Video)
                {
                    vedioFile = new SaveFiles().SaveFile(_env.WebRootPath, mediaFile, "video");

                    if (!string.IsNullOrEmpty(vedioFile.URL) && !string.IsNullOrEmpty(vedioFile.ThumbnailbUrl))
                    {
                        response.Add(vedioFile);
                    }
                }
                else if (param.Type == (int)EDocumentType.Document)
                {
                    var file = new SaveFiles().SaveFile(_env.WebRootPath, mediaFile, "Document");

                    if (!string.IsNullOrEmpty(file.URL))
                    {
                        file.URL = file.URL;
                        response.Add(file);
                    }
                }

                if (response.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<List<FileUrlResponce>>() { IsError = false, Message = "", Data = response });
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<List<FileUrlResponce>>() { IsError = true, Message = Error.FileNotFound, Data = new List<FileUrlResponce>() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
