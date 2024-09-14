using Entities.Dto;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    class AboutDtoValidator : AbstractValidator<AboutDto>
    {
        public AboutDtoValidator()
        {
            RuleFor(a => a.Name)
                .MinimumLength(2).WithMessage("Ad uzunlugu 2-den az la bilmez")
                .NotNull().NotEmpty();
            RuleFor(a => a.Description)
                .MaximumLength(150).WithMessage("Description uzunlugu 150-den cox ola bilmez")
                .NotNull().NotEmpty();
            RuleFor(a => a.ProfilePciture.FileName)
               .Must(EndsWithImageExtension).WithMessage("File sekil formatinda olmalidi");
        }

        private bool EndsWithImageExtension(string arg)
        {
            return arg.EndsWith("png") || arg.EndsWith("jpeg") || arg.EndsWith("jpg");
        }
    }
}
