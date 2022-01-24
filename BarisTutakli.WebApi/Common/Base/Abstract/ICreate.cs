using BarisTutakli.WebApi.Common.Entities;

namespace WebApi.Common.Base.Abstract
{
    public interface ICreate<TEntity> where TEntity : BaseEntity
    {
        int Create(TEntity entity);
    }
}
