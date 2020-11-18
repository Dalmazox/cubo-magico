using CuboMagico.Application.Helpers;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;

namespace CuboMagico.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;

        private const string UsuarioDuplicado = "Já existe um usuário cadastrado com esse e-mail";
        private const string UsuarioNaoEncontrado = "Usuário não encontrado";

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Editar(Usuario usuario)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();

            var usuarioNoBanco = UsuarioExiste(usuarioRepositorio, usuario.ID);

            // Checar se existe algum outro usuário com o e-mail editado
            var jaExiste = usuarioRepositorio.Unique(u => u.Email == usuario.Email && u.ID != usuario.ID) != null;
            if (jaExiste)
                throw new Exception(UsuarioDuplicado);

            usuario.Senha = SenhaHelper.CriarHash(usuario.Senha);

            EntityHelper.TransferirPropriedades(usuario, usuarioNoBanco);

            usuarioRepositorio.Update(usuarioNoBanco);
        }

        public void Inserir(Usuario usuario)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();
            var jaExiste = _uow.Repositorio<IUsuarioRepository>().Unique(u => u.Email == usuario.Email) != null;

            if (jaExiste)
                throw new Exception(UsuarioDuplicado);

            usuario.Senha = SenhaHelper.CriarHash(usuario.Senha);

            usuarioRepositorio.Insert(usuario);
        }

        public void Excluir(Guid id)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();

            var usuario = UsuarioExiste(usuarioRepositorio, id);

            usuarioRepositorio.Delete(usuario);
        }

        public Usuario Buscar(Guid id)
            => _uow.Repositorio<IUsuarioRepository>().Unique(u => u.ID == id, "Softwares");

        public IEnumerable<Usuario> Buscar()
            => _uow.Repositorio<IUsuarioRepository>().GetAll("Softwares");

        public bool ValidarSenha(Usuario usuario)
        {
            var usuarioRepositorio = _uow.Repositorio<IUsuarioRepository>();

            var hash = UsuarioExiste(usuarioRepositorio, usuario.ID).Senha;

            return SenhaHelper.HashValida(usuario.Senha, hash);
        }

        private Usuario UsuarioExiste(IUsuarioRepository repositorio, Guid id)
        {
            // Checar se usuário existe pelo ID
            var usuario = repositorio.Unique(u => u.ID == id);
            if (usuario == null)
                throw new Exception(UsuarioNaoEncontrado);

            return usuario;
        }
    }
}
