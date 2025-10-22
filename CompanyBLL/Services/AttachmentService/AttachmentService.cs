using Microsoft.AspNetCore.Http;

namespace CompanyProjectBLL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> AllowedExtentions = [".png", ".jpg", ".jpeg"];
        const int maxSize = 2_097_152;
        public string? Upload(IFormFile file, string folderName)
        {
            var extention = Path.GetExtension(file.FileName);
            //1.Check Extension
            if (!AllowedExtentions.Contains(extention)) return null;

            //2.Check Size
            if(file.Length ==0 || file.Length == maxSize) return null;

            //3.Get Located Folder Path

            //wwwroot\ProfilePhotos\
            //var path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\ProfilePhotos\\";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfilePhotos");

            //4.Make Attachment Name Unique-- GUID
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5.Get File Path
            var filePath = Path.Combine(folderPath, fileName);

            //6.Create File Stream To Copy File[Unmanaged]
            using FileStream stream = new FileStream(filePath, FileMode.Create);

            //7.Use Stream To Copy File
            file.CopyTo(stream);

            //8.Return FileName To Store In Database
            return fileName;
        }
        public bool Delete(string filePath)
        {
            if(!File.Exists(filePath)) return false;

            File.Delete(filePath);
            return true;
        }

    }
}
