using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Entities.Dto.CategoryDtos;
using Entities.Dto.TravelDtos;

namespace Entities.DTO.TravelDTOs
{
    public class TravelDetailDto : IDto
    {
        public string TravelPicture { get; set; }
        public string LocationName { get; set; }
        public string LocationImgMap { get; set; }
        public string TravelDescription { get; set; }
        public decimal PricePerPerson { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<TravelImageDto> Images { get; set; }
    }
}
