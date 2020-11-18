using CuboMagico.Domain.Entities;
using FluentValidation;

namespace CuboMagico.Presentation.API.Validators
{
    public class SoftwareValidator : AbstractValidator<Software>
    {
        public SoftwareValidator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Nome do software não informado")
                .NotEmpty().WithMessage("Nome do software vazio");
        }
    }
}
