using Entities.DTO.TravelDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TravelDtoValidator : AbstractValidator<TravelDto>
    {
        public TravelDtoValidator()
        {
            RuleFor(t => t.PricePerPerson)
                .NotEmpty().WithMessage("Bos gonderile bilmez")
                .GreaterThan(0).WithMessage("qiymet 0-dan boyuk olmalidir")
                .NotNull();
            RuleFor(t => t.TravelPicture)
                .NotEmpty().WithMessage("Bos gonderile bilmez")
                .NotNull();
            RuleFor(t => t.TravelPicture.FileName)
                .Must(EndsWithImageExtension).WithMessage("File sekil formatinda olmalidi");
            RuleFor(t => t.LocationImgMap)
                .NotEmpty().WithMessage("Bos gonderile bilmez")
                .NotNull();
            RuleFor(t => t.LocationImgMap.FileName)
                .Must(EndsWithImageExtension).WithMessage("File sekil formatinda olmalidi");
        }
        private bool EndsWithImageExtension(string arg)
        {
            return arg.EndsWith("png")|| arg.EndsWith("jpeg") || arg.EndsWith("jpg");
        }
    }
}
