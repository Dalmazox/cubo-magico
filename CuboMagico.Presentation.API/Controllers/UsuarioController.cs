using AutoMapper;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Helpers;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.ViewModels;
using CuboMagico.Presentation.API.Validators.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuboMagico.Presentation.API.Controllers
{
    [ApiController, AllowAnonymous, Route("v1/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRetornoHelper _retornoHelper;
        private readonly IUsuarioService _usuarioService;
        private readonly IValidator<Usuario> _validator;

        public UsuarioController(
            IRetornoHelper retornoHelper,
            IMapper mapper,
            IUsuarioService usuarioService,
            IValidator<Usuario> validator)
        {
            _retornoHelper = retornoHelper;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] UsuarioInserirViewModel model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                var validacao = await _validator.ValidateAsync(usuario);

                if (!validacao.IsValid)
                    return _retornoHelper.ErroValidacao(validacao.Errors.ParaRetorno());

                _usuarioService.Inserir(usuario);

                return _retornoHelper.Criado();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Excluir(Guid id)
        {
            try
            {
                _usuarioService.Excluir(id);

                return _retornoHelper.Sucesso();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                var validacao = await _validator.ValidateAsync(usuario);

                if (!validacao.IsValid)
                    return _retornoHelper.ErroValidacao(validacao.Errors.ParaRetorno());

                usuario.ID = id;

                _usuarioService.Editar(usuario);

                return _retornoHelper.Alterado();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            try
            {
                var usuarios = _usuarioService.Buscar();

                if (usuarios.Any())
                {
                    var usuariosMapeados = _mapper.Map<IEnumerable<UsuarioBuscarViewModel>>(usuarios);
                    return _retornoHelper.Sucesso(usuariosMapeados);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }

        }

        [HttpGet, Route("{id}")]
        public IActionResult Buscar(Guid id)
        {
            try
            {
                var usuario = _usuarioService.Buscar(id);

                if (usuario != null)
                {
                    var usuarioMapeado = _mapper.Map<UsuarioBuscarViewModel>(usuario);
                    return _retornoHelper.Sucesso(usuarioMapeado);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }

        }

        [HttpPost, Route("{id}/validar")]
        public IActionResult ValidarSenha(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.ID = id;

                return _retornoHelper.Sucesso(_usuarioService.ValidarSenha(usuario));
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }
    }
}
