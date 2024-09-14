using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.DTO.TravelDTOs;

namespace Business.Abstract
{
    public interface ITravelService
    {
        IResult Add(TravelDto entity);
        IResult Delete(int id);
        IDataResult<List<Travel>> GetAll();
        IDataResult<Travel> GetById(int id);
        IResult Update(int id, TravelDto entity);
        IDataResult<TravelDetailDto> GetTravelWithDetail(int id);
        // getAllbycategory
    }
}
