using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Create(TEntity entity);
    }
}
