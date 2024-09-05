using Business.Abstract;
using Business.BusinessAspect.Autofac.Secured;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Constants;
using Core.Helpers.Business;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class TravelManager(ITravelDal travelDal, IAddFileHelperService addFileHelperService) : ITravelService
    {
        private readonly ITravelDal _travelDal = travelDal;
        private readonly IAddFileHelperService _addFileHelperService = addFileHelperService;          


        [SecuredAspect("Admin,Moderator")]
        [ValidationAspect<TravelDto>(typeof(TravelDtoValidator))]
        public IResult Add(TravelDto travelDto)
        {
            var fileName = _addFileHelperService.AddFile(travelDto.TravelPicture, FolderNames.ImagesFolder);
            Travel travel = new()
            {
                LocationImgMap= FolderNames.ImagesFolderWithSlash + fileName,
                TravelPicture = FolderNames.ImagesFolderWithSlash + fileName,
                LocationName= travelDto.LocationName,
                PricePerPerson=travelDto.PricePerPerson,
                TravelDescription= travelDto.TravelDescription,
            };
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

        public IResult Update(int id, Travel trip)
        {
            var updateTravel = GetById(id).Data;
            if (updateTravel != null)
            {
                updateTravel.LocationName = trip.LocationName;
                _travelDal.Update(updateTravel);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult();
        }
    }
}
