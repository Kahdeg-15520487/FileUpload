using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using FileUpload.Contract;
using FileUpload.Contract.Exceptions;

namespace FileUpload.AppServices
{
    public class LocalFileStorage : IFileStorage
    {
        private readonly IConfiguration configuration;

        public LocalFileStorage(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<byte[]> Load(string fileName)
        {
            string filePath = Path.Combine(this.configuration["StorageLocation"], fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Store(string fileName, byte[] fileContent, bool isOverwrite)
        {
            string filePath = Path.Combine(this.configuration["StorageLocation"], fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            if (!isOverwrite && File.Exists(filePath))
            {
                throw new FileExistedException();
            }

            try
            {
                using (Stream fs = File.Open(filePath, FileMode.Create))
                {
                    await fs.WriteAsync(fileContent, 0, fileContent.Length);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
