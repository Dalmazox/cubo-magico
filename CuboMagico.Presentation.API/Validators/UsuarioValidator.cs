using CuboMagico.Domain.Entities;
using FluentValidation;

namespace CuboMagico.Presentation.API.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Nome do usuário não informado")
                .NotEmpty().WithMessage("Nome do usuário vazio");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("E-mail do usuário não informado")
                .NotEmpty().WithMessage("E-mail do usuário vazio")
                .EmailAddress().WithMessage("Formato do e-mail inválido");

            RuleFor(x => x.Senha)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Senha do usuário não informada")
                .NotEmpty().WithMessage("Senha do usuário vazia");
        }
    }
}
