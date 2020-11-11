using CuboMagico.Domain.Interfaces.Builders;
using CuboMagico.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace CuboMagico.Application.Builders
{
    public class RetornoBuilder : IRetornoBuilder
    {
        private readonly Retorno _retorno;

        public RetornoBuilder()
        {
            _retorno = new Retorno();
        }

        public IRetornoBuilder AddDados(object dados)
        {
            _retorno.Dados = dados;
            return this;
        }

        public IRetornoBuilder AddMensagem(string mensagem)
        {
            _retorno.Mensagem = mensagem;
            return this;
        }

        public IRetornoBuilder AddStatusCode(int statusCode)
        {
            _retorno.StatusCode = statusCode;
            return this;
        }

        public IActionResult Build()
        {
            return new ObjectResult(_retorno) 
            { 
                StatusCode = _retorno.StatusCode 
            };
        }
    }
}
