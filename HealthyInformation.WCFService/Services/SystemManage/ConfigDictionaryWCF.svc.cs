using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using HealthyInformation.Service.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ConfigDictionaryService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ConfigDictionaryService.svc 或 ConfigDictionaryService.svc.cs，然后开始调试。
    public class ConfigDictionaryWCF : IConfigDictionaryWCF
    {
        IConfigDictionaryService configDictionary = new ConfigDictionaryService();
        public List<FlyerType> GetFlyerTypeList()
        {
            return configDictionary.GetFlyerType();
        }

        public int CreateFlyerType(FlyerTypeRequest flyerTypeRequest)
        {
           return configDictionary.CreateFlyerType(flyerTypeRequest);
        }


        public int UpdateFlyerType(FlyerTypeRequest flyerTypeRequest)
        {
            return configDictionary.UpdateFlyerType(flyerTypeRequest);
        }

        public int DeleteFlyerType(string transactionNumber)
        {
            return configDictionary.DeleteFlyerType(transactionNumber);
        }
    }
}
