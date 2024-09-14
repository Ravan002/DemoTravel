using Entities.Dto.CategoryDtos;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class CategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(a => a.CategoryName)
                .MinimumLength(2).WithMessage("Ad uzunlugu 2-den az la bilmez")
                .NotNull().NotEmpty();
            RuleFor(a => a.CategoryImg.FileName)
               .Must(EndsWithImageExtension).WithMessage("File sekil formatinda olmalidi");
        }

        private bool EndsWithImageExtension(string arg)
        {
            return arg.EndsWith("png") || arg.EndsWith("jpeg") || arg.EndsWith("jpg");
        }
    }
}
