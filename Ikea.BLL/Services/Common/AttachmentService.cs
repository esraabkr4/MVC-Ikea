using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ikea.BLL.Services.Common
{
    public class AttachmentService:IAttachmentService
    {
        private readonly List<string> AllowedExtensions = new() { ".jpg",".jpeg",".png"};
        private const int FileMaxSize = 2_546_234;
        public async Task<string> UploadFileAsync(IFormFile file, string FolderName)
        {
            var fileExtenstion = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(fileExtenstion))
            {
                throw new Exception("Invalid File Extension");
            }
            if (file.Length > FileMaxSize)
            {
                throw new Exception("File Size Is Big");
            }
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            var FileName = $"{Guid.NewGuid()}{fileExtenstion}";
            var filePath = Path.Combine(FolderPath, FileName);
            using var filestream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(filestream);
            return FileName;
        }
        public async Task<bool> DeleteFileAsync(string folderPath)
        {
            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
                return true;
            }
            return false;
        }
    }
}
