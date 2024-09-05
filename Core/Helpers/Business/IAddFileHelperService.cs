using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Business
{
    public interface IAddFileHelperService
    {
        string AddFile(IFormFile formFile, string folderName);
    }
}
