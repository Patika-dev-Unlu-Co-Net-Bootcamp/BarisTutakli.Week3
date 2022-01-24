using BarisTutakli.WebApi.Common.Entities;
using BarisTutakli.WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Common.Base.Abstract;

namespace WebApi.Common.Base.Concrete
{
    public class BaseReadRepository<TEntity, TContext> : IRead<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly ECommerceDbContext _dbcontext;
        public BaseReadRepository(ECommerceDbContext context)
        {
            _dbcontext = context;
        }
        public  TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbcontext.Set<TEntity>().SingleOrDefault(filter);     
        }
    }
}
