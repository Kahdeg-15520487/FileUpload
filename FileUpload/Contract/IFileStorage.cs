using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Contract
{
    public interface IFileStorage
    {
        Task Store(string fileName, byte[] fileContent, bool isOverwrite);
        Task<byte[]> Load(string fileName);
    }
}
