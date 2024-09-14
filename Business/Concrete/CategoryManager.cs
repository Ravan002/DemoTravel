using AutoMapper;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.DTO.TravelDTOs;

namespace Business.Concrete
{
    public class CategoryManager(ICategoryDal categoryDal, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;
        private readonly IMapper _mapper = mapper;

        [ValidationAspect<AddCategoryDto>(typeof(CategoryDtoValidator))]
        public IResult Add(AddCategoryDto addCategoryDto)
        {
            var category = _mapper.Map<Category>(addCategoryDto);
            _categoryDal.Add(category);
            return new SuccessResult("Kategqoriya Ugurla yaradildi");
        }

        public IResult Delete(int id)
        {
            var deleteCategory = GetById(id).Data;
            if (deleteCategory != null)
            {
                deleteCategory.IsDeleted = true;
                _categoryDal.Delete(deleteCategory);
                return new SuccessResult("Katqoriya listden silindi");
            }
            return new ErrorResult("Bele bir kateqoriya listde yoxdur");
        }

        public IDataResult<List<Category>> GetAll()
        {
            var allCategories = _categoryDal.GetAll(c => c.IsDeleted == false);
            if (allCategories.Count > 0)
            {
                return new SuccessDataResult<List<Category>>(allCategories, "butun kateqoriyalar gosterildi");
            }
            return new ErrorDataResult<List<Category>>("Hec bir kateqoriya tapilmadi");
        }

        public IDataResult<Category> GetById(int id)
        {
            var selectedCategory = _categoryDal.Get(t => t.Id == id && t.IsDeleted == false);
            if (selectedCategory != null)
            {
                return new SuccessDataResult<Category>(selectedCategory, "Gonderilen id ile bagli kateqoriya ugurla tapildi");
            }
            return new ErrorDataResult<Category>(id + " ile bagli hec bir kateqoriya tapilmadi");
        }


        [ValidationAspect<AddCategoryDto>(typeof(CategoryDtoValidator))]
        public IResult Update(int id, AddCategoryDto addCategoryDto)
        {
            var updateCategory = GetById(id).Data;
            if (updateCategory != null)
            {
                _mapper.Map(addCategoryDto, updateCategory);
                _categoryDal.Update(updateCategory);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("Emelliyat basrisiz oldu");
        }
    }
}
