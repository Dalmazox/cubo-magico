using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CuboMagico.Domain.Interfaces.Repositories
{
    public interface IRepository : IDisposable
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        TEntity Unique(Expression<Func<TEntity, bool>> filtro, params string[] includes);
        IEnumerable<TEntity> GetAll(params string[] includes);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
