using BarisTutakli.WebApi.Common.Entities;
using System.Threading.Tasks;

namespace WebApi.Common.Base.Abstract
{
    public interface IUpdate<TEntity> where TEntity : BaseEntity
    {
        // Return Updated product Id
        int Update(TEntity entity);
    }
}
