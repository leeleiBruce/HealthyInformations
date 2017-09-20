using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.ConfigDictionary
{
    public class FlyerTypeRepository : BaseRepository<FlyerType>, IFlyerTypeRepository
    {
        public FlyerTypeRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public List<FlyerType> GetFlyerType()
        {
            return this._context.Set<FlyerType>().ToList();
        }

        public FlyerType GetFlyerTypeByKey(int key)
        {
            return this._context.Set<FlyerType>().FirstOrDefault(f => f.TransactionNumber == key);
        }
    }
}
