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
    public interface IFAQService
    {
        IResult Add(FAQDto entity);
        IResult Delete(int id);
        IDataResult<List<FAQ>> GetAll();
        IDataResult<FAQ> GetById(int id);
        IResult Update(int id, FAQDto entity);
    }
}
