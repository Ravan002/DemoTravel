using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Travel : BaseEntity
    {
        public string TravelPicture { get; set; }
        public string LocationName { get; set; }
        public string LocationImgMap { get; set; }
        public string TravelDescription { get; set; }
        public decimal PricePerPerson { get; set; }
    }
}
