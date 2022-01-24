using BarisTutakli.WebApi.Common.Entities;
using BarisTutakli.WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Common.Base.Abstract;

namespace WebApi.Common.Base.Concrete
{
    public class BaseReadAllRepository<TEntity, TContext> : IReadAll<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly ECommerceDbContext _dbcontext;
        public BaseReadAllRepository(ECommerceDbContext context)
        {
            _dbcontext = context;
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbcontext.Set<TEntity>().AsNoTracking() :
                _dbcontext.Set<TEntity>().Where(filter).AsNoTracking();
        }

      
    }
}
