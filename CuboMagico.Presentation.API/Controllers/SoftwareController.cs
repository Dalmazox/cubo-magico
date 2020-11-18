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
    [ApiController, AllowAnonymous, Route("v1/usuario")]
    public class SoftwareController
    {
        private readonly IMapper _mapper;
        private readonly IRetornoHelper _retornoHelper;
        private readonly IValidator<Software> _validator;
        private readonly ISoftwareService _softwareService;

        public SoftwareController(
            IMapper mapper,
            IRetornoHelper retornoHelper,
            IValidator<Software> validator, 
            ISoftwareService softwareService)
        {
            _mapper = mapper;
            _retornoHelper = retornoHelper;
            _validator = validator;
            _softwareService = softwareService;
        }

        [HttpPost, Route("{id}/[controller]")]
        public async Task<IActionResult> Inserir(Guid id, [FromBody] SoftwareInserirViewModel model)
        {
            try
            {
                var software = _mapper.Map<Software>(model);
                var validacao = await _validator.ValidateAsync(software);

                if (!validacao.IsValid)
                    return _retornoHelper.ErroValidacao(validacao.Errors.ParaRetorno());

                software.UsuarioID = id;

                _softwareService.Inserir(software);

                return _retornoHelper.Criado();
            }
            catch (Exception ex)
            {
                return _retornoHelper.Erro(ex.InnerException, ex.Message);
            }
        }
    }
}
