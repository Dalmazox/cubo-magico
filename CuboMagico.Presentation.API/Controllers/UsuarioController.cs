using AutoMapper;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Helpers;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CuboMagico.Presentation.API.Controllers
{
    [ApiController, AllowAnonymous, Route("v1/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRetornoHelper _retornoHelper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IRetornoHelper retornoHelper, 
            IMapper mapper,
            IUsuarioService usuarioService)
        {
            _retornoHelper = retornoHelper;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpPost()]
        public IActionResult Inserir([FromBody] UsuarioInserirViewModel model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);

                _usuarioService.Inserir(usuario);

                return _retornoHelper.Criado();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }
    }
}
