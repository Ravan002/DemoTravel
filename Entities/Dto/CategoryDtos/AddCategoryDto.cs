using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.CategoryDtos
{
    public class AddCategoryDto : IDto
    {
        public string CategoryName { get; set; }
        public IFormFile CategoryImg { get; set; }
    }
}
