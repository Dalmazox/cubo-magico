using Microsoft.AspNetCore.Mvc;

namespace CuboMagico.Domain.Interfaces.Builders
{
    public interface IRetornoBuilder
    {
        IRetornoBuilder AddStatusCode(int statusCode);
        IRetornoBuilder AddMensagem(string mensagem);
        IRetornoBuilder AddDados(object dados);
        // Retornar o objeto montado e finalizado com as propriedades que foram sendo adicionadas
        IActionResult Build();
    }
}
