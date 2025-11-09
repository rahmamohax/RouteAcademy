using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GymMangBLL.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IWebHostEnvironment _webHost;

        public AttachmentService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        private readonly string[] allowedExtentions = { ".jpg", ".jpeg", ".png" };
        private readonly long maxFileSize = 5 * 1024 * 1024; // 5 MB

        public string? Upload(string folderName, IFormFile file)
        {
            try
            {
                if (folderName is null || file is null || file.Length == 0 || file.Length > maxFileSize)
                    return null;

                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtentions.Contains(extension))
                    return null;

                var folderPath = Path.Combine(_webHost.WebRootPath, "images", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString() + extension;
                //wwwroot/images/members/9222j3kkmktji748uvfji59.png
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Upload" + ex);
                return null;
            }
        }

        public bool Delete(string fileName, string folderName)
        {
            try
            {
                if(string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderName)) return false;

                var fullPath = Path.Combine(_webHost.WebRootPath, "images", folderName, fileName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Delete " + ex);
                return false;
            }
        }
    }
}
