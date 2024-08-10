using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length >= 5)
            {
                _categoryDal.Add(category);
                return new SuccessResult("Kategqoriya Ugurla yaradildi");
            }
            return new ErrorResult("Ad uzunlugu 5-den kicik ola bilmez");
        }

        public IResult Delete(Category category)
        {
            var deleteCategory = GetById(category.Id).Data;
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
            List<Category> allCategories = _categoryDal.GetAll(c => c.IsDeleted == false);
            if (allCategories.Count > 0)
            {
                return new SuccessDataResult<List<Category>>(allCategories, "butun kateqoriyalar gosterildi");
            }
            return new ErrorDataResult<List<Category>>("Hec bir kateqoriya tapilmadi");
        }

        public IDataResult<Category> GetById(int id)
        {
            Category selectedCategory = _categoryDal.Get(t => t.Id == id && t.IsDeleted == false);
            if (selectedCategory != null)
            {
                return new SuccessDataResult<Category>(selectedCategory, "Gonderilen id ile bagli kateqoriya ugurla tapildi");
            }
            return new ErrorDataResult<Category>(id + " ile bagli hec bir kateqoriya tapilmadi");
        }

        public IResult Update(Category category)
        {
            var updateCategory = GetById(category.Id).Data;
            if (updateCategory != null)
            {
                updateCategory.CategoryName = category.CategoryName;
                _categoryDal.Update(updateCategory);
                return new SuccessResult("Ugurla update olundu");
            }
            return new ErrorResult("Emelliyat basrisiz oldu");
        }
    }
}
