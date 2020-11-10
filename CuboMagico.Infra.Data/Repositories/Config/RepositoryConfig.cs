using CuboMagico.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CuboMagico.Infra.Data.Repositories.Config
{
    public class RepositoryConfig : IDisposable
    {
        // Coleção de interfaces - implementações que serão usadas na injeção de dependência da UnitOfWork
        private readonly ICollection<RepositoryBinding> _bindings;

        public RepositoryConfig()
        {
            _bindings = new List<RepositoryBinding>();
        }

        // Mesmo conceito da injeção de dependência 
        // Interface - Implementação
        // IUsuarioRepository, UsuarioRepository
        public RepositoryConfig AddBind<TInterface, TImplementacao>()
            where TInterface : IRepository
            where TImplementacao : Repository, TInterface
        {
            _bindings.Add(new RepositoryBinding(typeof(TInterface), typeof(TImplementacao)));

            return this;
        }

        public bool PossuiImplementacao(Type typeInterface)
            => _bindings.Any(x => x.TipoInterface == typeInterface);

        public Type ObterTipoImplementacao(Type typeInterface)
        {
            var tipoImplementacao = _bindings.FirstOrDefault(x => x.TipoInterface == typeInterface);

            return tipoImplementacao?.TipoImplementacao;
        }

        #region Dispose suporte
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _bindings.Clear();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
