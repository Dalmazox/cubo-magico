using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuboMagico.Application.Services
{
    public class UsuarioService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async void Inserir(Usuario usuario, Software software)
        {
            var usuarioRepository = _uow.Repositorio<IUsuarioRepository>();
            var softwareRepository = _uow.Repositorio<ISoftwareRepository>();

            await _uow.IniciarTransacaoAsync();
            software.Usuario = usuario;
            usuarioRepository.Insert(usuario);
            softwareRepository.Insert(software);
            await _uow.ComitarTransacaoAsync();
        }
    }
}
