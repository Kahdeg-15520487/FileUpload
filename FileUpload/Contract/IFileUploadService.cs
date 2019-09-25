using System.Threading.Tasks;

using FileUpload.Contract.Dtos;

namespace FileUpload.Contract
{
    public interface IFileUploadService
    {
        Task Store(UploadDto dto);
        Task<byte[]> Load(string fileName);
    }
}
