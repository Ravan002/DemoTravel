using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.CategoryDtos
{
    public class CategoryDto : IDto
    {
        public string CategoryName { get; set; }
    }
}
