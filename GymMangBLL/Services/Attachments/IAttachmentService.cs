using Microsoft.AspNetCore.Http;

namespace GymMangBLL.Services.Attachments
{
    public interface IAttachmentService
    {
        string? Upload(string folderName, IFormFile file);   
        bool Delete(string fileName, string folderName);
    }
}
