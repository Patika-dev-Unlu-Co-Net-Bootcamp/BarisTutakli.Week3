using BarisTutakli.WebApi.Common.Entities;
using BarisTutakli.WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Common.Base.Abstract;

namespace WebApi.Common.Base.Concrete
{
    public class BaseDeleteRepository<TEntity, TContext> : IDelete<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly ECommerceDbContext _dbcontext;
        public BaseDeleteRepository(ECommerceDbContext context)
        {
            _dbcontext = context;
        }
        public int Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
