using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class AboutDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string FacebookURL { get; set; } 
        public string PinterestURL { get; set; }
        public string TwitterURL { get; set; }
        public IFormFile ProfilePciture { get; set; }
    }
}
