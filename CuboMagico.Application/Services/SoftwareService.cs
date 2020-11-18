using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.Interfaces.UoW;
using CuboMagico.Domain.ViewModels;
using System;

namespace CuboMagico.Application.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly IUnitOfWork _uow;

        private const string UsuarioNaoEncontrado = "Usuário não encontrado";

        public SoftwareService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Inserir(Software software)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();
            var softwareRepositorio = _uow.Repositorio<ISoftwareRepository>();

            var usuario = usuarioRepositorio.Unique(u => u.ID == software.UsuarioID);

            if (usuario is null)
                throw new Exception(UsuarioNaoEncontrado);

            software.Usuario = usuario;

            softwareRepositorio.Insert(software);
        }
    }
}
