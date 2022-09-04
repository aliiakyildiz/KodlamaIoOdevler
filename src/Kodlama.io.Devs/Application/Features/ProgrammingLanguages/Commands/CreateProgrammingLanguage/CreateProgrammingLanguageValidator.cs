using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageValidator : AbstractValidator<CreateProgrammingLanguageRequest>
    {
        public CreateProgrammingLanguageValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
