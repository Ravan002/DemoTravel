using AutoMapper;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class AboutManager(IAboutDal aboutDal, IMapper mapper) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;
        private readonly IMapper _mapper = mapper;

        [ValidationAspect<AboutDto>(typeof(AboutDtoValidator))]
        public IResult Add(AboutDto entity)
        {
            About about = _mapper.Map<About>(entity);
            _aboutDal.Add(about);
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
            var result = _aboutDal.GetAll(a => a.IsDeleted == false);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<About>>(result, "ugurlu emeliyyat");
            }
            return new ErrorDataResult<List<About>>(result, "Hec bir data tapilmadi");
        }

        public IDataResult<About> GetById(int id)
        {
            var result = _aboutDal.Get(a => a.Id == id && a.IsDeleted == false);
            if (result != null)
            {
                return new SuccessDataResult<About>(result, "gonderile id-li data tapildi");
            }
            return new ErrorDataResult<About>(result, "Hecbir data tapilmadi");
        }

        [ValidationAspect<AboutDto>(typeof(AboutDtoValidator))]
        public IResult Update(int id, AboutDto entity)
        {
            var updateAbout = GetById(id).Data;
            if (updateAbout != null)
            {
                _mapper.Map(entity, updateAbout);
                _aboutDal.Update(updateAbout);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("Emelliyat basrisiz oldu");
        }
    }
}
