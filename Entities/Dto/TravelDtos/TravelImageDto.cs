﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.TravelDtos
{
    public class TravelImageDto : IDto
    {
        public string ImageUrl {  get; set; }
    }
}
