using CuboMagico.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CuboMagico.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        void Inserir(Usuario usuario);
        void Editar(Usuario usuario);
        void Excluir(Guid id);
        bool ValidarSenha(Usuario usuario);
        Usuario Buscar(Guid id);
        IEnumerable<Usuario> Buscar();
    }
}
