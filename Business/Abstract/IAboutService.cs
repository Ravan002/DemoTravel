using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutDto entity);
        IResult Delete(int id);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetById(int id);
        IResult Update(int id, AboutDto entity);

    }
}
