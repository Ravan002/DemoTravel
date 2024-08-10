using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TravelManager(ITravelDal travelDal) : ITravelService
    {
        private readonly ITravelDal _travelDal = travelDal;

        public IResult Add(Travel trip)
        {
            if (trip.LocationName.Length > 3)
            {
                _travelDal.Add(trip);
                return new SuccessResult("Yeni seyahet elave olundu");
            }
            return new ErrorResult("Bu adda olke yoxdur");

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
