using Entities.Dto;
using Entities.DTO.TravelDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    internal class FAQDtoValidator : AbstractValidator<FAQDto>
    {
        public FAQDtoValidator()
        {
            RuleFor(t => t.Question)
                .NotEmpty().WithMessage("Bos gonderile bilmez")
                .NotNull()
                .MinimumLength(10)
                .Must(EndsWithQuestionMark).WithMessage("Sual cumlesi sual isaresi ile bitmelidir");
            RuleFor(t => t.Answer)
                .NotEmpty().WithMessage("Bos gonderile bilmez")
                .MaximumLength(100).WithMessage("150den cox olmamalidir");
        }
        private bool EndsWithQuestionMark(string arg)
        {
            return arg.EndsWith('?');
        }
    }
}
