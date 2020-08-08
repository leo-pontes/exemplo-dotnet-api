using LL.Curso.Domain.Contracts.Repositories;
using LL.Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LL.Curso.Data.EF.Repositories
{
    public abstract class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly StoreDataContext _ctx;
        protected readonly DbSet<TEntity> _db;

        public RepositoryEF(StoreDataContext ctx)
        {
            _ctx = ctx;
            _db = ctx.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _db.FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
            _ctx.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _ctx.Update(entity);
            _ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
