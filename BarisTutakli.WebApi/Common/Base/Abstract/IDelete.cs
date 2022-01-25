using BarisTutakli.WebApi.Common.Entities;
using System.Threading.Tasks;

namespace WebApi.Common.Base.Abstract
{
    interface IDelete<TEntity> where TEntity : BaseEntity
    {
        int Delete(TEntity entity);
    }
}
