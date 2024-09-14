using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.Dto.TravelDtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTravelDal : BaseRepository<Travel, ProjectContext>, ITravelDal
    {
        public List<CategoryDto> GetCategoriesByTravelId(int travelId)
        {
            using var context = new ProjectContext();
            var result = from tc in context.TravelCategories
                         where tc.IsDeleted == false && tc.TravelId == travelId
                         join c in context.Categories
                         on tc.CategoryId equals c.Id
                         where c.IsDeleted == false
                         select new CategoryDto()
                         {
                             CategoryName = c.CategoryName
                         };
            return result.ToList();
        }

        public List<TravelImageDto> GetImagesByTravelId(int travelId)
        {
            using var context = new ProjectContext();
            var result = from ti in context.TravelImages
                         where ti.IsDeleted == false && ti.TravelId == travelId
                         select new TravelImageDto()
                         {
                             ImageUrl = ti.ImageUrl
                         };
            return result.ToList();
        }

    }
}
