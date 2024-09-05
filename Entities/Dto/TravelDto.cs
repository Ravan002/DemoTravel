using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class TravelDto : IDto
    {
        public IFormFile TravelPicture { get; set; }
        public string LocationName { get; set; }
        public IFormFile LocationImgMap { get; set; }
        public string TravelDescription { get; set; }
        public decimal PricePerPerson { get; set; }
    }
}
