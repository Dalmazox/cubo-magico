using CuboMagico.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace CuboMagico.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task IniciarTransacaoAsync();
        Task ComitarTransacaoAsync();
        Task ReverterTransacaoAsync();
        Task<int> SalvarAlteracoesAsync();
        T Repositorio<T>() where T : class, IRepository;
    }
}
