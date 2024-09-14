using AutoMapper;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO.TravelDTOs;

namespace Business.Concrete
{
    public class TravelManager(ITravelDal travelDal, IMapper mapper) : ITravelService
    {
        private readonly ITravelDal _travelDal = travelDal;
        private readonly IMapper _mapper = mapper;


        //[SecuredAspect("Admin,Moderator")]
        [ValidationAspect<TravelDto>(typeof(TravelDtoValidator))]
        public IResult Add(TravelDto travelDto)
        {
            Travel travel = _mapper.Map<Travel>(travelDto);
            _travelDal.Add(travel);
            return new SuccessResult("Yeni seyahet elave olundu");
        }


        public IResult Delete(int id)
        {
            var deleteTrip = GetById(id).Data;
            if (deleteTrip != null)
            {
                deleteTrip.IsDeleted = true;
                _travelDal.Delete(deleteTrip);
                return new SuccessResult("Seyahet list-den silindi");
            }
            return new ErrorResult("Bele bir seyahet list-de yoxdur");
        }

        public IDataResult<List<Travel>> GetAll()
        {
            List<Travel> allTrips = _travelDal.GetAll(t => t.IsDeleted == false);
            return allTrips.Count > 0
                ? new SuccessDataResult<List<Travel>>(allTrips, "butun seyahetler gosterildi")
                : new ErrorDataResult<List<Travel>>("Hec bir seyahet plani tapilmadi");
        }

        public IDataResult<Travel> GetById(int id)
        {
            Travel selectedTrip = _travelDal.Get(t => t.Id == id && t.IsDeleted == false);
            return selectedTrip != null
                ? new SuccessDataResult<Travel>(selectedTrip, "Gonderilen id ile bagli seyahet ugurla tapildi")
                : new ErrorDataResult<Travel>(id + " ile bagli hec bir seyahet plani tapilmadi");
        }

        public IDataResult<TravelDetailDto> GetTravelWithDetail(int id)
        {
            var result = GetById(id);
            var selectedTrip = result.Data;
            if (selectedTrip != null)
            {
                var categories = _travelDal.GetCategoriesByTravelId(id);
                var images = _travelDal.GetImagesByTravelId(id);
                TravelDetailDto travelDetailDto = _mapper.Map<TravelDetailDto>(selectedTrip);
                travelDetailDto.Categories = categories;
                travelDetailDto.Images = images;
                return new SuccessDataResult<TravelDetailDto>(travelDetailDto, "Ugurla data geldi");
            }
            return new ErrorDataResult<TravelDetailDto>(result.Message);

        }

        [ValidationAspect<TravelDto>(typeof(TravelDtoValidator))]
        public IResult Update(int id, TravelDto trip)
        {
            var updateTravel = GetById(id).Data;
            if (updateTravel != null)
            {
                _mapper.Map(trip, updateTravel);
                _travelDal.Update(updateTravel);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("Ugursuz emeliyyat");
        }
    }
}
