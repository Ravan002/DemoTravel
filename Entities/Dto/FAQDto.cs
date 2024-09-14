using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class FAQDto : IDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
