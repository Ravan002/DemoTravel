using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;
        public IResult Add(About entity)
        {
            _aboutDal.Add(entity);
            return new SuccessResult("Şəxs hakkindaki melumatlar ugurla elave olundu");
        }

        public IResult Delete(int id)
        {
            var deleteAbout = GetById(id).Data;
            if (deleteAbout != null)
            {
                deleteAbout.IsDeleted = true;
                _aboutDal.Delete(deleteAbout);
                return new SuccessResult("Shexs listden silindi");
            }
            return new ErrorResult("Bele bir shexs listde yoxdur");
        }

        public IDataResult<List<About>> GetAll()
        {
            var result = _aboutDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<About>>(result, "ugurlu emeliyyat");
            }
            return new ErrorDataResult<List<About>>(result, "Hec bir data tapilmadi");
        }

        public IDataResult<About> GetById(int id)
        {
            var result = _aboutDal.Get(a => a.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<About>(result, "gonderile id-li data tapildi");
            }
            return new ErrorDataResult<About>(result, "Hecbir data tapilmadi");
        }

        public IResult Update(int id, About entity)
        {
            var updateAbout = GetById(id).Data;
            if (updateAbout != null)
            {
                updateAbout.Surname = entity.Surname;
                _aboutDal.Update(updateAbout);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("Emelliyat basrisiz oldu");
        }
    }
}
