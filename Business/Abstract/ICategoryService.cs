using Core.DataAccess.Abstract;
using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(AddCategoryDto entity);
        IResult Delete(int id);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IResult Update(int id, AddCategoryDto entity);
    }
}
