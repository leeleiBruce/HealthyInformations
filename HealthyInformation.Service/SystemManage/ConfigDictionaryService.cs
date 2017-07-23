using HealthyInformation.Model;
using HealthyInformation.Repository.ConfigDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class ConfigDictionaryService :  IConfigDictionaryService
    {
        IFlyerTypeRepository flyerTypeRepository;
        HealthyInformationEntities dbContext;
        public ConfigDictionaryService()
        {
            this.dbContext = new HealthyInformationEntities();
            this.flyerTypeRepository = new FlyerTypeRepository(this.dbContext);
        }

        public List<FlyerType> GetFlyerType()
        {
            return this.flyerTypeRepository.GetFlyerType();
        }
    }
}
