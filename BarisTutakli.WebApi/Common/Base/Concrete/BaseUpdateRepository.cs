using BarisTutakli.WebApi.Common.Entities;
using BarisTutakli.WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common.Base.Abstract;

namespace WebApi.Common.Base.Concrete
{
    public class BaseUpdateRepository<TEntity, TContext> : IUpdate<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly ECommerceDbContext _dbcontext;
        public BaseUpdateRepository(ECommerceDbContext context)
        {
            _dbcontext = context;
        }
        public int Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            _dbcontext.SaveChangesAsync();
            var updatedItemId = entity.Id;
            return updatedItemId;
            
        }
    }
}
