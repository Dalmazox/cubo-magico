using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CuboMagico.Infra.Data.Repositories
{
    public class Repository : IRepository
    {
        protected readonly CuboContext _context;

        // Contexto passado pela UnitOfWork
        public Repository(CuboContext context)
        {
            _context = context;
        }

        #region Dispose suporte
        protected bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class Repository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CuboContext context) : base(context)
        {
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            // Busca da entidade no banco para "agarrar" e modificar para delete
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual TEntity Unique(Expression<Func<TEntity, bool>> filtro, params string[] includes)
        {
            var query = _dbSet.AsQueryable();

            // Adicionando JOINS na SQL usando o Include das propriedades via parametros
            if (includes.Any())
                foreach (var include in includes)
                    query = _dbSet.Include(include);

            return query.FirstOrDefault(filtro);
        }

        public virtual IEnumerable<TEntity> GetAll(params string[] includes)
        {
            var query = _dbSet.AsQueryable();

            // Adicionando JOINS na SQL usando o Include das propriedades via parametros
            if (includes.Any())
                foreach (var include in includes)
                    query = _dbSet.Include(include);

            return query.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if(entities is null || !entities.Any())
                throw new ArgumentNullException(nameof(entities));

            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            // Busca da entidade no banco para "agarrar" e modificar para update
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
