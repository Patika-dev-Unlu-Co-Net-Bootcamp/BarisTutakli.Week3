using CleanArch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IList<TEntity>> Get(Expression<Func<TEntity,bool>> filter);
        
    }
}
