using FileUpload.Contract;
using FileUpload.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            this.fileUploadService = fileUploadService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload([FromForm]UploadDto inputDto)
        {
            try
            {
                await this.fileUploadService.Store(inputDto);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest();
            }
        }
    }
}
