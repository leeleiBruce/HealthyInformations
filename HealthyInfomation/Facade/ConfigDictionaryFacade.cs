using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class ConfigDictionaryFacade : RestClientWrapper
    {
        public ConfigDictionaryFacade(WindowBase windowBase)
            : base("ConfigDictionaryWCF", "SystemManage", windowBase)
        {
        }

        public async Task<List<FlyerTypeEntity>> GetFlyerTypeList()
        {
            return await this.GetAsync<List<FlyerTypeEntity>>("flyertype/get");
        }
    }
}
