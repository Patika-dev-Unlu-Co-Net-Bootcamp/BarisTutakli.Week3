using CleanArch.Domain.Entity;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        CinemaContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(CinemaContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

        }
        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public Task<IList<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
