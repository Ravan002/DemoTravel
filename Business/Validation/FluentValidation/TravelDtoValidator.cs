using Entities.Dto;
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
            RuleFor(t => t.TravelPicture).NotEmpty().WithMessage("Bos gonderile bilmez");
            RuleFor(t => t.TravelPicture.FileName).Must(EndsWithImageExtension).WithMessage("File sekil formatinda olmalidi");
        }

        private bool EndsWithImageExtension(string arg)
        {
            return arg.EndsWith("png");
        }
    }
}
