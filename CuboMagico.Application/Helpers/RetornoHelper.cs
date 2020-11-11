using CuboMagico.Domain.Interfaces.Builders;
using CuboMagico.Domain.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuboMagico.Application.Helpers
{
    public class RetornoHelper : IRetornoHelper
    {
        private readonly IRetornoBuilder _builder;

        public RetornoHelper(IRetornoBuilder builder)
        {
            _builder = builder;
        }

        public IActionResult Erro(object dados = null, string mensagem = null, int? statusCode = null)
        {
            var codigoRetorno = statusCode ?? StatusCodes.Status404NotFound;
            var mensagemRetorno = mensagem ?? "Ocorreu um erro na requisição";

            return CriarRetorno(dados, mensagemRetorno, codigoRetorno);
        }

        public IActionResult Sucesso(object dados = null, string mensagem = null, int? statusCode = null)
        {
            var codigoRetorno = statusCode ?? StatusCodes.Status200OK;
            var mensagemRetorno = mensagem ?? "Requisição feita com sucesso";

            return CriarRetorno(dados, mensagemRetorno, codigoRetorno);
        }

        public IActionResult Criado(object dados = null, string mensagem = null, int? statusCode = null)
        {
            var codigoRetorno = statusCode ?? StatusCodes.Status201Created;
            var mensagemRetorno = mensagem ?? "Criado com sucesso";

            return CriarRetorno(dados, mensagemRetorno, codigoRetorno);
        }

        private IActionResult CriarRetorno(object dados, string mensagem, int statusCode)
            => _builder
                .AddStatusCode(statusCode)
                .AddMensagem(mensagem)
                .AddDados(dados)
                .Build();
    }
}
