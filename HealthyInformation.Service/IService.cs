using HealthyInformation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyInformation.Service
{
    public interface IService<TEntity> 
        where TEntity : class, new()
    {
        BaseResponse Create(TEntity entity);

        BaseResponse Remove(TEntity entity);

        void RemoveWithoutCommit(TEntity entity);

        BaseResponse Update(TEntity entity);
    }
}
