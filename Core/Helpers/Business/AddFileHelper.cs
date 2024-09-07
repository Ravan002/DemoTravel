using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.Business
{
    public class AddFileHelper(IWebHostEnvironment webHostEnvironment) : IAddFileHelperService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        public string AddFile(IFormFile formFile, string folderName)
        {
            var fileName = Guid.NewGuid() + "-" + formFile.FileName;
            // files parametr olaraq add eleye bileriz
            var wwwFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            var fileFolder = Path.Combine(wwwFolder, fileName);
            using var fileStream = new FileStream(fileFolder, FileMode.CreateNew);
            formFile.CopyTo(fileStream);
            return "/"+folderName+"/"+fileName;
        }
    }
}
