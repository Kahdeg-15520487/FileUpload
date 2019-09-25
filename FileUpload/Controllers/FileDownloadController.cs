using FileUpload.Contract;
using FileUpload.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{
    [Route("api/download")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly IFileUploadService fileUploadService;

        public FileDownloadController(IFileUploadService fileUploadService)
        {
            this.fileUploadService = fileUploadService;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> Upload([FromRoute] string fileName)
        {
            try
            {
                byte[] fileContent = await this.fileUploadService.Load(fileName);
                return this.File(fileContent, "application/octet-stream");
            }
            catch (Exception ex)
            {
                return this.BadRequest();
            }
        }
    }
}
