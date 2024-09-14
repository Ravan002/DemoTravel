using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.Dto.TravelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITravelDal : IBaseRepository<Travel>
    {
        List<CategoryDto> GetCategoriesByTravelId(int travelId);
        List<TravelImageDto> GetImagesByTravelId(int travelId);
    }
}
