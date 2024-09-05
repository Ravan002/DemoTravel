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
    public interface ITravelService
    {
        IResult Add(TravelDto entity);
        IResult Delete(int id);
        IDataResult<List<Travel>> GetAll();
        IDataResult<Travel> GetById(int id);
        IResult Update(int id, Travel entity);
    }
}
