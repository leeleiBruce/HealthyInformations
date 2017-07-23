using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.ConfigDictionary
{
    public interface IFlyerTypeRepository : IRepository<FlyerType>
    {
        List<FlyerType> GetFlyerType();
    }
}
