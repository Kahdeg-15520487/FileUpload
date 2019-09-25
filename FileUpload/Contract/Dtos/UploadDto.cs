using Microsoft.AspNetCore.Http;

namespace FileUpload.Contract.Dtos
{
    public class UploadDto
    {
        public IFormFile File { get; set; }
        public bool IsOvewrite { get; set; }
    }
}
