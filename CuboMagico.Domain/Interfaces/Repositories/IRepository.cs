using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuboMagico.Domain.Interfaces.Repositories
{
    public interface IRepository : IDisposable
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        TEntity Find<T>(T key);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
