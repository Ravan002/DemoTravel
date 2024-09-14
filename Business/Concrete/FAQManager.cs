using AutoMapper;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Entities.DTO.TravelDTOs;

namespace Business.Concrete
{
    public class FAQManager(IFAQDal faqDal, IMapper mapper) : IFAQService
    {
        private readonly IFAQDal _faqDal = faqDal;
        private readonly IMapper _mapper = mapper;

        [ValidationAspect<FAQDto>(typeof(FAQDtoValidator))]
        public IResult Add(FAQDto fAQDto)
        {
            var faq = _mapper.Map<FAQ>(fAQDto);
            _faqDal.Add(faq);
            return new SuccessResult("Yeni Sual-Cavab elave olundu");
        }
        public IResult Delete(int id)
        {
            var checkAvailability = GetById(id);
            if (checkAvailability.Success)
            {
                var deleteFAQ = checkAvailability.Data;
                deleteFAQ.IsDeleted = true;
                _faqDal.Delete(deleteFAQ);
                return new SuccessResult("Emeliyyat ugurla yerine yetirildi");
            }
            return new SuccessResult(checkAvailability.Message);
        }

        public IDataResult<List<FAQ>> GetAll()
        {
            List<FAQ> allRecords = _faqDal.GetAll(t => t.IsDeleted == false);
            return allRecords.Count > 0
                ? new SuccessDataResult<List<FAQ>>(allRecords, "butun sual/cavablar gosterildi")
                : new ErrorDataResult<List<FAQ>>("Hec bir sual/cavablar tapilmadi");
        }

        public IDataResult<FAQ> GetById(int id)
        {
            var faq = _faqDal.Get(f => f.Id == id && f.IsDeleted == false);
            return faq != null
                ? new SuccessDataResult<FAQ>(faq, "data")
                : new ErrorDataResult<FAQ>("Data tapilmadi");
        }

        public IResult Update(int id, FAQDto faqDto)
        {
            var updateFAQ = GetById(id).Data;
            if (updateFAQ != null)
            {
                _mapper.Map(faqDto, updateFAQ);
                _faqDal.Update(updateFAQ);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("TApilmadi");
        }
    }
}
