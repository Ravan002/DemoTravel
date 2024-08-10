using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FAQManager(IFAQDal faqDal) : IFAQService
    {
        private readonly IFAQDal _faqDal = faqDal;
        public IResult Add(FAQ entity)
        {
            _faqDal.Add(entity);
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

        public IResult Update(int id, FAQ faq)
        {
            var updateFAQ = GetById(id).Data;
            if (updateFAQ != null)
            {
                updateFAQ.Question = faq.Question;
                updateFAQ.Answer = faq.Answer;
                _faqDal.Update(updateFAQ);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("TApilmadi");
        }
    }
}
