using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.Interfaces.UoW;
using System;

namespace CuboMagico.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Inserir(Usuario usuario)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();
            var jaExiste = usuarioRepositorio.Unique(u => u.Email == usuario.Email) != null;

            if (jaExiste)
                throw new Exception("Já existe um usuário cadastrado com esse e-mail");

            usuarioRepositorio.Insert(usuario);
        }
    }
}
