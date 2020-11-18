using Microsoft.AspNetCore.Mvc;

namespace CuboMagico.Domain.Interfaces.Helpers
{
    public interface IRetornoHelper
    {
        IActionResult Erro(object dados = null, string mensagem = null, int? statusCode = null);
        IActionResult Sucesso(object dados = null, string mensagem = null, int? statusCode = null);
        IActionResult Criado(object dados = null, string mensagem = null, int? statusCode = null);
        IActionResult Alterado(object dados = null, string mensagem = null, int? statusCode = null);
        IActionResult ErroValidacao(object dados = null, string mensagem = null, int? statusCode = null);
    }
}
