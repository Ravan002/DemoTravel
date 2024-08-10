using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IResult Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<About>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<About> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
