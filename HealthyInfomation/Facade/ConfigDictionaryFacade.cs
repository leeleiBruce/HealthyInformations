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
            return await this.GetAsync<List<FlyerTypeEntity>>("get");
        }

        public async Task<int> CreateFlyerType(FlyerTypeEntity entity)
        {
            return await this.PostAsync<FlyerTypeEntity, int>("create", entity);
        }

        public async Task<int> UpdateFlyerType(FlyerTypeEntity entity)
        {
            return await this.PutAsync<FlyerTypeEntity, int>("update", entity);
        }

        public async Task<int> DeleteFlyerType(int transactionID)
        {
            return await this.DeleteAsync<int>(string.Format("delete/{0}", transactionID));
        }
    }
}
