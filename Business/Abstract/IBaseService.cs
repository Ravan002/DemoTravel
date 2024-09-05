using Core.Entites.Abstract;
using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : class,IEntity, new()
    {
        IResult Add(T entity);
        IResult Delete(int id);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Update(int id, T entity);
    }
}
