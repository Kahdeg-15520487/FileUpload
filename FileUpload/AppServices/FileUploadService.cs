using System.IO;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using FileUpload.Contract;
using FileUpload.Contract.Exceptions;
using FileUpload.Contract.Dtos;

namespace FileUpload.AppServices
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileStorage fileStorage;

        public FileUploadService(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public async Task Store(UploadDto dto)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await dto.File.CopyToAsync(ms);
                byte[] fileContent = ms.ToArray();
                await fileStorage.Store(dto.File.FileName, fileContent, dto.IsOvewrite);
            }
        }

        public async Task<byte[]> Load(string fileName)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    return await fileStorage.Load(fileName);
                }
                catch (FileNotFoundException fnfex)
                {
                    throw new ApiException(fnfex.Message, HttpStatusCode.NotFound);
                }
            }
        }
    }
}
