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
    public class BaseCreateRepository<TEntity,TContext> : ICreate<TEntity>
        where TEntity : BaseEntity
        where TContext:DbContext
    {
        private readonly TContext _dbcontext;
        public BaseCreateRepository(TContext context)
        {
            _dbcontext = context;
        }
        public int Create(TEntity entity)
        {
            //Deneme
            _dbcontext.Set<TEntity>().AddAsync(entity);
            _dbcontext.SaveChangesAsync();
            var createdItemId = entity.Id;
            return createdItemId;
        }
    }
}
