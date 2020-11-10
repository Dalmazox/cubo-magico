using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.UoW;
using CuboMagico.Infra.Data.Context;
using CuboMagico.Infra.Data.Repositories.Config;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuboMagico.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CuboContext _context;
        private readonly RepositoryConfig _config; // Lista de repositórios passados via injeção de dependência no 'Configure' (IOptions)

        // Propriedade nativa do .NET de controle da transação corrente no banco
        private IDbContextTransaction _transaction { get; set; } = null;

        public UnitOfWork(
            CuboContext context,
            IOptions<RepositoryConfig> config)
        {
            _context = context;
            _config = config.Value;
        }

        public async Task IniciarTransacaoAsync()
        {
            if (_transaction is null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task ReverterTransacaoAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task ComitarTransacaoAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public Task<int> SalvarAlteracoesAsync()
            => _context.SaveChangesAsync();

        public T Repositorio<T>() where T : class, IRepository
        {
            Type tipoT = typeof(T);

            // Váriavel de controle do tipo do repositório
            Type tipoRepositorio = null;

            if (!(_config is null) && _config.PossuiImplementacao(tipoT))
                tipoRepositorio = _config.ObterTipoImplementacao(tipoT);

            if (tipoRepositorio is null)
                throw new ArgumentNullException($"{typeof(T)} não implementado");

            // Instanciando um repositório pela UoW usando sempre o mesmo contexto do banco como paramêtro construtor 
            // UoW é injetada como Singleton no arquivo Injector.cs
            return (T)Activator.CreateInstance(tipoRepositorio, new object[] { _context });
        }

        #region Dispose suporte

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                    _transaction?.Dispose();
                }

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
