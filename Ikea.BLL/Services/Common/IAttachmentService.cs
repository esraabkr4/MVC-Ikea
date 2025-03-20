using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ikea.BLL.Services.Common
{
    public interface IAttachmentService
    {
        Task<string> UploadFileAsync(IFormFile file, string FolderName);
        
        
        Task<bool> DeleteFileAsync(string folderPath);

    }
}
