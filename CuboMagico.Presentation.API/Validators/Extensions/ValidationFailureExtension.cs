using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CuboMagico.Presentation.API.Validators.Extensions
{
    public static class ValidationFailureExtension
    {
        public static IEnumerable<object> ParaRetorno(this IList<ValidationFailure> erros)
            => erros.Select(erro => new { Propriedade = erro.PropertyName, Mensagem = erro.ErrorMessage });
        
    }
}
